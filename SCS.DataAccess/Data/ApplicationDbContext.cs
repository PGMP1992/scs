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
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogSubscriber> BlogSubscribers { get; set; }

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
			modelBuilder.Entity<BlogCategory>().HasData(
			   new BlogCategory { Id = 1, Name = "Lexicon", Slug = "lexicon", ShowOnNavbar = true },
			   new BlogCategory { Id = 2, Name = "SCS", Slug = "scs", ShowOnNavbar = true },
			   new BlogCategory { Id = 3, Name = "C#", Slug = "c-sharp", ShowOnNavbar = true },
			   new BlogCategory { Id = 4, Name = "ASP.NET Core#", Slug = "asp-net-core", ShowOnNavbar = false },
			   new BlogCategory { Id = 5, Name = "Blazor", Slug = "blazor", ShowOnNavbar = true },
			   new BlogCategory { Id = 6, Name = "SQL Server", Slug = "sql-server", ShowOnNavbar = false },
			   new BlogCategory { Id = 7, Name = "Entity Framework Core", Slug = "ef-core", ShowOnNavbar = false },
			   new BlogCategory { Id = 8, Name = "Angular", Slug = "angular", ShowOnNavbar = false },
			   new BlogCategory { Id = 9, Name = "React", Slug = "react", ShowOnNavbar = false },
			   new BlogCategory { Id = 10, Name = "Vue", Slug = "vue", ShowOnNavbar = false },
			   new BlogCategory { Id = 11, Name = "JavaScript", Slug = "javascript", ShowOnNavbar = false },
			   new BlogCategory { Id = 12, Name = "HTML", Slug = "html", ShowOnNavbar = false },
			   new BlogCategory { Id = 13, Name = "CSS", Slug = "css", ShowOnNavbar = false },
			   new BlogCategory { Id = 14, Name = "Bootstrap", Slug = "bootstrap", ShowOnNavbar = false },
			   new BlogCategory { Id = 15, Name = "MVC", Slug = "mvc", ShowOnNavbar = false },
               new BlogCategory { Id=16 , Name="Blommor" , Slug="blommor" , ShowOnNavbar=true }
		   );
            modelBuilder.Entity<BlogPost>().HasData(
           new BlogPost { 
               Id = 1, 
               Title = "Ny hemsida", 
               Slug = "ny-hemsida",
               Image = "images/posts/lwbsypfb.rxe.png",
               Introduction = "scservices har fått en ny mensida",
               Content= "<p> besök den https:\\scservices.se</p>",
               BlogCategoryId = 2,
               IsPublished = true,
               ViewCount = 2,
               IsFeatured = true,
               CreatedAt = DateTime.Now.AddDays(-3),
               PublishedAt = DateTime.Now.AddDays(-3)
           },
           new BlogPost
           {
               Id = 2,
               Title = "Lexicon i Malmö",
               Slug = "ny-hemsida",
               Image = "images/posts/e41eigqw.de2.png",
               Introduction = "Här finns vi",
               Content = "<p> Du hittar oss på Södergatan 24 mellan Stortorget och Gustav Adolfs Torg. Cirka 10 minuter gångväg från Centralstationen. Ingång mellan Stadium och Indiska.</p><p>Varmt välkommen att kontakta oss för mer information&nbsp;om våra erbjudanden och bokning.</p>",
               BlogCategoryId = 1,
               IsPublished = true,
               ViewCount = 4,
               IsFeatured = true,
               CreatedAt = DateTime.Now.AddDays(-4),
               PublishedAt = DateTime.Now.AddDays(-4)
           }, new BlogPost
           {
               Id = 3,
               Title = "Rosor",
               Slug = "rosor",
               Image = "images/posts/u1q4qomy.loi.png",
               Introduction = "Rikblommande rosor - floribunda",
               Content = "<p> <span style=\"color: rgb(71, 71, 71);\">Floribundarosor, en grupp rosor med mycket komplext ursprung. Grunden till gruppen utgörs av korsningar mellan polyantarosor och rosor i andra grupper. Gruppen inkluderar även produktnamn som miniflorarosor, castlerosor och palacerosor. Motsvarar beteckningarna Floribunda och Climbing Floribunda i Modern Roses 11.&nbsp;</span><a href=\"https://sv.wikipedia.org/wiki/Floribundarosor\" target=\"_blank\" style=\"color: var(--JKqx2);\">Wikipedia</a></p>",
               BlogCategoryId = 16,
               IsPublished = true,
               ViewCount = 5,
               IsFeatured = true,
               CreatedAt = DateTime.Now.AddDays(-1),
               PublishedAt = DateTime.Now.AddDays(-1)
           }, new BlogPost
           {
               Id = 4,
               Title = "Lavendel",
               Slug = "lavendel",
               Image = "images/posts/yujd3vy3.mmp.png",
               Introduction = "Lavendel, Lavandula angustifolia, är en av de mest älskade trädgårdsväxterna. Alla bör unna sig lavendel, den trivs både i rabatten och sommarkrukan",
               Content = "<p><strong style=\"color: rgb(95, 99, 104);\">Lavendel</strong><span style=\"color: rgb(77, 81, 86);\">, Lavandula angustifolia, är en av de mest älskade trädgårdsväxterna. Alla bör unna sig&nbsp;</span><strong style=\"color: rgb(95, 99, 104);\">lavendel</strong><span style=\"color: rgb(77, 81, 86);\">, den trivs både i rabatten och sommarkrukan</span></p><p><br></p><p><a href=\"https://www.blomsterlandet.se/kundklubb/\" target=\"_blank\" style=\"color: rgb(222, 238, 241);\">Kundklubb</a><a href=\"https://www.blomsterlandet.se/hitta-din-butik/\" target=\"_blank\" style=\"color: rgb(222, 238, 241);\">Våra butiker</a></p><p><img src=\"https://www.blomsterlandet.se/contentassets/309cef56f7d444a0abc60d61ec24da04/lavendelhack.jpg\"></p><p>Lavendel räknas som halvbuske, eftersom den blir förvedad, och är därför inte härdig i hela landet. Ju längre norrut man bor desto viktigare är det att välja ett soligt, varmt och framförallt väldränerat läge. Lavendel älskar torr jord, gärna sandblandad, sol och värme. Även om lavendel under gynnsamma former kan klara sig i zon 5 är det att rekommendera att i zon 3 och norrut plantera lavendeln i en upphöjd rabatt – eller i krukor som du vinterförvarar ljust och frostfritt.</p><p><br></p><p>Lavendel räknas också som medicinalväxt och har lugnande och kramplösande egenskaper. Lavendelblommor ger utsökt smak i olika sorters kakor, både i småkakor, skorpor och sockerkakor.</p><p>Främst är det doften vi tycker så mycket om, denna somriga doft som i fantasin tar oss med på resor till Provence och Toscana.</p>",
               BlogCategoryId =16,
               IsPublished = true,
               ViewCount = 3,
               IsFeatured = true,
               CreatedAt = DateTime.Now.AddDays(-7),
               PublishedAt = DateTime.Now.AddDays(-7)
           }, new BlogPost
           {
               Id = 5,
               Title = "Guide",
               Slug = "guide",
               Image = "images/posts/kcukikkw.lb3.png",
               Introduction = "C# (C-Sharp) is a programming language developed by Microsoft that runs on the .NET",
               Content = "<p> https://www.w3schools.com/cs/index.php</p><h2>What is C#?</h2><p>C# is pronounced \"C-Sharp\".</p><p>It is an object-oriented programming language created by Microsoft that runs on the .NET Framework.</p><p>C# has roots from the C family, and the language is close to other popular languages like&nbsp;<a href=\"https://www.w3schools.com/cpp/default.asp\" target=\"_blank\" style=\"color: inherit;\">C++</a>&nbsp;and&nbsp;<a href=\"https://www.w3schools.com/java/default.asp\" target=\"_blank\" style=\"color: inherit;\">Java</a>.</p><p>The first version was released in year 2002. The latest version,&nbsp;<strong>C# 12</strong>, was released in November 2023.</p><p>C# is used for:</p><ul><li>Mobile applications</li><li>Desktop applications</li><li>Web applications</li><li>Web services</li><li>Web sites</li><li>Games</li><li>VR</li><li>Database applications</li><li>And much, much more!</li></ul><h2>Why Use C#?</h2><ul><li>It is one of the most popular programming languages in the world</li><li>It is easy to learn and simple to use</li><li>It has huge community support</li><li>C# is an object-oriented language which gives a clear structure to programs and allows code to be reused, lowering development costs</li><li>As C# is close to&nbsp;<a href=\"https://www.w3schools.com/c/index.php\" target=\"_blank\" style=\"color: inherit;\">C</a>,&nbsp;<a href=\"https://www.w3schools.com/cpp/default.asp\" target=\"_blank\" style=\"color: inherit;\">C++</a>&nbsp;and&nbsp;<a href=\"https://www.w3schools.com/java/default.asp\" target=\"_blank\" style=\"color: inherit;\">Java</a>, it makes it easy for programmers to switch to C# or vice versa</li></ul><h2>Get Started</h2><p>This tutorial will teach you the basics of C#.</p><p>It is not necessary to have any prior programming experience.</p>",
               BlogCategoryId = 3,
               IsPublished = true,
               ViewCount = 1,
               IsFeatured = true,
               CreatedAt = DateTime.Now.AddDays(-8),
               PublishedAt = DateTime.Now.AddDays(-8)
           }


       );
        }
    }
}
