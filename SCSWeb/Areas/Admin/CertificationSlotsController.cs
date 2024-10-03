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
        
        IEnumerable<CertificationSlot> cerSlotList =_unitOfWork.CertificationSlot.GetAll();

        return View(cerSlotList);
       
    }
    public IActionResult Upsert(int? id)
    {
        CertificationSlot certSlot = new CertificationSlot();
        

        if (id != null && id > 0)
        {
            certSlot = _unitOfWork.CertificationSlot.Get(u=>u.Id==id);
        }

        return View(certSlot);
    }

    [HttpPost]
    public IActionResult Upsert(CertificationSlot certSlot)
    {
        if (ModelState.IsValid)
        {
            if (certSlot.Id == 0)
            {
                _unitOfWork.CertificationSlot.Add(certSlot);
            }
            else
            {
                _unitOfWork.CertificationSlot.Update(certSlot);
            }
            _unitOfWork.Save();

          

            TempData["success"] = "The certificationSlot was created/updated";
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
            CertificationSlot certificationSlot = _unitOfWork.CertificationSlot.Get(u=>u.Id==id);
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
