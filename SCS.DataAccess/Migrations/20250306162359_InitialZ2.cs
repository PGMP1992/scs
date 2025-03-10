using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialZ2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.InsertData(
                table: "CertificationSlots",
                columns: new[] { "Id", "Dates", "DayOfWeek", "EndDate", "Name", "ShowDays", "StartDate" },
                values: new object[,]
                {
                    { 1, "[\"2025-03-17\",\"2025-03-19\"]", null, new DateOnly(2025, 3, 20), "Sanctions", false, new DateOnly(2025, 3, 16) },
                    { 2, "[\"2025-03-27\",\"2025-03-30\",\"2025-04-01\"]", null, new DateOnly(2025, 4, 4), "C# Beginner", false, new DateOnly(2025, 3, 26) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BundleId", "CategoryId", "CertSlotId", "Description", "Name", "Price", "ProviderId", "Status" },
                values: new object[,]
                {
                    { 1, null, 1, null, "Certificate in Sanctions Description....", "Certificate in Sanctions", 7200.0, 1, "Active" },
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
                    { 1, 1, new DateOnly(2025, 3, 16), false },
                    { 2, 1, new DateOnly(2025, 3, 17), true },
                    { 3, 1, new DateOnly(2025, 3, 18), false },
                    { 4, 1, new DateOnly(2025, 3, 19), true },
                    { 5, 1, new DateOnly(2025, 3, 20), false },
                    { 6, 2, new DateOnly(2025, 3, 26), false },
                    { 7, 2, new DateOnly(2025, 3, 27), true },
                    { 8, 2, new DateOnly(2025, 3, 28), false },
                    { 9, 2, new DateOnly(2025, 3, 29), true },
                    { 10, 2, new DateOnly(2025, 3, 30), true },
                    { 11, 2, new DateOnly(2025, 3, 31), false },
                    { 12, 2, new DateOnly(2025, 4, 1), true },
                    { 13, 2, new DateOnly(2025, 4, 2), false },
                    { 14, 2, new DateOnly(2025, 4, 3), false },
                    { 15, 2, new DateOnly(2025, 4, 4), false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
