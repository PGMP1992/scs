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
            IEnumerable<AppUser> users = await _unitOfWork.AppUser.GetAllAsync(includeProperties: "Address");

            //IQueryable<AppUser> query = (IQueryable<AppUser>)_unitOfWork.AppUser.GetAll(includeProperties: "Address");
            //query = query.Include(p => p.Provider)
            //         .ThenInclude(provider => provider.Products)
            //         .ThenInclude(relatedProduct => relatedProduct.ProductImages)  // Include images for related products
            //         .Include(p => p.ProductImages);  // Include images for the main product

            var usersByCountry = users.GroupBy(x => x.Address.Country)
                .Select(x => new
                {
                   Country = x.Key,
                   Count = x.Count()
                }).ToList();


            IEnumerable<Product> products = await _unitOfWork.Product.GetAllAsync(includeProperties: "Category");
            IEnumerable<OrderHeader> orders = await _unitOfWork.OrderHeader.GetAllAsync();
            IEnumerable<Booking> bookings = await _unitOfWork.Booking.GetAllAsync();

            DashboardVM dashboardVM = new DashboardVM()
            {
                Users  = users,
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
