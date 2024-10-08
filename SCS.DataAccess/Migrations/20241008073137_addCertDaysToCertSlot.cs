using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addCertDaysToCertSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateOnly(2024, 10, 18));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateOnly(2024, 10, 19));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateOnly(2024, 10, 20));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateOnly(2024, 10, 21));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateOnly(2024, 10, 22));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateOnly(2024, 10, 28));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateOnly(2024, 10, 29));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateOnly(2024, 10, 30));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateOnly(2024, 10, 31));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateOnly(2024, 11, 1));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateOnly(2024, 11, 2));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateOnly(2024, 11, 3));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateOnly(2024, 11, 4));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateOnly(2024, 11, 5));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateOnly(2024, 11, 6));

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Dates", "EndDate", "StartDate" },
                values: new object[] { "[\"2024-10-19\",\"2024-10-21\"]", new DateOnly(2024, 10, 22), new DateOnly(2024, 10, 18) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Dates", "EndDate", "StartDate" },
                values: new object[] { "[\"2024-10-29\",\"2024-11-01\",\"2024-11-03\"]", new DateOnly(2024, 11, 6), new DateOnly(2024, 10, 28) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateOnly(2024, 10, 17));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateOnly(2024, 10, 18));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateOnly(2024, 10, 19));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateOnly(2024, 10, 20));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateOnly(2024, 10, 21));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateOnly(2024, 10, 27));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateOnly(2024, 10, 28));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateOnly(2024, 10, 29));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateOnly(2024, 10, 30));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateOnly(2024, 10, 31));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateOnly(2024, 11, 1));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateOnly(2024, 11, 2));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateOnly(2024, 11, 3));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateOnly(2024, 11, 4));

            migrationBuilder.UpdateData(
                table: "CertificationDay",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateOnly(2024, 11, 5));

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Dates", "EndDate", "StartDate" },
                values: new object[] { "[\"2024-10-18\",\"2024-10-20\"]", new DateOnly(2024, 10, 21), new DateOnly(2024, 10, 17) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Dates", "EndDate", "StartDate" },
                values: new object[] { "[\"2024-10-28\",\"2024-10-31\",\"2024-11-02\"]", new DateOnly(2024, 11, 5), new DateOnly(2024, 10, 27) });
        }
    }
}
