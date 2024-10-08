using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;
using SCS.Utility;
using Stripe;

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
        
        IEnumerable<CertificationSlot> cerSlotList =_unitOfWork.CertificationSlot.GetAll(includeProperties: "CertificationDays");

        return View(cerSlotList);
    }

    public IActionResult Upsert(int? id)
    {

        CertificationSlotVM certSlotVM = new CertificationSlotVM()
        {
            CertificationSlot=new CertificationSlot(),
            ShowDays=false
        };
       

        if (id != null && id > 0)
        {
            certSlotVM.CertificationSlot = _unitOfWork.CertificationSlot.Get(u => u.Id == id,includeProperties:"CertificationDays");

            bool isCertDay = false;
           
            foreach (var item in certSlotVM.CertificationSlot.CertificationDays)
            {
                if (certSlotVM.CertificationSlot.Dates is not null)
                { 
                    if(certSlotVM.CertificationSlot.Dates.Contains(item.Date))
                    {
                        item.IsCertDay = true;
                    }
                    else
                    {
                        item.IsCertDay= false;
                    }
                }
                else
                {
                    item.IsCertDay=false;
                }
            }
            

            if (certSlotVM.CertificationSlot.EndDate>certSlotVM.CertificationSlot.StartDate)
            {
                certSlotVM.ShowDays=true;
            }
            
        }

        return View(certSlotVM);
    }

    [HttpPost]
    public IActionResult Upsert(CertificationSlotVM certSlotVM)
    {
      
        if (ModelState.IsValid )
        {
            if (certSlotVM.CertificationSlot.CertificationDays is not null)
            { 
            foreach (var item in certSlotVM.CertificationSlot.CertificationDays)
            {
                if(item.IsCertDay)
                {
                    certSlotVM.CertificationSlot.Dates.Add(item.Date);
                }
            }
            }
            if (certSlotVM.CertificationSlot.Id == 0)
            {
                
                _unitOfWork.CertificationSlot.Add(certSlotVM.CertificationSlot);
            }
            else
            {
                _unitOfWork.CertificationSlot.Update(certSlotVM.CertificationSlot);
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

    [HttpPost]
    public IActionResult ShowDays(CertificationSlotVM certSlotVM)
    {
        if (certSlotVM.CertificationSlot.EndDate<=certSlotVM.CertificationSlot.StartDate)
        {
            TempData["error"] = "The End Date has to be larger than the Start Date";
            return RedirectToAction(nameof(Upsert),new {id=certSlotVM.CertificationSlot.Id});
        }
        _unitOfWork.CertificationSlot.Add(certSlotVM.CertificationSlot);
        _unitOfWork.Save();
        CertificationSlot certSlotFromDb = _unitOfWork.CertificationSlot.Get(u => u.Id == certSlotVM.CertificationSlot.Id);
        TimeOnly time=new TimeOnly(00,00,00);
        TimeSpan intervall= certSlotVM.CertificationSlot.EndDate.ToDateTime(time) - certSlotVM.CertificationSlot.StartDate.ToDateTime(time);
        DateOnly newDate = certSlotVM.CertificationSlot.StartDate;
        CertificationDay certDay= new CertificationDay();
        List<CertificationDay> days= new List<CertificationDay>();
        for (int i = 0; i<intervall.Days;i++)
        {
            newDate=newDate.AddDays(1);
       
            certDay = new()
            {
                Date = newDate,
                IsCertDay = false,
                CertSlotId=certSlotFromDb.Id
            };
            _unitOfWork.CertificationDay.Add(certDay);
            _unitOfWork.Save();
            days.Add(certDay);
        }
        certSlotVM.CertificationSlot.CertificationDays = days;
        certSlotVM.ShowDays = true;

      
       
       
       
        return RedirectToAction(nameof(Upsert),new {id=certSlotVM.CertificationSlot.Id });

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
