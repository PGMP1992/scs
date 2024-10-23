using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;
using SCS.Utility;
using System.Globalization;
using System.Security.Claims;

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
            var calendarData = new List<CalendarData>();
            var slots = _unitOfWork.CertificationSlot.GetAll();
            
            foreach(var item in slots)
            {
                CalendarData temp = new CalendarData
                {
                    id = item.Id,
                    title = item.Name,
                    start = item.StartDate,
                    end = item.EndDate
                };
                calendarData.Add(temp);
            }
            
            ViewData["Events"] = JSONListHelper.GetEventListJSONString( calendarData);
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Index()
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

            IEnumerable<CertificationSlot> slots = await _unitOfWork.CertificationSlot.GetAllAsync();

            OrderDetails order = _unitOfWork.OrderDetails.Get(o => o.VoucherKey == voucherId, includeProperties: "Product");

            List<CertificationDay> cDayList =  (List<CertificationDay>)_unitOfWork.CertificationDay
                .GetAll(x => x.IsCertDay == true && x.Date >= DateOnly.FromDateTime(DateTime.Now));
				            //,includeProperties: "CertificationSlot");

            BookingVM BookingVM = new BookingVM
            {
                VoucherId = voucherId,
                OrderDetails = order,
                Slots = slots,
                CDayList = cDayList
            };

            return View(BookingVM);
        }

		public async Task<IActionResult> Summary(DateOnly bDate)
		{
            var userId = HttpContext.User.GetUserId();

            string voucherId = HttpContext.Session.GetString(SD.SessionVoucherId);
			OrderDetails order = await _unitOfWork.OrderDetails.GetAsync(o => o.VoucherKey == voucherId, includeProperties: "Product");
			AppUser user = _unitOfWork.AppUser.Get(x => x.Id == userId);
            
            // Save new Booking 
            BookingVM BookingVM = new BookingVM
            {
                VoucherId = voucherId,
                BookDate = bDate,
                AppUserId = userId,
                AppUser = user,
                OrderDetails = order
            };

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
                Date       = BookingVM.BookDate,
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
				+ $"<p>-------------------------------------------------</p>< br/>"
				+ $"<p>Voucher Key : {bookEmail.VoucherKey}</P>"
				+ $"<p>Product     : {order.Product.Name}</p>";
			
            _emailSender.SendEmailAsync(AppUser.Email, "Booking Confirmed - SCS AB", emailHeader);

			HttpContext.Session.Clear();

			TempData["success"] = "Booking Confirmed. Check your Email App for confirmation.";

			return RedirectToAction("Index", "Home");
		}
    }
}

