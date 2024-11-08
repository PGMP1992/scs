using Microsoft.AspNetCore.Mvc;
using SCS.Models;
using SCS.Repository.IRepository;
using SCS.Utility;
using System.Diagnostics;

namespace SCS.Areas.Customer;

[Area("Customer")]

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    
    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }
    
    public IActionResult About()
    {
        var admin = _unitOfWork.AppUser.Get(x => x.Email ==SD.AdminEmail, includeProperties: "Address");
        return View(admin);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
