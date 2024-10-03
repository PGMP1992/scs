using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addjustCertAndProductModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 11, 2, 14, 36, 42, 63, DateTimeKind.Local).AddTicks(4601), new DateTime(2024, 10, 3, 14, 36, 42, 63, DateTimeKind.Local).AddTicks(4599) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 2, 14, 36, 42, 63, DateTimeKind.Local).AddTicks(4617), new DateTime(2024, 10, 3, 14, 36, 42, 63, DateTimeKind.Local).AddTicks(4616) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CertSlotId",
                table: "Products",
                column: "CertSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CertificationSlots_CertSlotId",
                table: "Products",
                column: "CertSlotId",
                principalTable: "CertificationSlots",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CertificationSlots_CertSlotId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CertSlotId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 11, 2, 14, 27, 23, 209, DateTimeKind.Local).AddTicks(6287), new DateTime(2024, 10, 3, 14, 27, 23, 209, DateTimeKind.Local).AddTicks(6285) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 2, 14, 27, 23, 209, DateTimeKind.Local).AddTicks(6306), new DateTime(2024, 10, 3, 14, 27, 23, 209, DateTimeKind.Local).AddTicks(6304) });
        }
    }
}
