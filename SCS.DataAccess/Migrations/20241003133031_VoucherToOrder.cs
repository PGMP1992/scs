using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class VoucherToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VoucherKey",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Dates",
                table: "CertificationSlots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 11, 2, 15, 30, 31, 59, DateTimeKind.Local).AddTicks(9820), new DateTime(2024, 10, 3, 15, 30, 31, 59, DateTimeKind.Local).AddTicks(9819) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 2, 15, 30, 31, 59, DateTimeKind.Local).AddTicks(9890), new DateTime(2024, 10, 3, 15, 30, 31, 59, DateTimeKind.Local).AddTicks(9888) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoucherKey",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Dates",
                table: "CertificationSlots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }
    }
}
