using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    ShowOnNavbar = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogSubscribers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SubscribedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogSubscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bundles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ProductId1 = table.Column<int>(type: "int", nullable: true),
                    ProductId2 = table.Column<int>(type: "int", nullable: true),
                    ProductId3 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificationSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: true),
                    ShowDays = table.Column<bool>(type: "bit", nullable: false),
                    Dates = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationSlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificationDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    IsCertDay = table.Column<bool>(type: "bit", nullable: false),
                    CertSlotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificationDays_CertificationSlots_CertSlotId",
                        column: x => x.CertSlotId,
                        principalTable: "CertificationSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: true),
                    BundleId = table.Column<int>(type: "int", nullable: true),
                    CertSlotId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Bundles_BundleId",
                        column: x => x.BundleId,
                        principalTable: "Bundles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_CertificationSlots_CertSlotId",
                        column: x => x.CertSlotId,
                        principalTable: "CertificationSlots",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Introduction = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogCategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlogPosts_BlogCategories_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    VoucherKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<double>(type: "float", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProdCount = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartImage = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    VoucherKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookCount = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "Name", "ShowOnNavbar", "Slug" },
                values: new object[,]
                {
                    { 1, "Lexicon", true, "lexicon" },
                    { 2, "SCS", true, "scs" },
                    { 3, "C#", true, "c-sharp" },
                    { 4, "ASP.NET Core#", false, "asp-net-core" },
                    { 5, "Blazor", true, "blazor" },
                    { 6, "SQL Server", false, "sql-server" },
                    { 7, "Entity Framework Core", false, "ef-core" },
                    { 8, "Angular", false, "angular" },
                    { 9, "React", false, "react" },
                    { 10, "Vue", false, "vue" },
                    { 11, "JavaScript", false, "javascript" },
                    { 12, "HTML", false, "html" },
                    { 13, "CSS", false, "css" },
                    { 14, "Bootstrap", false, "bootstrap" },
                    { 15, "MVC", false, "mvc" },
                    { 16, "Blommor", true, "blommor" }
                });

            migrationBuilder.InsertData(
                table: "Bundles",
                columns: new[] { "Id", "Name", "Price", "ProductId1", "ProductId2", "ProductId3" },
                values: new object[] { 1, "C# for beginners, Bundle", 8500.0, 3, 4, 5 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description...", "Certification Vouchers" },
                    { 2, "Description...", "Learning Materials" },
                    { 3, "Description...", "Practice Tests" },
                    { 4, "Description...", "Bundles" }
                });

            migrationBuilder.InsertData(
                table: "CertificationSlots",
                columns: new[] { "Id", "Dates", "DayOfWeek", "EndDate", "Name", "ShowDays", "StartDate" },
                values: new object[,]
                {
                    { 1, "[\"2024-11-30\",\"2024-12-02\"]", null, new DateOnly(2024, 12, 3), "Sanctions", false, new DateOnly(2024, 11, 29) },
                    { 2, "[\"2024-12-10\",\"2024-12-13\",\"2024-12-15\"]", null, new DateOnly(2024, 12, 18), "C# Beginner", false, new DateOnly(2024, 12, 9) }
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "ContactEmail", "ContactName", "ContactPhone", "Name" },
                values: new object[,]
                {
                    { 1, "info@agrc.com", "AGRC Contact Name", "11111111", "AGRC" },
                    { 2, "info@microsoft.com", "Microsoft Contact Name", "22222222", "Microsoft" },
                    { 3, "info@google.com", "Google Contact Name", "33333333", "Google" },
                    { 4, "info@redhat.com", "Red Hat Contact Name", "44444444", "Red Hat" }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "BlogCategoryId", "Content", "CreatedAt", "Image", "Introduction", "IsFeatured", "IsPublished", "PublishedAt", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { 1, 2, "<p> besök den https:\\scservices.se</p>", new DateTime(2024, 11, 16, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6795), "images/posts/lwbsypfb.rxe.png", "scservices har fått en ny mensida", true, true, new DateTime(2024, 11, 16, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6795), "ny-hemsida", "Ny hemsida", null, 2 },
                    { 2, 1, "<p> Du hittar oss på Södergatan 24 mellan Stortorget och Gustav Adolfs Torg. Cirka 10 minuter gångväg från Centralstationen. Ingång mellan Stadium och Indiska.</p><p>Varmt välkommen att kontakta oss för mer information&nbsp;om våra erbjudanden och bokning.</p>", new DateTime(2024, 11, 15, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6801), "images/posts/e41eigqw.de2.png", "Här finns vi", true, true, new DateTime(2024, 11, 15, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6801), "ny-hemsida", "Lexicon i Malmö", null, 4 },
                    { 3, 16, "<p> <span style=\"color: rgb(71, 71, 71);\">Floribundarosor, en grupp rosor med mycket komplext ursprung. Grunden till gruppen utgörs av korsningar mellan polyantarosor och rosor i andra grupper. Gruppen inkluderar även produktnamn som miniflorarosor, castlerosor och palacerosor. Motsvarar beteckningarna Floribunda och Climbing Floribunda i Modern Roses 11.&nbsp;</span><a href=\"https://sv.wikipedia.org/wiki/Floribundarosor\" target=\"_blank\" style=\"color: var(--JKqx2);\">Wikipedia</a></p>", new DateTime(2024, 11, 18, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6803), "images/posts/u1q4qomy.loi.png", "Rikblommande rosor - floribunda", true, true, new DateTime(2024, 11, 18, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6804), "rosor", "Rosor", null, 5 },
                    { 4, 16, "<p><strong style=\"color: rgb(95, 99, 104);\">Lavendel</strong><span style=\"color: rgb(77, 81, 86);\">, Lavandula angustifolia, är en av de mest älskade trädgårdsväxterna. Alla bör unna sig&nbsp;</span><strong style=\"color: rgb(95, 99, 104);\">lavendel</strong><span style=\"color: rgb(77, 81, 86);\">, den trivs både i rabatten och sommarkrukan</span></p><p><br></p><p><a href=\"https://www.blomsterlandet.se/kundklubb/\" target=\"_blank\" style=\"color: rgb(222, 238, 241);\">Kundklubb</a><a href=\"https://www.blomsterlandet.se/hitta-din-butik/\" target=\"_blank\" style=\"color: rgb(222, 238, 241);\">Våra butiker</a></p><p><img src=\"https://www.blomsterlandet.se/contentassets/309cef56f7d444a0abc60d61ec24da04/lavendelhack.jpg\"></p><p>Lavendel räknas som halvbuske, eftersom den blir förvedad, och är därför inte härdig i hela landet. Ju längre norrut man bor desto viktigare är det att välja ett soligt, varmt och framförallt väldränerat läge. Lavendel älskar torr jord, gärna sandblandad, sol och värme. Även om lavendel under gynnsamma former kan klara sig i zon 5 är det att rekommendera att i zon 3 och norrut plantera lavendeln i en upphöjd rabatt – eller i krukor som du vinterförvarar ljust och frostfritt.</p><p><br></p><p>Lavendel räknas också som medicinalväxt och har lugnande och kramplösande egenskaper. Lavendelblommor ger utsökt smak i olika sorters kakor, både i småkakor, skorpor och sockerkakor.</p><p>Främst är det doften vi tycker så mycket om, denna somriga doft som i fantasin tar oss med på resor till Provence och Toscana.</p>", new DateTime(2024, 11, 12, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6806), "images/posts/yujd3vy3.mmp.png", "Lavendel, Lavandula angustifolia, är en av de mest älskade trädgårdsväxterna. Alla bör unna sig lavendel, den trivs både i rabatten och sommarkrukan", true, true, new DateTime(2024, 11, 12, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6806), "lavendel", "Lavendel", null, 3 },
                    { 5, 3, "<p> https://www.w3schools.com/cs/index.php</p><h2>What is C#?</h2><p>C# is pronounced \"C-Sharp\".</p><p>It is an object-oriented programming language created by Microsoft that runs on the .NET Framework.</p><p>C# has roots from the C family, and the language is close to other popular languages like&nbsp;<a href=\"https://www.w3schools.com/cpp/default.asp\" target=\"_blank\" style=\"color: inherit;\">C++</a>&nbsp;and&nbsp;<a href=\"https://www.w3schools.com/java/default.asp\" target=\"_blank\" style=\"color: inherit;\">Java</a>.</p><p>The first version was released in year 2002. The latest version,&nbsp;<strong>C# 12</strong>, was released in November 2023.</p><p>C# is used for:</p><ul><li>Mobile applications</li><li>Desktop applications</li><li>Web applications</li><li>Web services</li><li>Web sites</li><li>Games</li><li>VR</li><li>Database applications</li><li>And much, much more!</li></ul><h2>Why Use C#?</h2><ul><li>It is one of the most popular programming languages in the world</li><li>It is easy to learn and simple to use</li><li>It has huge community support</li><li>C# is an object-oriented language which gives a clear structure to programs and allows code to be reused, lowering development costs</li><li>As C# is close to&nbsp;<a href=\"https://www.w3schools.com/c/index.php\" target=\"_blank\" style=\"color: inherit;\">C</a>,&nbsp;<a href=\"https://www.w3schools.com/cpp/default.asp\" target=\"_blank\" style=\"color: inherit;\">C++</a>&nbsp;and&nbsp;<a href=\"https://www.w3schools.com/java/default.asp\" target=\"_blank\" style=\"color: inherit;\">Java</a>, it makes it easy for programmers to switch to C# or vice versa</li></ul><h2>Get Started</h2><p>This tutorial will teach you the basics of C#.</p><p>It is not necessary to have any prior programming experience.</p>", new DateTime(2024, 11, 11, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6808), "images/posts/kcukikkw.lb3.png", "C# (C-Sharp) is a programming language developed by Microsoft that runs on the .NET", true, true, new DateTime(2024, 11, 11, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6809), "guide", "Guide", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "CertificationDays",
                columns: new[] { "Id", "CertSlotId", "Date", "IsCertDay" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2024, 11, 29), false },
                    { 2, 1, new DateOnly(2024, 11, 30), true },
                    { 3, 1, new DateOnly(2024, 12, 1), false },
                    { 4, 1, new DateOnly(2024, 12, 2), true },
                    { 5, 1, new DateOnly(2024, 12, 3), false },
                    { 6, 2, new DateOnly(2024, 12, 9), false },
                    { 7, 2, new DateOnly(2024, 12, 10), true },
                    { 8, 2, new DateOnly(2024, 12, 11), false },
                    { 9, 2, new DateOnly(2024, 12, 12), true },
                    { 10, 2, new DateOnly(2024, 12, 13), true },
                    { 11, 2, new DateOnly(2024, 12, 14), false },
                    { 12, 2, new DateOnly(2024, 12, 15), true },
                    { 13, 2, new DateOnly(2024, 12, 16), false },
                    { 14, 2, new DateOnly(2024, 12, 17), false },
                    { 15, 2, new DateOnly(2024, 12, 18), false }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BundleId", "CategoryId", "CertSlotId", "Description", "Name", "Price", "ProviderId", "Status" },
                values: new object[,]
                {
                    { 1, null, 1, 1, "Certificate in Sanctions Description....", "Certificate in Sanctions", 7200.0, 1, "Active" },
                    { 2, null, 1, null, "Certificate in Corporate Governance Description....", "Certificate in Corporate Governance", 8400.0, 1, "Active" },
                    { 3, 1, 1, null, "C# Certification Description...", "C# Certificate", 1000.0, 2, "Active" },
                    { 4, 1, 2, null, "C# Begginner Programming Description...", "C# Beginner", 200.0, 2, "Active" },
                    { 5, 1, 3, null, "C# Begginner Programming Description...", "C# Beginner", 300.0, 2, "Active" },
                    { 10, 1, 4, null, "C# Advanced Programming Description...", "C# for beginners, Bundle", 300.0, 2, "Active" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_BlogCategoryId",
                table: "BlogPosts",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_UserId",
                table: "BlogPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AppUserId",
                table: "Bookings",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_AppUserId",
                table: "Carts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationDays_CertSlotId",
                table: "CertificationDays",
                column: "CertSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_AppUserId",
                table: "OrderHeaders",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BundleId",
                table: "Products",
                column: "BundleId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CertSlotId",
                table: "Products",
                column: "CertSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProviderId",
                table: "Products",
                column: "ProviderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "BlogSubscribers");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "CertificationDays");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Bundles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CertificationSlots");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
