using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedVoucherKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 11, 2, 15, 21, 31, 127, DateTimeKind.Local).AddTicks(8233), new DateTime(2024, 10, 3, 15, 21, 31, 127, DateTimeKind.Local).AddTicks(8231) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 2, 15, 21, 31, 127, DateTimeKind.Local).AddTicks(8250), new DateTime(2024, 10, 3, 15, 21, 31, 127, DateTimeKind.Local).AddTicks(8249) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "VoucherKey",
                value: "0f8fad5b-d9cb-469f-a165-70867728950e");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "VoucherKey",
                value: "7c9e6679-7425-40de-944b-e07fc1f90ae7");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "VoucherKey",
                value: "9x9e5429-7125-299c-v09fd1390bd3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 11, 2, 14, 39, 47, 727, DateTimeKind.Local).AddTicks(5652), new DateTime(2024, 10, 3, 14, 39, 47, 727, DateTimeKind.Local).AddTicks(5650) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 2, 14, 39, 47, 727, DateTimeKind.Local).AddTicks(5668), new DateTime(2024, 10, 3, 14, 39, 47, 727, DateTimeKind.Local).AddTicks(5667) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "VoucherKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "VoucherKey",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "VoucherKey",
                value: null);
        }
    }
}
