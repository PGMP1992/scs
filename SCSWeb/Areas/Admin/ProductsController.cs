using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;
using SCS.Utility;

namespace SCS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]

public class ProductsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductsController(IUnitOfWork unitOfWork
        , IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Provider,Category,CertificationSlot");
        return View(productList);
    }

    public IActionResult Upsert(int? id)
    {
        ProductVM productVM = new ProductVM()
        {
            Product = new Product(),

            CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }),

            ProviderList = _unitOfWork.Provider.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }),
            CertSlotList = _unitOfWork.CertificationSlot.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            })
        };

        if (id != null && id > 0)
        {
            productVM.Product = _unitOfWork.Product.Get(u => u.Id == id, includeProperties: "ProductImages,Provider,Category,CertificationSlot");
        }

        return View(productVM);
    }

    [HttpPost]
    public IActionResult Upsert(ProductVM productVM, List<IFormFile> files)
    {
        string message = "";

        if (ModelState.IsValid)
        {
            if (productVM.Product.Id == 0)
            {
                //if (productVM.Product.CategoryId == 1)
                //{
                //    productVM.Product.VoucherKey = Guid.NewGuid().ToString();
                //}
                _unitOfWork.Product.Add(productVM.Product);
                message = "Product was Created";
            }
            else
            {
                _unitOfWork.Product.Update(productVM.Product);
                message = "Product Updated";
            }
            _unitOfWork.Save();

            string wwwRootPath = _webHostEnvironment.WebRootPath;

            if (files != null)
            {
                foreach (IFormFile file in files)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = @"images\products\product-" + productVM.Product.Id;
                    string finalPath = Path.Combine(wwwRootPath, productPath);

                    if (!Directory.Exists(finalPath))
                    {
                        Directory.CreateDirectory(finalPath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    ProductImage productImage = new ProductImage()
                    {
                        ImageUrl = @"\" + productPath + @"\" + fileName,
                        ProductId = productVM.Product.Id,
                    };

                    if (productVM.Product.ProductImages == null)
                    {
                        productVM.Product.ProductImages = new List<ProductImage>();
                    }

                    productVM.Product.ProductImages.Add(productImage);
                }
                _unitOfWork.Product.Update(productVM.Product);
                _unitOfWork.Save();
            }

            TempData["success"] = message;
            return RedirectToAction("Index");
        }
        else
        {
            productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            productVM.ProviderList = _unitOfWork.Provider.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            productVM.CertSlotList = _unitOfWork.CertificationSlot.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            return View(productVM);
        }
    }

    public IActionResult DeleteImage(int imageId)
    {
        var imgToBeDeleted = _unitOfWork.ProductImage.Get(u => u.Id == imageId);

        if (imgToBeDeleted != null)
        {
            if (!string.IsNullOrEmpty(imgToBeDeleted.ImageUrl))
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, imgToBeDeleted.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _unitOfWork.ProductImage.Remove(imgToBeDeleted);
            _unitOfWork.Save();
            TempData["success"] = "The image was removed";
        }
        return RedirectToAction(nameof(Upsert), new { id = imgToBeDeleted.ProductId });
    }

    public IActionResult Delete(int id)
    {
        if (id != null && id > 0)
        {
            Product product = _unitOfWork.Product.Get(u => u.Id == id, includeProperties: "ProductImages,Category,Provider");
            return View(product);
        }
        TempData["error"] = "No product to delete";
        return View();
    }

    [HttpPost]
    public IActionResult Delete(int? Id)
    {
        //If the product is in order register it will change status to expired but not be deleted
        var product = _unitOfWork.Product.Get(u => u.Id == Id);
        if (product == null)
        {
            TempData["error"] = "Error with deleting";
        }

        if (_unitOfWork.Bundle.Any(u => u.ProductId1 == Id)
            || _unitOfWork.Bundle.Any(u => u.ProductId2 == Id)
            || _unitOfWork.Bundle.Any(u => u.ProductId3 == Id))
        {
            TempData["error"] = "The product is a part of a bundle, delete the bundle first";
            return View(product);
        }

        if (!_unitOfWork.OrderDetails.Any(u => u.ProductId == Id))
        {
            string productPath = @"images\products\product-" + Id;
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, productPath);
            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }
                Directory.Delete(finalPath);
            }
            _unitOfWork.Product.Remove(product);
            TempData["success"] = "The product was deleted";
        }
        else
        {
            product.Status = SD.ProductStatusExpired;
            _unitOfWork.Product.Update(product);
            TempData["success"] = "The product status is changed to expired";
        }
        _unitOfWork.Save();

        return RedirectToAction("Index");
    }

    #region APICALLS

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Product> ProductList = _unitOfWork.Product.GetAll(includeProperties: "Provider,Category");
        return Json(new { data = ProductList });
    }

    #endregion
}
