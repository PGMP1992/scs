using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SCS.Models;
using SCS.Repository.IRepository;
using SCS.Utility;

namespace SCS.Data.DbInitializer;

public class DbInitializer : IDbInitializer
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _db;
    private readonly IUnitOfWork _unitOfWork;

    public DbInitializer(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db,
            IUnitOfWork unitOfWork
        )
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _db = db;
        _unitOfWork = unitOfWork;
    }

    public void Initialize()
    {
        try
        {
            if (_db.Database.GetPendingMigrations().Count() > 0)
            {
                _db.Database.Migrate();
            }
        }
        catch (Exception ex)
        {
        }

        _db.Database.EnsureCreated();

        if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
        {
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
        }

        // Create Admin User
        _userManager.CreateAsync(new AppUser()
        {
            Name = "Admin",
            UserName = SD.AdminEmail,
            Email = SD.AdminEmail,
            Address = new Address
            {
                Street1 = "Admin Street 1",
                Street2 = "Admin Street 2",
                City = "Admin City",
                State = "Admin State",
                Postcode = "Admin postocode",
                Country = "Admin Country"
            },
        }, SD.Password).GetAwaiter().GetResult();

        AppUser user = _db.AppUsers.FirstOrDefault(u => u.Email == SD.AdminEmail);
        _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
        
        return;
    }
}
