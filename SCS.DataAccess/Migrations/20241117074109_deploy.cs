using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class deploy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductId2",
                table: "Bundles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId1",
                table: "Bundles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateOnly(2024, 11, 27));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateOnly(2024, 11, 28));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateOnly(2024, 11, 29));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateOnly(2024, 11, 30));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateOnly(2024, 12, 1));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateOnly(2024, 12, 7));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateOnly(2024, 12, 8));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateOnly(2024, 12, 9));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateOnly(2024, 12, 10));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateOnly(2024, 12, 11));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateOnly(2024, 12, 12));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateOnly(2024, 12, 13));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateOnly(2024, 12, 14));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateOnly(2024, 12, 15));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateOnly(2024, 12, 16));

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Dates", "EndDate", "StartDate" },
                values: new object[] { "[\"2024-11-28\",\"2024-11-30\"]", new DateOnly(2024, 12, 1), new DateOnly(2024, 11, 27) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Dates", "EndDate", "StartDate" },
                values: new object[] { "[\"2024-12-08\",\"2024-12-11\",\"2024-12-13\"]", new DateOnly(2024, 12, 16), new DateOnly(2024, 12, 7) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductId2",
                table: "Bundles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId1",
                table: "Bundles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateOnly(2024, 11, 16));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateOnly(2024, 11, 17));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateOnly(2024, 11, 18));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateOnly(2024, 11, 19));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateOnly(2024, 11, 20));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateOnly(2024, 11, 26));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateOnly(2024, 11, 27));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateOnly(2024, 11, 28));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateOnly(2024, 11, 29));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateOnly(2024, 11, 30));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateOnly(2024, 12, 1));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateOnly(2024, 12, 2));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateOnly(2024, 12, 3));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateOnly(2024, 12, 4));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateOnly(2024, 12, 5));

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Dates", "EndDate", "StartDate" },
                values: new object[] { "[\"2024-11-17\",\"2024-11-19\"]", new DateOnly(2024, 11, 20), new DateOnly(2024, 11, 16) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Dates", "EndDate", "StartDate" },
                values: new object[] { "[\"2024-11-27\",\"2024-11-30\",\"2024-12-02\"]", new DateOnly(2024, 12, 5), new DateOnly(2024, 11, 26) });
        }
    }
}
