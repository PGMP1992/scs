using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SCS.Models;
using SCS.Utility;

namespace SCS.DataAccess.Data
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
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Bundle> Bundles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>().HasData(
                new Address()
                {
                    Id = 1,
                    Street1 = "Street 1",
                    Street2 = "Street 2",
                    City = "City Admin",
                    State = "State Admin",
                    Country = "Country Admin",
                    Postcode = "111111"
                }
                );

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
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Certificate in Sanctions",
                    CategoryId = 1,
                    Description = "E-learning om efterlevnad av sanktioner i egen takt (15–20 timmar långt)",
                    Price = 7200,
                    Status = SD.ProductStatusRegistrated,
                    ProviderId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Certificate in Corporate Governance",
                    CategoryId = 1,
                    Description = "E-learning om efterlevnad av sanktioner i egen takt (15–20 timmar långt)",
                    Price = 8400,
                    Status = SD.ProductStatusRegistrated,
                    ProviderId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "C# Certificate",
                    CategoryId = 1,
                    Description = "C# Certification",
                    Price = 1000,
                    Status = SD.ProductStatusRegistrated,
                    ProviderId = 2
                },
                new Product
                {
                    Id = 4,
                    Name = "C# Begginner",
                    CategoryId = 2,
                    Description = "C# Begginner Programming",
                    Price = 200,
                    Status = SD.ProductStatusRegistrated,
                    ProviderId = 2
                },
                new Product
                {
                    Id = 5,
                    Name = "C# Begginner",
                    CategoryId = 3,
                    Description = "C# Begginner Programming",
                    Price = 300,
                    Status = SD.ProductStatusRegistrated,
                    ProviderId = 2
                },
                new Product
                {
                    Id = 6,
                    Name = "C# Intermediate",
                    CategoryId = 2,
                    Description = "C# Intermediate Programming",
                    Price = 200,
                    Status = SD.ProductStatusRegistrated,
                    ProviderId = 2
                },
                new Product
                {
                    Id = 7,
                    Name = "C# Intermediate",
                    CategoryId = 3,
                    Description = "C# Intermediate Programming",
                    Price = 300,
                    Status = SD.ProductStatusRegistrated,
                    ProviderId = 2
                },
                new Product
                {
                    Id = 8,
                    Name = "C# Advanced",
                    CategoryId = 2,
                    Description = "C# Advanced Programming",
                    Price = 200,
                    Status = SD.ProductStatusRegistrated,
                    ProviderId = 2
                },
                new Product
                {
                    Id = 9,
                    Name = "C# Advanced",
                    CategoryId = 3,
                    Description = "C# Advanced Programming",
                    Price = 300,
                    Status = SD.ProductStatusRegistrated,
                    ProviderId = 2
                },
                new Product
                {
                    Id = 10,
                    Name = "C# for beginners, Bundle",
                    CategoryId = 3,
                    Description = "C# Advanced Programming",
                    Price = 300,
                    Status = SD.ProductStatusRegistrated,
                    ProviderId = 2,
                    BundleId = 1
                }
            );

            modelBuilder.Entity<CertificationSlot>().HasData(
               new CertificationSlot
               {
                   Id = 1,
                   ProductId = 1,
                   ParticipantsMax = 10,
                   ParticipantsRegistered = 0,
                   StartDate = DateTime.Now,
                   EndDate = DateTime.Now.AddDays(60),
                   DayOfWeek = DayOfWeek.Monday,
                   WeekNumbers = new List<int>() { 39, 41, 43 }
               },

               new CertificationSlot
               {
                   Id = 2,
                   ProductId = 1,
                   ParticipantsMax = 15,
                   ParticipantsRegistered = 0,
                   StartDate = DateTime.Now.AddDays(10),
                   EndDate = DateTime.Now.AddDays(80),
                   DayOfWeek = DayOfWeek.Tuesday,
                   WeekNumbers = new List<int>() { 43, 45, 437 }

               },
                new CertificationSlot
                {
                    Id = 3,
                    ProductId = 2,
                    ParticipantsMax = 15,
                    ParticipantsRegistered = 0,
                    StartDate = DateTime.Now.AddDays(10),
                    EndDate = DateTime.Now.AddDays(80),
                    DayOfWeek = DayOfWeek.Tuesday,
                    WeekNumbers = new List<int>() { 43, 45, 47 }
                }
           );



        }
    }
}
