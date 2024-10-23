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
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;

        [BindProperty]
        public CartVM CartVM { get; set; }

        public ProductController(IUnitOfWork unitOfWork
                                 , IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }

        public IActionResult Index(string search)
        {
            IEnumerable<Product> productList = _unitOfWork.Product
                .GetAll(includeProperties: "ProductImages,Provider,Category");

            ViewBag.Message = "";

            if (!String.IsNullOrEmpty(search))
            {
                IEnumerable<Product> searchList = _unitOfWork.Product
                    .GetAll(p => p.Name.Contains(search), includeProperties: "ProductImages,Provider,Category");

                if (searchList.Count() > 0)
                {
                    return View(searchList);
                }
                ViewBag.Message = "There are not products within that search.";
            }
            return View(productList);
        }

        public IActionResult IndexList(string search)
        {
            IEnumerable<Product> productList = _unitOfWork.Product
                .GetAll(includeProperties: "ProductImages,Provider,Category");

            ViewBag.Message = "";

            if (!String.IsNullOrEmpty(search))
            {
                IEnumerable<Product> searchList = _unitOfWork.Product
                    .GetAll(p => p.Name.Contains(search), includeProperties: "ProductImages,Provider,Category");

                if (searchList.Count() > 0)
                {
                    return View(searchList);
                }
                ViewBag.Message = "There are not products within that search.";
            }
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            Cart cart = new()
            {
                Product = _unitOfWork.Product.Get(p => p.Id == productId, includeProperties: "ProductImages,Provider,Category"),
                ProdCount = 1,
                ProductId = productId,
            };
            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(Cart cart)
        {
            var userId = HttpContext.User.GetUserId();
            cart.AppUserId = userId;

            Cart dbCart = _unitOfWork.Cart.Get(u => u.AppUserId == userId
                && u.ProductId == cart.ProductId, null, false);

            if (dbCart != null) // Cart exists 
            {
                dbCart.ProdCount += 1;
                _unitOfWork.Cart.Update(dbCart);
                _unitOfWork.Save();
            }
            else // Create Cart
            {
                cart.ProdCount = 1;
                _unitOfWork.Cart.Add(cart);
                _unitOfWork.Save();
                HttpContext.Session.SetInt32(SD.SessionCart
                    , _unitOfWork.Cart.GetAll(u => u.AppUserId == userId).Count());
            }
            TempData["success"] = "Product Added to Cart!";
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult AddToCart(int productId)
        {
            var userId = HttpContext.User.GetUserId();

            Cart cart = new()
            {
                Product = _unitOfWork.Product.Get(p => p.Id == productId, includeProperties: "ProductImages,Provider,Category", true),
                ProdCount = 1,
                ProductId = productId,
                AppUserId = userId
            };

            Cart dbCart = _unitOfWork.Cart.Get(u => u.AppUserId == userId
                && u.ProductId == productId, null, true);

            if (dbCart != null) // Cart exists
            {
                dbCart.ProdCount += 1;
                _unitOfWork.Cart.Update(dbCart);
                _unitOfWork.Save();
            }
            else // Create Cart
            {
                cart.ProdCount = 1;
                _unitOfWork.Cart.Add(cart);
                _unitOfWork.Save();
                HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.Cart.GetAll(u => u.AppUserId == userId).Count());
            }
            TempData["success"] = "Product Added to Cart!";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Buy(int productId)
        {
            AppUser tempUser = new AppUser()
            {
                Name = "Temp",
                UserName = SD.TempEmail,
                Email = SD.TempEmail,
            };

            _unitOfWork.AppUser.Add(tempUser);
            _unitOfWork.Save();

            // Save Sesssion TempUserId 
            HttpContext.Session.SetString(SD.SessionTempUserId, tempUser.Id);

            Cart cart = new()
            {
                Product = _unitOfWork.Product.Get(p => p.Id == productId, includeProperties: "ProductImages,Provider,Category", true),
                ProdCount = 1,
                ProductId = productId,
                AppUserId = HttpContext.Session.GetString(SD.SessionTempUserId)
            };

            // Create Cart
            cart.ProdCount = 1;
            _unitOfWork.Cart.Add(cart);
            _unitOfWork.Save();

            return RedirectToAction(nameof(BuySummary));
        }

        public IActionResult BuySummary()
        {
            CartVM = new CartVM()
            {
                CartList = _unitOfWork.Cart.GetAll(u => u.AppUserId == HttpContext.Session.GetString(SD.SessionTempUserId),
                    includeProperties: "Product"),
                OrderHeader = new()
            };

            // User should enter Name and Email Address for Stripe and SendGrid
            CartVM.OrderHeader.Name = "";
            CartVM.OrderHeader.Email = "";

            foreach (var cart in CartVM.CartList)
            {
                cart.Price = cart.Product.Price * cart.ProdCount;
                CartVM.OrderHeader.OrderTotal += cart.Price;
            }
            return View(CartVM);
        }

        [HttpPost]
        [ActionName("BuySummary")]
        public IActionResult BuySummaryPost()
        {
            var tempUserId = HttpContext.Session.GetString(SD.SessionTempUserId);

            CartVM.CartList = _unitOfWork.Cart.GetAll(u => u.AppUserId == tempUserId,
                includeProperties: "Product");

            CartVM.OrderHeader.OrderDate = System.DateTime.Now;
            CartVM.OrderHeader.AppUserId = tempUserId;

            // Save Name and Email to User in OrderHeaders and AppUsers - PM
            var newAppUser = _unitOfWork.AppUser.Get(u => u.Id == tempUserId, tracked: true);
            _unitOfWork.AppUser.SetName(newAppUser.Id, CartVM.OrderHeader.Name);
            _unitOfWork.AppUser.SetEmail(newAppUser.Id, CartVM.OrderHeader.Email);
            _unitOfWork.AppUser.Update(newAppUser);
            _unitOfWork.Save();

            // Save new UserId to Session after creating Users
            HttpContext.Session.SetString(SD.SessionTempUserId, newAppUser.Id);
            newAppUser.Id = HttpContext.Session.GetString(SD.SessionTempUserId);

            foreach (var cart in CartVM.CartList)
            {
                cart.Price = cart.Product.Price * cart.ProdCount;
                CartVM.OrderHeader.OrderTotal += cart.Price;
            }

            CartVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
            CartVM.OrderHeader.OrderStatus = SD.StatusPending;

            _unitOfWork.OrderHeader.Add(CartVM.OrderHeader);
            _unitOfWork.Save();

            foreach (var cart in CartVM.CartList)
            {
                var orderDetail = new OrderDetails()
                {
                    ProductId = cart.ProductId,
                    OrderHeaderId = CartVM.OrderHeader.Id,
                    Price = cart.Price,
                    Count = cart.ProdCount
                };
                _unitOfWork.OrderDetails.Add(orderDetail);
                _unitOfWork.Save();
            }

            //Stripe logic ------------------------------------------------
            var domain = Request.Scheme + "://" + Request.Host.Value + "/";
            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + $"customer/product/BuyOrderConfirmation?id={CartVM.OrderHeader.Id}",
                CancelUrl = domain + "customer/product/Index",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                CustomerEmail = CartVM.OrderHeader.Email,
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
        }

        public IActionResult BuyOrderConfirmation(int id)
        {
            OrderHeader orderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == id, includeProperties: "AppUser");
            
            var service = new SessionService();
            Session session = service.Get(orderHeader.SessionId);

            if (session.PaymentStatus.ToLower() == "paid")
            {
                _unitOfWork.OrderHeader.UpdateStripePaymentID(id, session.Id, session.PaymentIntentId);
                _unitOfWork.OrderHeader.UpdateStatus(id, SD.StatusApproved, SD.PaymentStatusApproved);
                _unitOfWork.Save();
                
                // Email --------------------------
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
                
                // Remove the carts from DB 
                List<Cart> Carts = _unitOfWork.Cart
                    .GetAll(u => u.AppUserId == orderHeader.AppUserId).ToList();

                _unitOfWork.Cart.RemoveRange(Carts);
                _unitOfWork.Save();
                // Clear Session 

                HttpContext.Session.Clear();
                return View(id);
            }
            else // Payment didn't go through  
            {
                // Have  to delete user if not paid
                //_unitOfWork.OrderHeader.Remove(orderHeader);
                //_unitOfWork.OrderDetails.Remove();
                
                // Deleting User will cascade to OrderHeader, OrderDetails and Hopefully CartList - PM
                _unitOfWork.AppUser.Remove(orderHeader.AppUser);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
