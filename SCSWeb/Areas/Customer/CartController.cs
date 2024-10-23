using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;
using SCS.Utility;
using Stripe.Checkout;

namespace SCS.Areas.Customer
{
	[Area("Customer")]
	[Authorize]

	public class CartController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IEmailSender _emailSender;

		[BindProperty]
		public CartVM CartVM { get; set; } //Used to pass CartVM between methods - PM

		public CartController(IUnitOfWork unitOfWork, IEmailSender emailSender)
		{
			_unitOfWork = unitOfWork;
			_emailSender = emailSender;
		}

		public async Task<IActionResult> Index()
		{
			var userId = HttpContext.User.GetUserId();

			var CartVM = new CartVM()
			{
				CartList = _unitOfWork.Cart.GetAll(u => u.AppUserId == userId,
								includeProperties: "Product"),
				OrderHeader = new()
			};

			IEnumerable<ProductImage> productImages = _unitOfWork.ProductImage.GetAll();

			foreach (var cart in CartVM.CartList)
			{
				cart.Product.ProductImages = productImages.Where(u => u.ProductId == cart.Product.Id).ToList();
				cart.Price = cart.Product.Price * cart.ProdCount;
				CartVM.OrderHeader.OrderTotal += cart.Price;
			}
			return View(CartVM);
		}

		public IActionResult Summary()
		{
			var userId = HttpContext.User.GetUserId();

			CartVM = new CartVM()
			{
				CartList = _unitOfWork.Cart.GetAll(u => u.AppUserId == userId,
					includeProperties: "Product"),
				OrderHeader = new()
			};

			CartVM.OrderHeader.Name = _unitOfWork.AppUser.GetName(userId);
            CartVM.OrderHeader.Email = _unitOfWork.AppUser.GetEmail(userId);

            foreach (var cart in CartVM.CartList)
			{
				cart.Price = cart.Product.Price * cart.ProdCount;
				CartVM.OrderHeader.OrderTotal += cart.Price;
			}
			return View(CartVM);
		}

		[HttpPost]
		[ActionName("Summary")]
		public IActionResult SummaryPOST()
		{
			var userId = HttpContext.User.GetUserId();

			CartVM.CartList = _unitOfWork.Cart.GetAll(u => u.AppUserId == userId,
				includeProperties: "Product");

			// Order Header -------------------------------------
			CartVM.OrderHeader.OrderDate = System.DateTime.Now;
			CartVM.OrderHeader.AppUserId = userId;
            CartVM.OrderHeader.Name = _unitOfWork.AppUser.GetName(userId);
            CartVM.OrderHeader.Email = _unitOfWork.AppUser.GetEmail(userId);

            foreach (var cart in CartVM.CartList)
			{
				cart.Price = cart.Product.Price * cart.ProdCount;
				CartVM.OrderHeader.OrderTotal += cart.Price;
			}

			CartVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
			CartVM.OrderHeader.OrderStatus = SD.StatusPending;

			_unitOfWork.OrderHeader.Add(CartVM.OrderHeader);
			_unitOfWork.Save(); // ???? 

            // Order Details -------------------------------------
            foreach (var cart in CartVM.CartList)
			{
                var orderDetail = new OrderDetails()
				{
					ProductId = cart.ProductId,
					OrderHeaderId = CartVM.OrderHeader.Id,
					Price = cart.Price,
					Count = cart.ProdCount,
					VoucherKey = Guid.NewGuid().ToString(), // Creates a new Voucher Key for the product 
                    // Sets BookCount to zero - Once a booking is done it updates this property
					// Depending on the Quantity/Count it books it uses the VoucherKey until BookCount = Count - PM
                    BookCount = 0 
                };
			
				_unitOfWork.OrderDetails.Add(orderDetail);
				_unitOfWork.Save(); // ??? 
			}

			//Stripe logic ------------------------------------------------
			
			var domain = Request.Scheme + "://" + Request.Host.Value + "/";
			var options = new SessionCreateOptions
			{
				SuccessUrl = domain + $"customer/cart/OrderConfirmation?id={CartVM.OrderHeader.Id}",
				CancelUrl = domain + "customer/cart/summary",
				LineItems = new List<SessionLineItemOptions>(),
				Mode = "payment",
			};

			foreach (var cart in CartVM.CartList)
			{
				var sessionLineItem = new SessionLineItemOptions
				{
					PriceData = new SessionLineItemPriceDataOptions
					{
						UnitAmount = (long)(cart.Product.Price * 100), // $20.50 => 2050
						Currency = "sek",
						ProductData = new SessionLineItemPriceDataProductDataOptions
						{
							Name = cart.Product.Name
						}
					},
					Quantity = cart.ProdCount
				};
				options.LineItems.Add(sessionLineItem);
			}

			var service = new SessionService();
			Session session = service.Create(options);
			
			_unitOfWork.OrderHeader.UpdateStripePaymentID(CartVM.OrderHeader.Id, session.Id, session.PaymentIntentId);
			_unitOfWork.Save();
			
			Response.Headers.Add("Location", session.Url);
			return new StatusCodeResult(303);
			//return RedirectToAction(nameof(OrderConfirmation), new { id = CartVM.OrderHeader.Id });
		}

		public IActionResult OrderConfirmation(int id)
		{
			OrderHeader orderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == id, includeProperties: "AppUser");
			List<OrderDetails> orderDetails = _unitOfWork.OrderDetails.GetAll(u => u.OrderHeaderId == id, 
					includeProperties: "OrderHeader,Product").ToList();
            
			var service = new SessionService();
			Session session = service.Get(orderHeader.SessionId);

			if (session.PaymentStatus.ToLower() == "paid")
			{
				_unitOfWork.OrderHeader.UpdateStripePaymentID(id, session.Id, session.PaymentIntentId);
				_unitOfWork.OrderHeader.UpdateStatus(id, SD.StatusApproved, SD.PaymentStatusApproved);
				_unitOfWork.Save();
			}

			HttpContext.Session.Clear();

			// Email -----------------------------------
			string emailHeader =
				  $"<p>New Order Number :{orderHeader.Id}</p>"
				+ $"<p>Date  : {orderHeader.OrderDate}</P>"
				+ $"<p>Status: {orderHeader.OrderStatus}</P>"
				+ $"<p>Total : {orderHeader.OrderTotal}</P>"
				+ $"<p> --------------------------------------------------------------------------------------------------------</p>";
				// Have to create a <ul> here.... - PM
			string emailDetails = "";

            foreach (var item in orderDetails)
			{
				emailDetails += 
					$"<p>Product : {item.Product.Name}</p>" 
					+ $"<p>Qty : {item.Count}</p>"
                    + $"<p>Price : {item.Product.Price}</p>"
                    + $"<p>Voucher Key : {item.VoucherKey}</p>"
                    + $"<p> --------------------------------------------------------------------------------------------------------</p>";
            }
			
			_emailSender.SendEmailAsync(orderHeader.AppUser.Email, "New Order - SCS AB", emailHeader + emailDetails);

			// Remove the carts from DB 
			List<Cart> Carts = _unitOfWork.Cart
				.GetAll(u => u.AppUserId == orderHeader.AppUserId).ToList();

			_unitOfWork.Cart.RemoveRange(Carts);
			_unitOfWork.Save();

			return View(id);
		}

		public IActionResult Plus(int cartId)
		{
			var cartFromDb = _unitOfWork.Cart.Get(u => u.Id == cartId);
			cartFromDb.ProdCount += 1;
			_unitOfWork.Cart.Update(cartFromDb);
			_unitOfWork.Save();
			HttpContext.Session.SetInt32(SD.SessionCart, 
				_unitOfWork.Cart.GetAll(u => u.AppUserId == cartFromDb.AppUserId).Count());	
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Minus(int cartId)
		{
			var cartFromDb = _unitOfWork.Cart.Get(u => u.Id == cartId, tracked: true);
			if (cartFromDb.ProdCount <= 1)
			{
                //remove that from cart
                HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.Cart
                     .GetAll(u => u.AppUserId == cartFromDb.AppUserId).Count() - 1);
                _unitOfWork.Cart.Remove(cartFromDb);
			}
			else
			{
				cartFromDb.ProdCount -= 1;
				_unitOfWork.Cart.Update(cartFromDb);
			}

			_unitOfWork.Save();
            return RedirectToAction(nameof(Index));
		}

		public IActionResult Remove(int cartId)
		{
			var cartFromDb = _unitOfWork.Cart.Get(u => u.Id == cartId, tracked:true);
            HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.Cart
              .GetAll(u => u.AppUserId == cartFromDb.AppUserId).Count() - 1);
            _unitOfWork.Cart.Remove(cartFromDb);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}
    }
}
