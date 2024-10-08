using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SCS.Models;
using SCS.Repository.IRepository;
using SCS.Utility;

namespace SCS.Areas.Customer
{
    [Area("Customer")]
    [Authorize]

    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Profile()
        {
            var userId = HttpContext.User.GetUserId();

            var appUser = _unitOfWork.AppUser.Get(u => u.Id == userId, includeProperties: "Address");

            return View(appUser);
        }

        [HttpPost]
        public IActionResult Profile(AppUser user)
        {
            AppUser appUser = _unitOfWork.AppUser
                .Get(u => u.Id == user.Id, includeProperties: "Address", true);

            // Update Address first ---------------------
            var address = _unitOfWork.Address.Get(a => a.Id == appUser.AddressId, null, true);

            // New registered User has no Address. 
            if (address == null)
                address = new Address();

            // Need this otherwise updates Address.Id on Existing User.Address
            address.Street1 = user.Address.Street1;
            address.Street2 = user.Address.Street2;
            address.City = user.Address.City;
            address.State = user.Address.State;
            address.Postcode = user.Address.Postcode;
            address.Country = user.Address.Country;

            _unitOfWork.Address.Update(address);
            _unitOfWork.Save(); // Need to save changes in case of a new Address.Id

            if (appUser.AddressId == null)
            {
                // Saves new AddressId to new user
                appUser.AddressId = address.Id;
            }
            appUser.Name = user.Name;

            _unitOfWork.AppUser.Update(appUser);
            _unitOfWork.Save();
            TempData["success"] = "Profile Updated";

            return RedirectToAction("Index","Home");
        }
    }
}