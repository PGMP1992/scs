using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changedCertList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { new DateTime(2024, 11, 2, 13, 52, 16, 349, DateTimeKind.Local).AddTicks(8225), new DateTime(2024, 10, 3, 13, 52, 16, 349, DateTimeKind.Local).AddTicks(8224) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 2, 13, 52, 16, 349, DateTimeKind.Local).AddTicks(8248), new DateTime(2024, 10, 3, 13, 52, 16, 349, DateTimeKind.Local).AddTicks(8247) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Dates",
                table: "CertificationSlots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 11, 2, 13, 9, 47, 206, DateTimeKind.Local).AddTicks(176), new DateTime(2024, 10, 3, 13, 9, 47, 206, DateTimeKind.Local).AddTicks(174) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 2, 13, 9, 47, 206, DateTimeKind.Local).AddTicks(198), new DateTime(2024, 10, 3, 13, 9, 47, 206, DateTimeKind.Local).AddTicks(196) });
        }
    }
}
