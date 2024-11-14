using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;
using SCS.Utility;

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
            IEnumerable<AppUser> users = await _unitOfWork.AppUser.GetAllAsync(includeProperties: "Address");
            IEnumerable<Product> products = await _unitOfWork.Product.GetAllAsync(includeProperties: "Category");
            IEnumerable<OrderHeader> orders = await _unitOfWork.OrderHeader.GetAllAsync();
            IEnumerable<Booking> bookings = await _unitOfWork.Booking.GetAllAsync();

            DashboardVM dashboardVM = new DashboardVM()
            {
                Users = users,
                Products = products,
                Orders = orders,
                Bookings = bookings
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
