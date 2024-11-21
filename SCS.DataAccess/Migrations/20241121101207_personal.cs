using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class personal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2024, 11, 18, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2769), new DateTime(2024, 11, 18, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2770) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2024, 11, 17, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2775), new DateTime(2024, 11, 17, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2776) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2024, 11, 20, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2778), new DateTime(2024, 11, 20, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2778) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2024, 11, 14, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2780), new DateTime(2024, 11, 14, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2781) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2024, 11, 13, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2782), new DateTime(2024, 11, 13, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2783) });

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateOnly(2024, 12, 1));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateOnly(2024, 12, 2));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateOnly(2024, 12, 3));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateOnly(2024, 12, 4));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateOnly(2024, 12, 5));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateOnly(2024, 12, 11));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateOnly(2024, 12, 12));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateOnly(2024, 12, 13));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateOnly(2024, 12, 14));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateOnly(2024, 12, 15));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateOnly(2024, 12, 16));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateOnly(2024, 12, 17));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateOnly(2024, 12, 18));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateOnly(2024, 12, 19));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateOnly(2024, 12, 20));

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Dates", "EndDate", "StartDate" },
                values: new object[] { "[\"2024-12-02\",\"2024-12-04\"]", new DateOnly(2024, 12, 5), new DateOnly(2024, 12, 1) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Dates", "EndDate", "StartDate" },
                values: new object[] { "[\"2024-12-12\",\"2024-12-15\",\"2024-12-17\"]", new DateOnly(2024, 12, 20), new DateOnly(2024, 12, 11) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2024, 11, 16, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6795), new DateTime(2024, 11, 16, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6795) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2024, 11, 15, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6801), new DateTime(2024, 11, 15, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6801) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2024, 11, 18, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6803), new DateTime(2024, 11, 18, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6804) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2024, 11, 12, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6806), new DateTime(2024, 11, 12, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6806) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2024, 11, 11, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6808), new DateTime(2024, 11, 11, 15, 16, 7, 190, DateTimeKind.Local).AddTicks(6809) });

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateOnly(2024, 11, 29));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateOnly(2024, 11, 30));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateOnly(2024, 12, 1));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateOnly(2024, 12, 2));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateOnly(2024, 12, 3));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateOnly(2024, 12, 9));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateOnly(2024, 12, 10));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateOnly(2024, 12, 11));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateOnly(2024, 12, 12));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateOnly(2024, 12, 13));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateOnly(2024, 12, 14));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateOnly(2024, 12, 15));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateOnly(2024, 12, 16));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateOnly(2024, 12, 17));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateOnly(2024, 12, 18));

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Dates", "EndDate", "StartDate" },
                values: new object[] { "[\"2024-11-30\",\"2024-12-02\"]", new DateOnly(2024, 12, 3), new DateOnly(2024, 11, 29) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Dates", "EndDate", "StartDate" },
                values: new object[] { "[\"2024-12-10\",\"2024-12-13\",\"2024-12-15\"]", new DateOnly(2024, 12, 18), new DateOnly(2024, 12, 9) });
        }
    }
}
