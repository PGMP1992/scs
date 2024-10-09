using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;
using SCS.Utility;

namespace SCS.Areas.Admin;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]

public class BundleController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public BundleController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        IEnumerable<Bundle> bundleList = _unitOfWork.Bundle.GetAll();

        foreach (var item in bundleList)
        {
            if (item.ProductId1 > 0 && _unitOfWork.Product.Any(u => u.Id == item.ProductId1))
            {
                item.Product1 = _unitOfWork.Product.Get(u => u.Id == item.ProductId1, includeProperties: "Category");
            }
            else
            {
                item.Product1 = new Product();
                item.Product1.Category = new Category();
            }

            if (item.ProductId2 > 0 && _unitOfWork.Product.Any(u => u.Id == item.ProductId2))
            {
                item.Product2 = _unitOfWork.Product.Get(u => u.Id == item.ProductId2, includeProperties: "Category");
            }
            else
            {
                item.Product2 = new Product();
                item.Product2.Category = new Category();
            }

            if (item.ProductId3 > 0 && _unitOfWork.Product.Any(u => u.Id == item.ProductId3))
            {
                item.Product3 = _unitOfWork.Product.Get(u => u.Id == item.ProductId3, includeProperties: "Category");
            }
            else
            {
                item.Product3 = new Product();
                item.Product3.Category = new Category();
            }
        }

        return View(bundleList);
    }

    public IActionResult Upsert(int? id)
    {
        BundleVM bundleVM = new BundleVM()
        {
            Bundle = new Bundle(),

            ProductList1 = _unitOfWork.Product.GetAll(includeProperties: "Category").Select(u => new SelectListItem
            {
                Text = u.Name + ", Category: " + u.Category.Name,
                Value = u.Id.ToString()
            }),

            ProductList2 = _unitOfWork.Product.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name + ", Category: " + u.Category.Name,
                Value = u.Id.ToString()
            }),
    
            ProductList3 = _unitOfWork.Product.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name + ", Category: " + u.Category.Name,
                Value = u.Id.ToString()
            }),
        };

        if (id != null && id > 0)
        {
            bundleVM.Bundle = _unitOfWork.Bundle.Get(u => u.Id == id);
            if (bundleVM.Bundle.ProductId1 > 0)
            {
                bundleVM.Bundle.Product1 = _unitOfWork.Product.Get(u => u.Id == bundleVM.Bundle.ProductId1, includeProperties: "Category");
            }
            
            if (bundleVM.Bundle.ProductId1 > 0)
            {
                bundleVM.Bundle.Product2 = _unitOfWork.Product.Get(u => u.Id == bundleVM.Bundle.ProductId2, includeProperties: "Category");

            }
            
            if (bundleVM.Bundle.ProductId1 > 0)
            {
                bundleVM.Bundle.Product3 = _unitOfWork.Product.Get(u => u.Id == bundleVM.Bundle.ProductId3, includeProperties: "Category");

            }
        }
        return View(bundleVM);
    }

    [HttpPost]
    public IActionResult Upsert(BundleVM bundleVM)
    {
        string message = "";

        if (ModelState.IsValid)
        {
            if (bundleVM.Bundle.Id == 0)
            {
                if (!_unitOfWork.Category.Any(u => u.Name == "Bundles"))
                {
                    Category category = new Category()
                    {
                        Name = "Bundles",
                        Description = "Packages of products witch belongs together"
                    };
                    _unitOfWork.Category.Add(category);
                    
                }

                bundleVM.Bundle.ProductId1 = bundleVM.Bundle.Product1.Id;
                bundleVM.Bundle.ProductId2 = bundleVM.Bundle.Product2.Id;
                bundleVM.Bundle.ProductId3 = bundleVM.Bundle.Product3.Id;

                _unitOfWork.Bundle.Add(bundleVM.Bundle);
                message = "Bundle Created";
            }
            else
            {
                bundleVM.Bundle.ProductId1 = bundleVM.Bundle.Product1.Id;
                bundleVM.Bundle.ProductId2 = bundleVM.Bundle.Product2.Id;
                bundleVM.Bundle.ProductId3 = bundleVM.Bundle.Product3.Id;

                _unitOfWork.Bundle.Update(bundleVM.Bundle);
                message = "Bundle Updated";
            }

            _unitOfWork.Save();
            TempData["success"] = message;
    
            int providerId = 0;
            
            if (bundleVM.Bundle.ProductId1 > 0)
            {
                Product product = _unitOfWork.Product.Get(u => u.Id == bundleVM.Bundle.ProductId1);
                providerId = _unitOfWork.Provider.Get(u => u.Id == product.ProviderId).Id;
            }
            
            if (bundleVM.Bundle.ProductId2 > 0 && providerId == 0)
            {
                Product product = _unitOfWork.Product.Get(u => u.Id == bundleVM.Bundle.ProductId2);
                providerId = _unitOfWork.Provider.Get(u => u.Id == product.ProviderId).Id;
            }
            
            if (bundleVM.Bundle.ProductId3 > 0 && providerId == 0)
            {
                Product product = _unitOfWork.Product.Get(u => u.Id == bundleVM.Bundle.ProductId3);
                providerId = _unitOfWork.Provider.Get(u => u.Id == product.ProviderId).Id;
            }
            
            if (!(_unitOfWork.Product.Any(u => u.BundleId == bundleVM.Bundle.Id)))
            {
                string description = "Contains: ";
                
                if (bundleVM.Bundle.ProductId1 > 0)
                {
                    Product product1 = _unitOfWork.Product.Get(u => u.Id == bundleVM.Bundle.ProductId1, includeProperties: "Category");
                    description = description + product1.Category.Name + " " + product1.Name;
                }
                
                if (bundleVM.Bundle.ProductId2 > 0)
                {
                    Product product2 = _unitOfWork.Product.Get(u => u.Id == bundleVM.Bundle.ProductId2, includeProperties: "Category");
                    description = description + ",\n      " + product2.Category.Name + " " + product2.Name;
                }
                
                if (bundleVM.Bundle.ProductId3 > 0)
                {
                    Product product3 = _unitOfWork.Product.Get(u => u.Id == bundleVM.Bundle.ProductId3, includeProperties: "Category");
                    description = description + ",\n       " + product3.Category.Name + " " + product3.Name;
                }
                
                Product product = new Product()
                {
                    Name = bundleVM.Bundle.Name,
                    Price = bundleVM.Bundle.Price,
                    CategoryId = _unitOfWork.Category.Get(u => u.Name == "Bundles").Id,
                    Description = description,
                    BundleId = bundleVM.Bundle.Id
                };
                
                if (providerId > 0 && _unitOfWork.Provider.Any(u => u.Id == providerId))
                {
                    product.ProviderId = providerId;
                }

                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }
        else
        {
            bundleVM.ProductList1 = _unitOfWork.Product.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            
            bundleVM.ProductList2 = _unitOfWork.Product.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            
            bundleVM.ProductList3 = _unitOfWork.Product.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(bundleVM);
        }
    }

    public IActionResult Delete(int id)
    {

        if (id != null && id > 0)
        {
            Bundle bundle = _unitOfWork.Bundle.Get(u => u.Id == id);

            bundle = _unitOfWork.Bundle.Get(u => u.Id == id);
            bundle.Product1 = _unitOfWork.Product.Get(u => u.Id == bundle.ProductId1);
            bundle.Product2 = _unitOfWork.Product.Get(u => u.Id == bundle.ProductId2);
            bundle.Product3 = _unitOfWork.Product.Get(u => u.Id == bundle.ProductId3);

            return View(bundle);



        }
        else
        {

            TempData["error"] = "No bundle to delete";
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    public IActionResult Delete(int? id)
    {
        //Bundle and product will be deleted if the product isnt in OrderDetails
        Bundle bundle = new Bundle();
        if (id > 0)
        {
            bundle = _unitOfWork.Bundle.Get(u => u.Id == id);
            
            if (_unitOfWork.Product.Any(u => u.BundleId == id))
            {
                Product product = _unitOfWork.Product.Get(u => u.BundleId == id);
                if (!(_unitOfWork.OrderDetails.Any(u => u.ProductId == product.Id)))
                {
                    string productPath = @"images\products\product-" + id;
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
                }
                else
                {
                    TempData["error"] = "The bundle is used in a product which has been ordered and cant be deleted";
                    return View(bundle);
                }
            }

            _unitOfWork.Bundle.Remove(bundle);
            _unitOfWork.Save();
            TempData["success"] = "Bundle was Deleted";
            return RedirectToAction("Index");
        }
        else
        {
            TempData["error"] = "Error deleting Bundle";
            return View(bundle);
        }
    }

}
