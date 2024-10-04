using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SCS.Models.ViewModels;
using SCS.Models;
using SCS.Repository.IRepository;
using SCS.Utility;

namespace SCSWeb.Areas.Customer
{
    [Area("Customer")]
    [Authorize]
    
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;

        [BindProperty]
        public BookingVM BookingVM { get; set; } //Used to pass BookingVM between methods - PM

        public BookingController(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.User.GetUserId();

            IEnumerable<Product> products = _unitOfWork.Product.GetAll(p=>p.VoucherKey != null );
                      
            return View(products);
        }

        public IActionResult Book()
        {
            var userId = HttpContext.User.GetUserId();

            //BookingVM = new BookingVM()
            //{
            //    BookingList = _unitOfWork.Booking.GetAll(u => u.AppUserId == userId,
            //        includeProperties: "Product"),
            //    OrderHeader = new()
            //};

            //BookingVM.OrderHeader.Name = _unitOfWork.AppUser.GetName(userId);
            //BookingVM.OrderHeader.Email = _unitOfWork.AppUser.GetEmail(userId);

            //foreach (var Booking in BookingVM.BookingList)
            //{
            //    Booking.Price = Booking.Product.Price * Booking.ProdCount;
            //    BookingVM.OrderHeader.OrderTotal += Booking.Price;
            //}
            return View(BookingVM);
        }

        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()
        {
            var userId = HttpContext.User.GetUserId();

            BookingVM.BookingList = _unitOfWork.Booking.GetAll(u => u.AppUserId == userId,
                includeProperties: "Product");

            //BookingVM.OrderHeader.OrderDate = System.DateTime.Now;
            //BookingVM.OrderHeader.AppUserId = userId;
            //BookingVM.OrderHeader.Name = _unitOfWork.AppUser.GetName(userId);
            //BookingVM.OrderHeader.Email = _unitOfWork.AppUser.GetEmail(userId);

            //foreach (var Booking in BookingVM.BookingList)
            //{
            //    Booking.Price = Booking.Product.Price * Booking.ProdCount;
            //    BookingVM.OrderHeader.OrderTotal += Booking.Price;
            //}

            //BookingVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
            //BookingVM.OrderHeader.OrderStatus = SD.StatusPending;

            //_unitOfWork.OrderHeader.Add(BookingVM.OrderHeader);
            _unitOfWork.Save(); // ???? 

            foreach (var Booking in BookingVM.BookingList)
            {
                //var orderDetail = new OrderDetails()
                //{
                //    ProductId = Booking.ProductId,
                //    OrderHeaderId = BookingVM.OrderHeader.Id,
                //    Price = Booking.Price,
                //    Count = Booking.ProdCount
                //};
                //_unitOfWork.OrderDetails.Add(orderDetail);
                _unitOfWork.Save(); // ??? 
            }

            _unitOfWork.Save();

            return RedirectToAction(nameof(OrderConfirmation), new { id = BookingVM.OrderHeader.Id });
        }

        public IActionResult OrderConfirmation(int id)
        {
            //OrderHeader orderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == id, includeProperties: "AppUser");
            ////OrderDetails orderDetails = _unitOfWork.OrderDetails.Get(u => u.OrderHeaderId == id, includeProperties: "OrderHeader,Product");

            //_emailSender.SendEmailAsync(orderHeader.AppUser.Email, "New Order - SCS AB",
            //    $"<p>New Order Created - {orderHeader.Id}</p>"
            //    + $"<p>Date: {orderHeader.OrderDate}</P>"
            //    + $"<p>Status: {orderHeader.OrderStatus}</P>"
            //    + $"<p>Total: {orderHeader.OrderTotal}</P>"
            //    //$"<p> ------------------------------------------</p>" 
            //    //$"<p> Product : {orderDetails.Product.Name}</P>" 
            //    //$"<p> Quantity: {orderDetails.Count}</P>" 
            //    //$"<p> Price   : {orderDetails.Product.Price.ToString("c")}
            //    );

            //// Remove the Bookings from DB 
            //List<Booking> Bookings = _unitOfWork.Booking
            //    .GetAll(u => u.AppUserId == orderHeader.AppUserId).ToList();

            //_unitOfWork.Booking.RemoveRange(Bookings);
            //_unitOfWork.Save();

            return View(id);
        }

        public IActionResult Remove(int BookingId)
        {
            //var BookingFromDb = _unitOfWork.Booking.Get(u => u.Id == BookingId, tracked: true);
            //HttpContext.Session.SetInt32(SD.SessionBooking, _unitOfWork.Booking
            //  .GetAll(u => u.AppUserId == BookingFromDb.AppUserId).Count() - 1);
            //_unitOfWork.Booking.Remove(BookingFromDb);
            //_unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
