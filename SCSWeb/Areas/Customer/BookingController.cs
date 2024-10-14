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
                        BookingVM.VoucherValidated = true;
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
        public IActionResult BookDate()
        {
            string voucherId = HttpContext.Session.GetString(SD.SessionVoucherId);

            IEnumerable<CertificationSlot> slots = _unitOfWork.CertificationSlot.GetAll();

            OrderDetails order = _unitOfWork.OrderDetails.Get(o => o.VoucherKey == voucherId, includeProperties: "Product");
            IEnumerable<CertificationDay> cDayList = _unitOfWork.CertificationDay
                .GetAll(x => x.IsCertDay == true, includeProperties: "CertificationSlot");

            BookingVM BookingVM = new BookingVM
            {
                VoucherId = voucherId,
                VoucherValidated = true,
                OrderDetails = order,
                Slots = slots,
                CDayList = cDayList
            };

            // Cleaning session as it was creating too many cookies
            // Will move that down when confirmation is done. - PM
            
            return View(BookingVM);
        }

		public IActionResult Summary(DateOnly bookingDate)
		{
            var userId = HttpContext.User.GetUserId();

            string voucherId = HttpContext.Session.GetString(SD.SessionVoucherId);

            // Save new Booking 
            Booking booking = new Booking
            {
                VoucherKey = voucherId,
                Date = bookingDate,
                AppUserId = userId
            };

            return View(booking); // Add Summary
		}

		//[Authorize]
  //      [HttpPost]
  //      [ActionName("Summary")]
  //      public async Task<IActionResult> SummaryPOST(DateTime bookingDate)
  //      {
  //          var userId = HttpContext.User.GetUserId();

  //          string voucherId = HttpContext.Session.GetString(SD.SessionVoucherId);

  //          OrderDetails order = _unitOfWork.OrderDetails.Get(o => o.VoucherKey == voucherId, includeProperties: "Product");
  //          order.BookCount += 1; // Increase BookCount 

  //          // Save new Booking 
  //          Booking booking = new Booking
  //          {
  //              VoucherKey = voucherId,
  //              Date = bookingDate,
  //              AppUserId = userId
  //          };

  //          _unitOfWork.Booking.Add(booking);
            
  //          // Update BookCount in OrderDetails 
  //          _unitOfWork.OrderDetails.Update(order);
            
  //          _unitOfWork.Save();

  //          HttpContext.Session.Clear();
  //          return View(); // Add Summary
  //      }

  //      public IActionResult Summary()
  //      {
  //          var userId = HttpContext.User.GetUserId();

            
  //          return View();
  //      }

        [Authorize]
        public IActionResult OrderConfirmation(string id)
        {
            //string emailHeader =
            //      $"<p>New Order Number :{orderHeader.Id}</p>"
            //    + $"<p>Date  : {orderHeader.OrderDate}</P>"
            //    + $"<p>Status: {orderHeader.OrderStatus}</P>"
            //    + $"<p>Total : {orderHeader.OrderTotal}</P>"
            //    + $"<p> ------------------------------------------------------------------------------------------------------------------</p>";

            //string emailDetails = "";

            //foreach (var item in orderDetails)
            //{
            //    emailDetails +=
            //        $"<p>Product : {item.Product.Name}</p>"
            //        + $"<p>Count : {item.Count}</p>"
            //        + $"<p>Price : {item.Product.Price}</p>"
            //        + $"<p>Voucher Key : {item.VoucherKey}</p>"
            //        + $"<p> ------------------------------------------------------------------------------------------------------------------</p>";
            //}

            //_emailSender.SendEmailAsync(orderHeader.AppUser.Email, "New Order - SCS AB", emailHeader + emailDetails);

            return View(id);
        }
    }
}

