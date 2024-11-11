using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SCS.Models;
using SCS.Models.ViewModels;
using SCS.Repository.IRepository;
using SCS.Utility;
using System.Diagnostics;

namespace SCS.Areas.Customer;

[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailSender _emailSender;
    
    [BindProperty]
    public ContactVM ContactVM { get; set; } //Used to pass ContactVM between methods - PM

    public HomeController(ILogger<HomeController> logger, 
        IUnitOfWork unitOfWork, 
        IEmailSender emailSender)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _emailSender = emailSender;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Contact(ContactVM ContactVM)
    {
        ContactVM = new ContactVM();
        return View(ContactVM);
    }

    [HttpPost]
    public IActionResult PostContact()
    {
        var admin = _unitOfWork.AppUser.Get(x => x.Email == SD.AdminEmail, includeProperties: "Address");

        _emailSender.SendEmailAsync(admin.Email, "Contact - SCS AB", ContactVM.Subject);
        return View(Index);
    }

    public IActionResult About()
    {
        var admin = _unitOfWork.AppUser.Get(x => x.Email == SD.AdminEmail, includeProperties: "Address");
        return View(admin);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
