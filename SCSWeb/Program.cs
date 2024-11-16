using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SCS.Data;
using SCS.Data.DbInitializer;
using SCS.Repository;
using SCS.Repository.IRepository;
using SCS.Utility;
using Stripe;
using System.Globalization;
using System.Text;


CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("se-SE");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("se-SE");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//  Added for JWT
//builder.Services.AddControllersWithViews( opt =>
//    {
//        var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
//        opt.Filters.Add(new AuthorizeFilter(policy));
//    } 
//);
//  Added for JWT

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

// Changed Defaul Error Pages. PS has to be after Identity - PM
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

// Session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder.Services.AddRazorPages(); // Added to use Identity pages for Login/ register. etc...

// Created Identity with Jwt Tokens - PM
//builder.Services.AddIdentityServices(builder.Configuration); // Extensions/IdentityServicesExtension.cs - PM
//builder.Services.AddIdentity<AppUser, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();
// Access Path to Authorization pages has to be added after Identity - PM

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>(); // Implemented for Register.cshtml.cs

// JWT Bearer Session Added - PM
builder.Services.AddScoped<TokenService>();

//var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("TokenKey").Get<string>()));
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
// JWT Bearer Session Added - PM

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
SeedDatabase();
app.MapRazorPages(); // Added for Routing the Identity Pages - PM

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var DbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        DbInitializer.Initialize();
    }
}
