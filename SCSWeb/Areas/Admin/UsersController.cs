using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;
using SCS.Utility;
using System.Net;

namespace SCS.Areas.Admin
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            // Show only users that have logged - PM 
            
            return View();
        }

        public IActionResult Edit(string userId)
        {
            var appUser = _unitOfWork.AppUser.Get(u => u.Id == userId, includeProperties: "Address");
            UserVM userVM = new UserVM
            {
                AppUser = appUser,
                RoleList = _roleManager.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Name
                }),
            };

            userVM.AppUser.Role = _userManager.GetRolesAsync(_unitOfWork.AppUser
                    .Get(u => u.Id == userId))
                    .GetAwaiter().GetResult().FirstOrDefault();

            return View(userVM);
        }

        [HttpPost]
        public IActionResult Edit(UserVM userVM)
        {
            // Update Role
            string oldRole = _userManager.GetRolesAsync(_unitOfWork.AppUser
                    .Get(u => u.Id == userVM.AppUser.Id))
                    .GetAwaiter().GetResult().FirstOrDefault();

            AppUser appUser = _unitOfWork.AppUser
                .Get(u => u.Id == userVM.AppUser.Id, includeProperties: "Address", true);

            // Update Address first ---------------------
            var address = _unitOfWork.Address.Get(a => a.Id == appUser.AddressId, null, true);
            
            // New registered User has no Address. 
            if (address == null)
                address = new Address();
            
            // Need this otherwise updates Address.Id on Existing User.Address
            address.Street1 = userVM.AppUser.Address.Street1;
            address.Street2 = userVM.AppUser.Address.Street2;
            address.City = userVM.AppUser.Address.City;
            address.State = userVM.AppUser.Address.State;
            address.Postcode = userVM.AppUser.Address.Postcode;
            address.Country = userVM.AppUser.Address.Country;

            _unitOfWork.Address.Update(address);
            _unitOfWork.Save(); // Need to save changes in case of a new Address.Id

            if (appUser.AddressId == null)
            {
                // Saves new AddressId to new user
                appUser.AddressId = address.Id;
            }

            // Update Role
            if (userVM.AppUser.Role != oldRole)
            {
                if ( oldRole != null)
                {
                    _userManager.RemoveFromRoleAsync(appUser, oldRole).GetAwaiter().GetResult();
                }
                _userManager.AddToRoleAsync(appUser, userVM.AppUser.Role).GetAwaiter().GetResult();
            }
            _unitOfWork.AppUser.Update(appUser);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        // --------------------------------------------------

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            
            List<AppUser> objUserList = _unitOfWork.AppUser.GetAll(u => u.NormalizedEmail != null).ToList();
            //List<AppUser> objUserList = _unitOfWork.AppUser.GetAll().ToList(); - Original showing all users - PM
            // Using AspNetUserRoles and AspNetRoles tables
            // - excluding the AspNet from the table name for all Identity tables works  

            foreach (var user in objUserList)
            {
                // Don't show temp/ not logged  users 
                user.Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();
            }
            return Json(new { data = objUserList });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var objFromDb = _unitOfWork.AppUser.Get(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error Locking/Unlocking" });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now) // User is Locked 
            {
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }

            _unitOfWork.AppUser.Update(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Operation Successful" });
        }

        #endregion
    }
}