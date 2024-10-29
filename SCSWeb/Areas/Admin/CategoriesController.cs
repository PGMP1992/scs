using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;
using SCS.Utility;
using static System.Collections.Specialized.BitVector32;

namespace SCS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]

public class CategoriesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> CategoryList = _unitOfWork.Category.GetAll();
        List<CategoryVM> categoryVMs = new List<CategoryVM>();
        foreach (var cat in CategoryList)
        {
            bool okToDelete = false;
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(u => u.CategoryId == cat.Id);
            if (!products.Any() && cat.Id!=1 && cat.Id!=4)
            {
                okToDelete = true;
            }
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.Category = cat;
            categoryVM.OkToDelete = okToDelete;
            categoryVMs.Add(categoryVM);
        }
        return View(categoryVMs);
    }

    public IActionResult Upsert(int? id)
    {
        Category categoryFromDb = new Category();
        if (id != null)
        {
            categoryFromDb =  _unitOfWork.Category.Get(c => c.Id == id);
        }
        return View(categoryFromDb);
    }

    [HttpPost]
    public IActionResult Upsert(Category category)
    {
        string message = string.Empty;
        if (ModelState.IsValid)
        {
            if (category.Id == 0)
            {
                _unitOfWork.Category.Add(category);
                message = "The category was created successfully";
            }
            else
            {
                _unitOfWork.Category.Update(category);
                message = "The category was updated successfully";
            }

            _unitOfWork.Save();
            TempData["success"] = message;
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Delete(int? id)
    {
        Category categoryFromDb = new Category();
        if (id != null)
        {
            categoryFromDb = _unitOfWork.Category.Get(c => c.Id == id);
        }
        return View(categoryFromDb);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
       
        Category category = new Category();
        

        if (id == 0 || id == null)
        {
            TempData["error"] = "Something went wrong, there is no such category to delete";
            return RedirectToAction("Index");
        }
        if (id != null && id > 0)
        {
            category = _unitOfWork.Category.Get(c => c.Id == id);
        }
        IEnumerable<Product> products = _unitOfWork.Product.GetAll(u => u.CategoryId == category.Id);
        if (products.Any())
        {
            TempData["error"] = "The category is used and can´t be deleted";
            return View();
        }
       

        _unitOfWork.Category.Remove(category);
        _unitOfWork.Save();
        TempData["success"] = "The category was deleted";
       
        return RedirectToAction("Index");
       
    }
}

