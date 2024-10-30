using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;
using SCS.Utility;

namespace SCS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]

public class ProvidersController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public ProvidersController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Provider> ProviderList = _unitOfWork.Provider.GetAll();
        List<ProviderVM> providerVMs = new List<ProviderVM>();
        foreach (var cat in ProviderList)
        {
            bool okToDelete = false;
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(u => u.ProviderId == cat.Id);
            if (!products.Any())
            {
                okToDelete = true;
            }
            ProviderVM providerVM = new ProviderVM();
            providerVM.Provider = cat;
            providerVM.OkToDelete = okToDelete;
            providerVMs.Add(providerVM);
        }
        return View(providerVMs);
    }

    public ActionResult Upsert(int? id)
    {
        Provider providerFromDb = new Provider();
        if (id != null)
        {
            providerFromDb = _unitOfWork.Provider.Get(c => c.Id == id);
        }
        return View(providerFromDb);
    }

    [HttpPost]
    public IActionResult Upsert(Provider provider)
    {
        if (ModelState.IsValid)
        {
            if (provider.Id == 0)
            {
                _unitOfWork.Provider.Add(provider);
            }
            else
            {
                _unitOfWork.Provider.Update(provider);
            }

            _unitOfWork.Save();
            TempData["success"] = "The provider was created/updated";
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Delete(int? id)
    {
        Provider providerFromDb = new Provider();
        if (id != null)
        {
            providerFromDb = _unitOfWork.Provider.Get(c => c.Id == id);
        }
        return View(providerFromDb);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {

        Provider provider = new Provider();


        if (id == 0)
        {
            TempData["error"] = "Something went wrong, there is no such provider to delete";
            return RedirectToAction("Index");
        }
        if (id > 0)
        {
            provider = _unitOfWork.Provider.Get(c => c.Id == id);
        }
        IEnumerable<Product> products = _unitOfWork.Product.GetAll(u => u.ProviderId == provider.Id);
        if (products.Any())
        {
            TempData["error"] = "The provider is used and can´t be deleted";
            return View();
        }


        _unitOfWork.Provider.Remove(provider);
        _unitOfWork.Save();
        TempData["success"] = "The provider was deleted";

        return RedirectToAction("Index");

    }


}

