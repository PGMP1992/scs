using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;
using SCS.Utility;

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
            var slots = await _unitOfWork.CertificationDay.GetAllAsync(x => x.IsCertDay == true, includeProperties: "CertificationSlot");

            foreach (var item in slots)
            {
                CalendarData temp = new CalendarData
                {
                    id = item.Id,
                    title = item.CertificationSlot.Name,
                    start = item.Date,
                    //end = item.EndDate
                };
                calendarData.Add(temp);
            }

            ViewData["Events"] = JSONListHelper.GetEventListJSONString(calendarData);
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Voucher()
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
                OrderHeader orderHeader = _unitOfWork.OrderHeader
                    .Get(p => p.Id == orderDetail.OrderHeaderId);

                if (orderDetail == null)
                {
                    TempData["error"] = "This Voucher Key is not valid.";
                    return RedirectToAction("Voucher");
                }
                else
                {
                    if (orderDetail.BookCount == orderDetail.Count)
                    {
                        TempData["error"] = "This Voucher has already been Used/Booked.";
                        return RedirectToAction("Voucher");
                    }

                    else if (orderHeader.PaymentStatus != SD.PaymentStatusApproved)
                    {
                        TempData["error"] = "Order Payment has not been approved yet.";
                        return RedirectToAction("Voucher");
                    }

                    else // Hasn't been booked yet and there are dates available
                    {
                        BookingVM.VoucherId = orderDetail.VoucherKey;

                        HttpContext.Session.SetString(SD.SessionVoucherId, orderDetail.VoucherKey);
                        //TempData["success"] = "Voucher key Validated.";
                        return RedirectToAction("BookDate");
                    }
                }
            }
            else
            {
                TempData["error"] = "Please enter a Valid Voucher Key.";
                return RedirectToAction("Voucher");
            }
        }

        [Authorize]
        public async Task<IActionResult> BookDate()
        {
            string voucherId = HttpContext.Session.GetString(SD.SessionVoucherId);

            IEnumerable<CertificationSlot> slots = await _unitOfWork.CertificationSlot.GetAllAsync();

            OrderDetails order = _unitOfWork.OrderDetails.Get(o => o.VoucherKey == voucherId, includeProperties: "Product");

            List<CertificationDay> cDayList = (List<CertificationDay>)_unitOfWork.CertificationDay
                .GetAll(x => x.IsCertDay == true
                    && x.Date >= DateOnly.FromDateTime(DateTime.Now)
                    && x.CertSlotId == order.Product.CertSlotId
                    , includeProperties: "CertificationSlot");

            if (!cDayList.Any())
            {
                TempData["error"] = "There are no Dates available for this Certification";
                return RedirectToAction("Voucher");
            }

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
                Date = BookingVM.BookDate,
                AppUserId = userId,
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
                + $"<p>-------------------------------------------------</p>"
                + $"<p>Voucher Key : {bookEmail.VoucherKey}</P>"
                + $"<p>Product     : {order.Product.Name}</p>";

            _emailSender.SendEmailAsync(AppUser.Email, "Booking Confirmed - SCS AB", emailHeader);

            HttpContext.Session.Clear();

            TempData["success"] = "Booking Confirmed. Check your Email App for confirmation.";

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> BookingList()
        {
            var userId = HttpContext.User.GetUserId();
            IEnumerable<Booking> bookings;

            //AppUser AppUser = await _unitOfWork.AppUser.GetAsync(x => x.Id == userId);

            if (User.IsInRole(SD.Role_Admin))
            {
                bookings = await _unitOfWork.Booking.GetAllAsync(includeProperties: "AppUser");
            }
            else
            {
                bookings = await _unitOfWork.Booking.GetAllAsync(x => x.AppUserId == userId, includeProperties: "AppUser,");
            }

            if (!bookings.Any())
            {
                TempData["error"] = "There are no Bookings";
                return RedirectToAction("Index", "Home");
            }
            else
                return View(bookings);
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var userId = HttpContext.User.GetUserId();
            Booking booking = _unitOfWork.Booking.Get(x => x.Id == id);
            var voucherKey = booking.VoucherKey;
            var date = booking.Date;
            OrderDetails order = await _unitOfWork.OrderDetails.GetAsync(x => x.VoucherKey == voucherKey, includeProperties: "Product");
            AppUser user = _unitOfWork.AppUser.Get(x => x.Id == booking.AppUserId);

            BookingVM bookingVM = new BookingVM
            {
                VoucherId = voucherKey,
                AppUser = user,
                OrderDetails = order,
                BookDate = date
            };

            return View(bookingVM);
        }
    }
}