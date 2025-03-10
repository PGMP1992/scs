using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;
using SCS.Utility;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SCSWeb.Areas.Admin
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Dashboard
        public async Task<ActionResult> Index()
        {
            IEnumerable<AppUser> users = await _unitOfWork.AppUser.GetAllAsync(x => x.AddressId != null && x.Email != SD.AdminEmail, includeProperties: "Address");
            var usersByCountry = users.GroupBy(x => x.Address.Country);

            IEnumerable<Product> products = await _unitOfWork.Product.GetAllAsync(includeProperties: "Category");
            var productByCategory = products.GroupBy(x => x.Category);

            IEnumerable<OrderHeader> orders = await _unitOfWork.OrderHeader.GetAllAsync();
            var orderByStatus = orders.GroupBy(x => x.OrderStatus ?? string.Empty);

            IEnumerable<Booking> bookings = await _unitOfWork.Booking.GetAllAsync(includeProperties: "AppUser");
            // Update the grouping to handle nullable strings
            var bookingByUser = bookings.GroupBy(x => x.AppUser.Name ?? string.Empty);

            DashboardVM dashboardVM = new DashboardVM()
            {
                Users = usersByCountry,
                Products = productByCategory,
                Orders = orderByStatus,
                Bookings = bookingByUser
            };
            return View(dashboardVM);
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
