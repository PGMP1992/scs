using Microsoft.AspNetCore.Mvc;
using SCS.Repository.IRepository;
using SCS.Utility;

namespace SCS.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync ()
        {
            var userId = HttpContext.User.GetUserId();
            if (userId != null)
            {
                if(HttpContext.Session.GetInt32(SD.SessionCart) == null)
                {
                    HttpContext.Session.SetInt32(SD.SessionCart,
                        _unitOfWork.Cart.GetAll(u => u.AppUserId == userId).Count());
                }
                return View(HttpContext.Session.GetInt32(SD.SessionCart));
            } else
            {
                HttpContext.Session.Clear();
                return View(0);
            }
        }
    }
}
