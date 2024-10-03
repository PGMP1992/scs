using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class nameToSlots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CertificationSlots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Name", "StartDate" },
                values: new object[] { new DateTime(2024, 11, 2, 14, 27, 23, 209, DateTimeKind.Local).AddTicks(6287), "Slot1", new DateTime(2024, 10, 3, 14, 27, 23, 209, DateTimeKind.Local).AddTicks(6285) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "Name", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 2, 14, 27, 23, 209, DateTimeKind.Local).AddTicks(6306), "Slot2", new DateTime(2024, 10, 3, 14, 27, 23, 209, DateTimeKind.Local).AddTicks(6304) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CertificationSlots");

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
    }
}
