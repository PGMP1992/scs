using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCS.DataAccess.Repository.IRepository;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Utility;

namespace SCSWeb.Areas.Admin;


[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]

public class CertificationSlotsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public CertificationSlotsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        IEnumerable<CertificationSlot> certificationSlotList = _unitOfWork.CertificationSlot.GetAll(includeProperties: "Product");

        return View(certificationSlotList);

    }
    public IActionResult Upsert(int? id)
    {
        CertificationSlotVM certificationSlotVM = new CertificationSlotVM()
        {
            CertificationSlot = new CertificationSlot(),

            ProductList = _unitOfWork.Product.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }),


        };

        if (id != null && id > 0)
        {
            certificationSlotVM.CertificationSlot = _unitOfWork.CertificationSlot.Get(u => u.Id == id, includeProperties: "Product");
        }

        return View(certificationSlotVM);
    }

    [HttpPost]
    public IActionResult Upsert(CertificationSlotVM certificationSlotVM)
    {
        if (ModelState.IsValid)
        {
            if (certificationSlotVM.CertificationSlot.Id == 0)
            {
                _unitOfWork.CertificationSlot.Add(certificationSlotVM.CertificationSlot);
            }
            else
            {
                _unitOfWork.CertificationSlot.Update(certificationSlotVM.CertificationSlot);
            }
            _unitOfWork.Save();



            TempData["success"] = "The certificationSlot was created/updated";
            return RedirectToAction("Index");
        }
        else
        {
            certificationSlotVM.ProductList = _unitOfWork.Product.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });


            return View(certificationSlotVM);
        }
    }

    public IActionResult Delete(int id)
    {

        if (id != null && id > 0)
        {
            CertificationSlot certificationSlot = _unitOfWork.CertificationSlot.Get(u => u.Id == id, includeProperties: "Product");
            return View(certificationSlot);
        }
        TempData["error"] = "No certificationSlot to delete";
        return View();
    }

    [HttpPost]
    public IActionResult Delete(int? id)
    {
        var certificationSlot = _unitOfWork.CertificationSlot.Get(u => u.Id == id);
        if (certificationSlot == null)
        {
            TempData["error"] = "Error with deleting";
        }



        _unitOfWork.CertificationSlot.Remove(certificationSlot);
        _unitOfWork.Save();
        TempData["success"] = "The certificationSlot was deleted";
        return RedirectToAction("Index");
    }

    #region APICALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<CertificationSlot> CertificationSlotList = _unitOfWork.CertificationSlot.GetAll(includeProperties: "Product");
        foreach (var item in CertificationSlotList)
        {

        }
        return Json(new { data = CertificationSlotList });

    }

    #endregion
}
