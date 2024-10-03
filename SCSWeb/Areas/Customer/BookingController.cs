using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;
using SCS.Utility;
using Stripe.Checkout;

namespace SCSWeb.Areas.Customer
{
    [Area("Customer")]
    [Authorize]

    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        
        [BindProperty]
        public BookingVM BookingVM { get; set; } //Used to pass CartVM between methods - PM

        public BookingController(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.User.GetUserId();

            var BookingVM = new BookingVM()
            {
                BookingList = _unitOfWork.Booking.GetAll(u => u.AppUserId == userId,
                                includeProperties: "Product"),
                OrderHeader = new()
            };

            IEnumerable<ProductImage> productImages = _unitOfWork.ProductImage.GetAll();

            foreach (var Booking in BookingVM.BookingList)
            {
                Booking.Product.ProductImages = productImages.Where(u => u.ProductId == Booking.Product.Id).ToList();
                Booking.Price = Booking.Product.Price * Booking.ProdCount;
                BookingVM.OrderHeader.OrderTotal += Booking.Price;
            }
            return View(BookingVM);
        }

        public IActionResult Summary()
        {
            var userId = HttpContext.User.GetUserId();

            BookingVM = new BookingVM()
            {
                BookingList = _unitOfWork.Booking.GetAll(u => u.AppUserId == userId,
                    includeProperties: "Product"),
                OrderHeader = new()
            };

            BookingVM.OrderHeader.Name = _unitOfWork.AppUser.GetName(userId);
            BookingVM.OrderHeader.Email = _unitOfWork.AppUser.GetEmail(userId);

            foreach (var Booking in BookingVM.BookingList)
            {
                Booking.Price = Booking.Product.Price * Booking.ProdCount;
                BookingVM.OrderHeader.OrderTotal += Booking.Price;
            }
            return View(BookingVM);
        }

        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()
        {
            var userId = HttpContext.User.GetUserId();

            BookingVM.BookingList = _unitOfWork.Booking.GetAll(u => u.AppUserId == userId,
                includeProperties: "Product");

            BookingVM.OrderHeader.OrderDate = System.DateTime.Now;
            BookingVM.OrderHeader.AppUserId = userId;
            BookingVM.OrderHeader.Name = _unitOfWork.AppUser.GetName(userId);
            BookingVM.OrderHeader.Email = _unitOfWork.AppUser.GetEmail(userId);

            foreach (var Booking in BookingVM.BookingList)
            {
                Booking.Price = Booking.Product.Price * Booking.ProdCount;
                BookingVM.OrderHeader.OrderTotal += Booking.Price;
            }

            BookingVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
            BookingVM.OrderHeader.OrderStatus = SD.StatusPending;

            _unitOfWork.OrderHeader.Add(BookingVM.OrderHeader);
            _unitOfWork.Save(); // ???? 

            foreach (var Booking in BookingVM.BookingList)
            {
                var orderDetail = new OrderDetails()
                {
                    ProductId = Booking.ProductId,
                    OrderHeaderId = BookingVM.OrderHeader.Id,
                    Price = Booking.Price,
                    Count = Booking.ProdCount
                };
                _unitOfWork.OrderDetails.Add(orderDetail);
                _unitOfWork.Save(); // ??? 
            }

            //Stripe logic ------------------------------------------------
            var domain = Request.Scheme + "://" + Request.Host.Value + "/";
            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + $"customer/Booking/OrderConfirmation?id={BookingVM.OrderHeader.Id}",
                CancelUrl = domain + "customer/Booking/summary",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
            };

            foreach (var Booking in BookingVM.BookingList)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(Booking.Product.Price * 100), // $20.50 => 2050
                        Currency = "sek",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = Booking.Product.Name
                        }
                    },
                    Quantity = Booking.ProdCount
                };
                options.LineItems.Add(sessionLineItem);
            }

            var service = new SessionService();
            Session session = service.Create(options);
            _unitOfWork.OrderHeader.UpdateStripePaymentID(BookingVM.OrderHeader.Id, session.Id, session.PaymentIntentId);
            _unitOfWork.Save();

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
            //return RedirectToAction(nameof(OrderConfirmation), new { id = BookingVM.OrderHeader.Id });
        }

        public IActionResult OrderConfirmation(int id)
        {
            OrderHeader orderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == id, includeProperties: "AppUser");
            //OrderDetails orderDetails = _unitOfWork.OrderDetails.Get(u => u.OrderHeaderId == id, includeProperties: "OrderHeader,Product");
            var service = new SessionService();
            Session session = service.Get(orderHeader.SessionId);

            if (session.PaymentStatus.ToLower() == "paid")
            {
                _unitOfWork.OrderHeader.UpdateStripePaymentID(id, session.Id, session.PaymentIntentId);
                _unitOfWork.OrderHeader.UpdateStatus(id, SD.StatusApproved, SD.PaymentStatusApproved);
                _unitOfWork.Save();
            }
            HttpContext.Session.Clear();

            _emailSender.SendEmailAsync(orderHeader.AppUser.Email, "New Order - SCS AB",
                $"<p>New Order Created - {orderHeader.Id}</p>"
                + $"<p>Date: {orderHeader.OrderDate}</P>"
                + $"<p>Status: {orderHeader.OrderStatus}</P>"
                + $"<p>Total: {orderHeader.OrderTotal}</P>"
                //$"<p> ------------------------------------------</p>" 
                //$"<p> Product : {orderDetails.Product.Name}</P>" 
                //$"<p> Quantity: {orderDetails.Count}</P>" 
                //$"<p> Price   : {orderDetails.Product.Price.ToString("c")}
                );

            // Remove the Bookings from DB 
            List<Booking> Bookings = _unitOfWork.Booking
                .GetAll(u => u.AppUserId == orderHeader.AppUserId).ToList();

            _unitOfWork.Booking.RemoveRange(Bookings);
            _unitOfWork.Save();

            return View(id);
        }

        public IActionResult Plus(int BookingId)
        {
            var BookingFromDb = _unitOfWork.Booking.Get(u => u.Id == BookingId);
            BookingFromDb.ProdCount += 1;
            _unitOfWork.Booking.Update(BookingFromDb);
            _unitOfWork.Save();
            HttpContext.Session.SetInt32(SD.SessionBooking,
                _unitOfWork.Booking.GetAll(u => u.AppUserId == BookingFromDb.AppUserId).Count());
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int BookingId)
        {
            var BookingFromDb = _unitOfWork.Booking.Get(u => u.Id == BookingId, tracked: true);
            if (BookingFromDb.ProdCount <= 1)
            {
                //remove that from Booking
                HttpContext.Session.SetInt32(SD.SessionBooking, _unitOfWork.Booking
                     .GetAll(u => u.AppUserId == BookingFromDb.AppUserId).Count() - 1);
                _unitOfWork.Booking.Remove(BookingFromDb);
            }
            else
            {
                BookingFromDb.ProdCount -= 1;
                _unitOfWork.Booking.Update(BookingFromDb);
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int BookingId)
        {
            var BookingFromDb = _unitOfWork.Booking.Get(u => u.Id == BookingId, tracked: true);
            HttpContext.Session.SetInt32(SD.SessionBooking, _unitOfWork.Booking
              .GetAll(u => u.AppUserId == BookingFromDb.AppUserId).Count() - 1);
            _unitOfWork.Booking.Remove(BookingFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
}
