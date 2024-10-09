using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;

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

        public async Task<IActionResult> Calendar()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            ViewBag.Message = "";
            BookingVM bookingVM = new BookingVM();
                        
            IEnumerable<CertificationSlot> slots = _unitOfWork.CertificationSlot.GetAll();
            
            bookingVM.VoucherId = "";
            bookingVM.Slots = slots;
            return View(bookingVM);
        }

        public IActionResult CheckVoucher(BookingVM bookingVM)
        {
            if (!String.IsNullOrEmpty(bookingVM.VoucherId))
            {
                OrderDetails orderDetail = _unitOfWork.OrderDetails
                    .Get(p => p.VoucherKey == bookingVM.VoucherId);

                if (orderDetail == null)
                    ViewBag.Message = "This Voucher Key is not valid.";
                else
                {
                    if (orderDetail.VoucherBooked == true)
                        ViewBag.Message = "This Voucher has already been Used/Booked.";
                    else
                    {
                        bookingVM.VoucherId = orderDetail.VoucherKey;
                        ViewBag.Message = "Voucher key Validated.";
                    }
                }
            }
            else
            {
                ViewBag.Message = "";
            }
            return View("Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Book(BookingVM bookingVM)
        {
            var voucher = _unitOfWork.OrderDetails.Get(v => v.VoucherKey == BookingVM.VoucherId);
            if (voucher != null)
            {
                voucher.VoucherBooked = true;
                _unitOfWork.OrderDetails.Update(voucher);
                _unitOfWork.Save();
                ViewBag.Message = "Voucher has been Booked.";
                return RedirectToAction(nameof(OrderConfirmation), new { id = BookingVM.VoucherId });
            }
            return RedirectToAction("OrderConfirmation");
        }

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

