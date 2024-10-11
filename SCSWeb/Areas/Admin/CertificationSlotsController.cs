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

    public CertificationSlotsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<CertificationSlot> cerSlotList =(_unitOfWork.CertificationSlot.GetAll(includeProperties: "CertificationDays"));

        return View(cerSlotList);
    }

    public IActionResult Upsert(int? id)
    {
        CertificationSlotVM certSlotVM = new CertificationSlotVM()
        {
            CertificationSlot = new CertificationSlot(),
        };

        if (id != null && id > 0)
        {
            certSlotVM.CertificationSlot = _unitOfWork.CertificationSlot.Get(u => u.Id == id,includeProperties:"CertificationDays");
            List<CertificationDay> CList = new List<CertificationDay>();
           
            if(certSlotVM.CertificationSlot.CertificationDays.Count() > 0)
            {
                certSlotVM.CertificationSlot.CertificationDays.OrderBy(u=>u.Date);
                CList = certSlotVM.CertificationSlot.CertificationDays.ToList();
            }
            
            if (certSlotVM.CertificationSlot.EndDate > certSlotVM.CertificationSlot.StartDate)
            {
                certSlotVM.CertificationSlot.ShowDays = true;
            }
            certSlotVM.CDayList = CList;
        }

        return View(certSlotVM);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert(CertificationSlotVM certSlotVM)
    {
        CertificationSlotVM certSlotVMTest = certSlotVM;
        CertificationSlot certSlotFromDb = _unitOfWork.CertificationSlot.Get(u => u.Id == certSlotVM.CertificationSlot.Id);
      
        if (ModelState.IsValid )
        {
            if (certSlotVM.CertificationSlot.Id == 0)
            {
                await _unitOfWork.CertificationSlot.AddAsync(certSlotVM.CertificationSlot);
            }
            else
            {
                if( certSlotVM.CDayList != null)
                {
                    foreach (var item in certSlotVM.CDayList)
                    {
                        CertificationDay cday = await _unitOfWork.CertificationDay.GetAsync(u => u.Id == item.Id);
                       
                        cday.IsCertDay = item.IsCertDay;
                        await _unitOfWork.CertificationDay.UpdateAsync(cday);
                    }
                }

                await _unitOfWork.SaveAsync();
                certSlotVM.CertificationSlot.CertificationDays = _unitOfWork.CertificationDay
                        .GetAll(u => u.CertSlotId == certSlotVM.CertificationSlot.Id);
            }

            if (certSlotVM.CertificationSlot.CertificationDays is not null)
            {
                certSlotVM.CertificationSlot.Dates = new List<DateOnly>();
                foreach (var item in certSlotVM.CertificationSlot.CertificationDays)
                {
                    if (item.IsCertDay)
                    {
                        certSlotVM.CertificationSlot.Dates.Add(item.Date);
                    }
                }
                await _unitOfWork.CertificationSlot.UpdateAsync(certSlotVM.CertificationSlot);
            }

            await  _unitOfWork.SaveAsync();

            if(certSlotVM.CertificationSlot.StartDate != certSlotFromDb.StartDate 
                || certSlotVM.CertificationSlot.EndDate != certSlotFromDb.EndDate)
            {
                await  _unitOfWork.CertificationDay.UpdateCertDayListAsync(certSlotVM.CertificationSlot);
            }

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
        DateOnly newDate = certSlotVM.CertificationSlot.StartDate.AddDays(-1);
        
        CertificationDay certDay= new CertificationDay();
        List<CertificationDay> days= new List<CertificationDay>();
        
        for (int i = 0; i<intervall.Days+1;i++)
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
        certSlotVM.CertificationSlot.ShowDays = true;
       
        return RedirectToAction(nameof(Upsert),new {id=certSlotVM.CertificationSlot.Id });
    }

    [HttpPost]
    public IActionResult UpdateList(List<CertificationDay> CDayList)
    {
        if (CDayList != null)
        {
            foreach (var item in CDayList)
            {
            }
        }
        return View();
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
