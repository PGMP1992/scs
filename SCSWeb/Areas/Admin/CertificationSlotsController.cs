using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCS.Models;
using SCS.Repository.IRepository;
using SCS.Utility;

namespace SCS.Areas.Admin;

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
        IEnumerable<CertificationSlot> cerSlotList = _unitOfWork.CertificationSlot.GetAll();
        return View(cerSlotList);
    }

    public IActionResult Upsert(int? id)
    {
        CertificationSlot certSlot = new CertificationSlot();

        if (id != null && id > 0)
        {
            certSlot = _unitOfWork.CertificationSlot.Get(u => u.Id == id);
        }
        return View(certSlot);
    }

    [HttpPost]
    public IActionResult Upsert(CertificationSlot certSlot)
    {
        string message = "";

        if (ModelState.IsValid)
        {
            if (certSlot.Id == 0)
            {
                _unitOfWork.CertificationSlot.Add(certSlot);
                message = "Certification Slot Created";
            }
            else
            {
                _unitOfWork.CertificationSlot.Update(certSlot);
                message = "Certification Slot Updated";
            }
            _unitOfWork.Save();

            TempData["success"] = message;
            return RedirectToAction("Index");
        }

        CertificationSlot newCertSlot = new CertificationSlot();
        TempData["error"] = "The certification slot couldnt be updated";
        return View(newCertSlot);
    }

    public IActionResult Delete(int id)
    {

        if (id != null && id > 0)
        {
            CertificationSlot certificationSlot = _unitOfWork.CertificationSlot.Get(u => u.Id == id);
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
        IEnumerable<CertificationSlot> CertificationSlotList = _unitOfWork.CertificationSlot.GetAll();
        foreach (var item in CertificationSlotList)
        {

        }
        return Json(new { data = CertificationSlotList });

    }

    #endregion
}
