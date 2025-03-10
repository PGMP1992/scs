using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialZ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "BlogSubscribers");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "ContactEmail", "ContactName", "ContactPhone", "Name" },
                values: new object[] { 1001, "info@comptia.com", "CompTIA Contact Name", "555555", "CompTIA" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShowOnNavbar = table.Column<bool>(type: "bit", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
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
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogCategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Introduction = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "Name", "ShowOnNavbar", "Slug" },
                values: new object[,]
                {
                    { 1, "Lexicon", true, "lexicon" },
                    { 2, "SCS", true, "scs" },
                    { 3, "C#", false, "c-sharp" },
                    { 4, "ASP.NET Core#", true, "asp-net-core" },
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
                    { 15, "MVC", true, "mvc" }
                });

            migrationBuilder.InsertData(
                table: "CertificationSlots",
                columns: new[] { "Id", "Dates", "DayOfWeek", "EndDate", "Name", "ShowDays", "StartDate" },
                values: new object[,]
                {
                    { 1, "[\"2025-01-30\",\"2025-02-01\"]", null, new DateOnly(2025, 2, 2), "Sanctions", false, new DateOnly(2025, 1, 29) },
                    { 2, "[\"2025-02-09\",\"2025-02-12\",\"2025-02-14\"]", null, new DateOnly(2025, 2, 17), "C# Beginner", false, new DateOnly(2025, 2, 8) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BundleId", "CategoryId", "CertSlotId", "Description", "Name", "Price", "ProviderId", "Status" },
                values: new object[,]
                {
                    { 2, null, 1, null, "Certificate in Corporate Governance Description....", "Certificate in Corporate Governance", 8400.0, 1, "Active" },
                    { 3, 1, 1, null, "C# Certification Description...", "C# Certificate", 1000.0, 2, "Active" },
                    { 4, 1, 2, null, "C# Begginner Programming Description...", "C# Beginner", 200.0, 2, "Active" },
                    { 5, 1, 3, null, "C# Begginner Programming Description...", "C# Beginner", 300.0, 2, "Active" },
                    { 10, 1, 4, null, "C# Advanced Programming Description...", "C# for beginners, Bundle", 300.0, 2, "Active" }
                });

            migrationBuilder.InsertData(
                table: "CertificationDays",
                columns: new[] { "Id", "CertSlotId", "Date", "IsCertDay" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2025, 1, 29), false },
                    { 2, 1, new DateOnly(2025, 1, 30), true },
                    { 3, 1, new DateOnly(2025, 1, 31), false },
                    { 4, 1, new DateOnly(2025, 2, 1), true },
                    { 5, 1, new DateOnly(2025, 2, 2), false },
                    { 6, 2, new DateOnly(2025, 2, 8), false },
                    { 7, 2, new DateOnly(2025, 2, 9), true },
                    { 8, 2, new DateOnly(2025, 2, 10), false },
                    { 9, 2, new DateOnly(2025, 2, 11), true },
                    { 10, 2, new DateOnly(2025, 2, 12), true },
                    { 11, 2, new DateOnly(2025, 2, 13), false },
                    { 12, 2, new DateOnly(2025, 2, 14), true },
                    { 13, 2, new DateOnly(2025, 2, 15), false },
                    { 14, 2, new DateOnly(2025, 2, 16), false },
                    { 15, 2, new DateOnly(2025, 2, 17), false }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BundleId", "CategoryId", "CertSlotId", "Description", "Name", "Price", "ProviderId", "Status" },
                values: new object[] { 1, null, 1, 1, "Certificate in Sanctions Description....", "Certificate in Sanctions", 7200.0, 1, "Active" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_BlogCategoryId",
                table: "BlogPosts",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_UserId",
                table: "BlogPosts",
                column: "UserId");
        }
    }
}
