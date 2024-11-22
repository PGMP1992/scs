using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SCS.Models;
using SCS.Utility;

namespace SCS.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<CertificationSlot> CertificationSlots { get; set; }
        public DbSet<CertificationDay> CertificationDays { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Bundle> Bundles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        //public DbSet<BlogCategory> BlogCategories { get; set; }
        //public DbSet<BlogPost> BlogPosts { get; set; }
        //public DbSet<BlogSubscriber> BlogSubscribers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Certification Vouchers",
                    Description = "Description...",
                },
                new Category
                {
                    Id = 2,
                    Name = "Learning Materials",
                    Description = "Description..."
                },
                new Category
                {
                    Id = 3,
                    Name = "Practice Tests",
                    Description = "Description..."
                },
                new Category
                {
                    Id = 4,
                    Name = "Bundles",
                    Description = "Description..."
                }
           );

            modelBuilder.Entity<Provider>().HasData(
               new Provider
               {
                   Id = 1,
                   Name = "AGRC",
                   ContactName = "AGRC Contact Name",
                   ContactEmail = "info@agrc.com",
                   ContactPhone = "11111111"
               },
               new Provider
               {
                   Id = 2,
                   Name = "Microsoft",
                   ContactName = "Microsoft Contact Name",
                   ContactEmail = "info@microsoft.com",
                   ContactPhone = "22222222"
               },
               new Provider
               {
                   Id = 3,
                   Name = "Google",
                   ContactName = "Google Contact Name",
                   ContactEmail = "info@google.com",
                   ContactPhone = "33333333"
               },
               new Provider
               {
                   Id = 4,
                   Name = "Red Hat",
                   ContactName = "Red Hat Contact Name",
                   ContactEmail = "info@redhat.com",
                   ContactPhone = "44444444"
               }
            );

            modelBuilder.Entity<Bundle>().HasData(
                new Bundle
                {
                    Id = 1,
                    Name = "C# for beginners, Bundle",
                    ProductId1 = 3,
                    ProductId2 = 4,
                    ProductId3 = 5,
                    Price = 8500
                }
            );

            modelBuilder.Entity<CertificationSlot>().HasData(
                new CertificationSlot
                {
                    Id = 1,
                    Name = "Sanctions",
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(10)),
                    EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(14)),
                    Dates = new List<DateOnly>
                    {
                        DateOnly.FromDateTime(DateTime.Now.AddDays(11)),
                        DateOnly.FromDateTime(DateTime.Now.AddDays(13)),
                    }
                },
                new CertificationSlot
                {
                    Id = 2,
                    Name = "C# Beginner",
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(20)),
                    EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(29)),

                    Dates = new List<DateOnly>
                    {
                        DateOnly.FromDateTime(DateTime.Now.AddDays(21)),
                        DateOnly.FromDateTime(DateTime.Now.AddDays(24)),
                        DateOnly.FromDateTime(DateTime.Now.AddDays(26))
                    }
                }
            );

            modelBuilder.Entity<CertificationDay>().HasData(

                new CertificationDay
                {
                    Id = 1,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(10)),
                    IsCertDay = false,
                    CertSlotId = 1
                },
                new CertificationDay
                {
                    Id = 2,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(11)),
                    IsCertDay = true,
                    CertSlotId = 1
                },
                new CertificationDay
                {
                    Id = 3,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(12)),
                    IsCertDay = false,
                    CertSlotId = 1
                },
                new CertificationDay
                {
                    Id = 4,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(13)),
                    IsCertDay = true,
                    CertSlotId = 1
                },
                new CertificationDay
                {
                    Id = 5,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(14)),
                    IsCertDay = false,
                    CertSlotId = 1
                },
                new CertificationDay
                {
                    Id = 6,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(20)),
                    IsCertDay = false,
                    CertSlotId = 2
                },
                new CertificationDay
                {
                    Id = 7,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(21)),
                    IsCertDay = true,
                    CertSlotId = 2
                },
                new CertificationDay
                {
                    Id = 8,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(22)),
                    IsCertDay = false,
                    CertSlotId = 2
                },
                new CertificationDay
                {
                    Id = 9,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(23)),
                    IsCertDay = true,
                    CertSlotId = 2
                },
                new CertificationDay
                {
                    Id = 10,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(24)),
                    IsCertDay = true,
                    CertSlotId = 2
                },
                new CertificationDay
                {
                    Id = 11,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(25)),
                    IsCertDay = false,
                    CertSlotId = 2
                },
                new CertificationDay
                {
                    Id = 12,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(26)),
                    IsCertDay = true,
                    CertSlotId = 2
                },
                new CertificationDay
                {
                    Id = 13,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(27)),
                    IsCertDay = false,
                    CertSlotId = 2
                },
                new CertificationDay
                {
                    Id = 14,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(28)),
                    IsCertDay = false,
                    CertSlotId = 2
                },
                new CertificationDay
                {
                    Id = 15,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(29)),
                    IsCertDay = false,
                    CertSlotId = 2
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Certificate in Sanctions",
                    CategoryId = 1,
                    Description = "Certificate in Sanctions Description....",
                    Price = 7200,
                    Status = SD.ProductStatusActive,
                    ProviderId = 1,
                    CertSlotId=1,
                },
                new Product
                {
                    Id = 2,
                    Name = "Certificate in Corporate Governance",
                    CategoryId = 1,
                    Description = "Certificate in Corporate Governance Description....",
                    Price = 8400,
                    Status = SD.ProductStatusActive,
                    ProviderId = 1,
                },
                new Product
                {
                    Id = 3,
                    Name = "C# Certificate",
                    CategoryId = 1,
                    Description = "C# Certification Description...",
                    Price = 1000,
                    Status = SD.ProductStatusActive,
                    ProviderId = 2,
                    BundleId = 1,
                },
                new Product
                {
                    Id = 4,
                    Name = "C# Beginner",
                    CategoryId = 2,
                    Description = "C# Begginner Programming Description...",
                    Price = 200,
                    Status = SD.ProductStatusActive,
                    ProviderId = 2,
                    BundleId = 1,
                },
                new Product
                {
                    Id = 5,
                    Name = "C# Beginner",
                    CategoryId = 3,
                    Description = "C# Begginner Programming Description...",
                    Price = 300,
                    Status = SD.ProductStatusActive,
                    ProviderId = 2,
                    BundleId = 1,
                },
                new Product
                {
                    Id = 10,
                    Name = "C# for beginners, Bundle",
                    CategoryId = 4,
                    Description = "C# Advanced Programming Description...",
                    Price = 300,
                    Status = SD.ProductStatusActive,
                    ProviderId = 2,
                    BundleId = 1,
                }
            );
			//modelBuilder.Entity<BlogCategory>().HasData(
			//   new BlogCategory { Id = 1, Name = "Lexicon", Slug = "lexicon", ShowOnNavbar = true },
			//   new BlogCategory { Id = 2, Name = "SCS", Slug = "scs", ShowOnNavbar = true },
			//   new BlogCategory { Id = 3, Name = "C#", Slug = "c-sharp", ShowOnNavbar = false },
			//   new BlogCategory { Id = 4, Name = "ASP.NET Core#", Slug = "asp-net-core", ShowOnNavbar = true },
			//   new BlogCategory { Id = 5, Name = "Blazor", Slug = "blazor", ShowOnNavbar = true },
			//   new BlogCategory { Id = 6, Name = "SQL Server", Slug = "sql-server", ShowOnNavbar = false },
			//   new BlogCategory { Id = 7, Name = "Entity Framework Core", Slug = "ef-core", ShowOnNavbar = false },
			//   new BlogCategory { Id = 8, Name = "Angular", Slug = "angular", ShowOnNavbar = false },
			//   new BlogCategory { Id = 9, Name = "React", Slug = "react", ShowOnNavbar = false },
			//   new BlogCategory { Id = 10, Name = "Vue", Slug = "vue", ShowOnNavbar = false },
			//   new BlogCategory { Id = 11, Name = "JavaScript", Slug = "javascript", ShowOnNavbar = false },
			//   new BlogCategory { Id = 12, Name = "HTML", Slug = "html", ShowOnNavbar = false },
			//   new BlogCategory { Id = 13, Name = "CSS", Slug = "css", ShowOnNavbar = false },
			//   new BlogCategory { Id = 14, Name = "Bootstrap", Slug = "bootstrap", ShowOnNavbar = false },
			//   new BlogCategory { Id = 15, Name = "MVC", Slug = "mvc", ShowOnNavbar = true }
		 //  );
		}
    }
}
