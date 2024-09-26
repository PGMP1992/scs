using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCS.Models;
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
        return View(ProviderList);
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
    public IActionResult Delete(Provider provider)
    {
        if (provider.Id == 0 || provider.Id == null)
        {
            TempData["error"] = "Something went wrong, there is no such provider to delete";
            return View();
        }

        _unitOfWork.Provider.Remove(provider);
        _unitOfWork.Save();

        return RedirectToAction("Index");
        TempData["success"] = "The provider was deleted";
    }


    #region APICALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<Provider> ProviderList = _unitOfWork.Provider.GetAll();
        return Json(new { data = ProviderList });
    }

    #endregion
}

