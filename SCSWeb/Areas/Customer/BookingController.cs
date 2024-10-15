using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;
using SCS.Utility;
using System.Globalization;

namespace SCSWeb.Areas.Customer
{
    [Area("Customer")]

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

        [AllowAnonymous]
        public async Task<IActionResult> Calendar()
        {
            var calendar = new GregorianCalendar();
            return View(calendar);
        }

        [Authorize]
        public IActionResult Index()
        {
            BookingVM BookingVM = new BookingVM();

            return View(BookingVM);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Validate(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                OrderDetails orderDetail = _unitOfWork.OrderDetails
                    .Get(p => p.VoucherKey == search);

                if (orderDetail == null)
                {
                    TempData["error"] = "This Voucher Key is not valid.";
                    return RedirectToAction("Index");
                }
                else
                {
                    if (orderDetail.BookCount == orderDetail.Count)
                    {
                        TempData["error"] = "This Voucher has already been Used/Booked.";
                        return RedirectToAction("Index");
                    }
                    else // Hasn't been booked yet 
                    {
                        BookingVM.VoucherId = orderDetail.VoucherKey;

                        HttpContext.Session.SetString(SD.SessionVoucherId, orderDetail.VoucherKey);

                        TempData["success"] = "Voucher key Validated.";
                        return RedirectToAction("BookDate");
                    }
                }
            }
            else
            {
                //ViewBag.Message = "Please enter a Valid Voucher Key."; Don't get why this is not working... ????
                TempData["error"] = "Please enter a Valid Voucher Key.";
                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public async Task<IActionResult> BookDate()
        {
            string voucherId = HttpContext.Session.GetString(SD.SessionVoucherId);

            IEnumerable<CertificationSlot> slots = _unitOfWork.CertificationSlot.GetAll();

            OrderDetails order = _unitOfWork.OrderDetails.Get(o => o.VoucherKey == voucherId, includeProperties: "Product");
            IEnumerable<CertificationDay> cDayList = await _unitOfWork.CertificationDay
                .GetAllAsync(x => x.IsCertDay == true && x.Date > DateOnly.FromDateTime(DateTime.Now)
                    , includeProperties: "CertificationSlot");

            BookingVM BookingVM = new BookingVM
            {
                VoucherId = voucherId,
                OrderDetails = order,
                Slots = slots,
                CDayList = cDayList,
            };

            // Cleaning session as it was creating too many cookies
            // Will move that down when confirmation is done. - PM
            // HttpContext.Session.Clear()
            return View(BookingVM);
        }

		public IActionResult Summary(DateOnly bDate)
		{
            var userId = HttpContext.User.GetUserId();

            string voucherId = HttpContext.Session.GetString(SD.SessionVoucherId);
			OrderDetails order = _unitOfWork.OrderDetails.Get(o => o.VoucherKey == voucherId, includeProperties: "Product");
			AppUser user = _unitOfWork.AppUser.Get(x => x.Id == userId);
            
            // Save new Booking 
            BookingVM BookingVM = new BookingVM
            {
                VoucherId = voucherId,
                Date = bDate,
                AppUserId = userId,
                AppUser = user,
                OrderDetails = order
            };

            //HttpContext.Session.CommitAsync()
            return View(BookingVM); // Add Summary
		}

		[Authorize]
        [HttpPost]
        [ActionName("Summary")]
        public async Task<IActionResult> SummaryPOST(BookingVM BookingVM)
        {
            var userId = HttpContext.User.GetUserId();

            string voucherId = HttpContext.Session.GetString(SD.SessionVoucherId);

            OrderDetails order = _unitOfWork.OrderDetails.Get(o => o.VoucherKey == voucherId, includeProperties: "Product");
            order.BookCount += 1; // Increase Booking Count 

            // Save new Booking 
            Booking booking = new Booking
            {
                VoucherKey = BookingVM.VoucherId,
                Date       = BookingVM.Date,
                AppUserId  = userId
			};

            _unitOfWork.Booking.Add(booking);

            // Update BookCount in OrderDetails 
            _unitOfWork.OrderDetails.Update(order);

            _unitOfWork.Save();

            // Sends Email Confirmation 
            Booking bookEmail = _unitOfWork.Booking.Get(x => x.VoucherKey == voucherId);
			AppUser AppUser = _unitOfWork.AppUser.Get(x => x.Id == userId);

			string emailHeader =
				  $"<p>Booking Id  : {bookEmail.Id}</p>"
				+ $"<p>Date        : {bookEmail.Date}</P>"
				+ $"<p>Name        : {AppUser.Name}</P>"
				+ $"<p>Email       : {AppUser.Email}</P>"
				+ $"<p>Voucher Key : {bookEmail.VoucherKey}</P>"
				+ $"<p>Product     : {order.Product.Name}</P>";
			
            _emailSender.SendEmailAsync(AppUser.Email, "Booking Confirmed - SCS AB", emailHeader);

			HttpContext.Session.Clear();

			TempData["success"] = "Booking Confirmed";

			return RedirectToAction("Index", "Home");
		}

   //     [Authorize]
   //     public IActionResult Confirmation(int id)
   //     {
   //         Booking booking = _unitOfWork.Booking.Get(x => x.Id == id);
   //         AppUser AppUser = _unitOfWork.AppUser.Get(x => x.Id == booking.AppUserId);
			//string voucherId = HttpContext.Session.GetString(SD.SessionVoucherId);
			//OrderDetails order = _unitOfWork.OrderDetails.Get(x => x.VoucherKey == voucherId, includeProperties: "Product");

   //         string emailHeader =
   //               $"<p>Booking     : {id}</p>"
   //             + $"<p>Date        : {booking.Date}</P>"
   //             + $"<p>Name        : {AppUser.Name}</P>"
   //             + $"<p>Email       : {AppUser.Email}</P>"
   //             + $"<p>Voucher Key : {booking.VoucherKey}</P>"
   //             + $"<p>Product     : {order.Product.Name}</P>";

   //         //string emailDetails = "";

   //         //foreach (var item in orderDetails)
   //         //{
   //         //    emailDetails +=
   //         //        $"<p>Product : {item.Product.Name}</p>"
   //         //        + $"<p>Count : {item.Count}</p>"
   //         //        + $"<p>Price : {item.Product.Price}</p>"
   //         //        + $"<p>Voucher Key : {item.VoucherKey}</p>"
   //         //        + $"<p> ------------------------------------------------------------------------------------------------------------------</p>";
   //         //}

   //         _emailSender.SendEmailAsync(AppUser.Email, "Booking Confirmed - SCS AB", emailHeader);

   //         return View(id);
   //     }
    }
}

