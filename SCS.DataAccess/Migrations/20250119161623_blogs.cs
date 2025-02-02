using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class blogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShowOnNavbar",
                value: false);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ShowOnNavbar",
                value: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "ShowOnNavbar",
                value: true);

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateOnly(2025, 1, 29));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateOnly(2025, 1, 30));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateOnly(2025, 1, 31));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateOnly(2025, 2, 1));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateOnly(2025, 2, 2));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 6,
                column: "Date",
                value: new DateOnly(2025, 2, 8));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 7,
                column: "Date",
                value: new DateOnly(2025, 2, 9));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 8,
                column: "Date",
                value: new DateOnly(2025, 2, 10));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 9,
                column: "Date",
                value: new DateOnly(2025, 2, 11));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 10,
                column: "Date",
                value: new DateOnly(2025, 2, 12));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 11,
                column: "Date",
                value: new DateOnly(2025, 2, 13));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 12,
                column: "Date",
                value: new DateOnly(2025, 2, 14));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 13,
                column: "Date",
                value: new DateOnly(2025, 2, 15));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 14,
                column: "Date",
                value: new DateOnly(2025, 2, 16));

            migrationBuilder.UpdateData(
                table: "CertificationDays",
                keyColumn: "Id",
                keyValue: 15,
                column: "Date",
                value: new DateOnly(2025, 2, 17));

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Dates", "EndDate", "StartDate" },
                values: new object[] { "[\"2025-01-30\",\"2025-02-01\"]", new DateOnly(2025, 2, 2), new DateOnly(2025, 1, 29) });

            migrationBuilder.UpdateData(
                table: "CertificationSlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Dates", "EndDate", "StartDate" },
                values: new object[] { "[\"2025-02-09\",\"2025-02-12\",\"2025-02-14\"]", new DateOnly(2025, 2, 17), new DateOnly(2025, 2, 8) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShowOnNavbar",
                value: true);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ShowOnNavbar",
                value: false);

            migrationBuilder.UpdateData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "ShowOnNavbar",
                value: false);

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "Name", "ShowOnNavbar", "Slug" },
                values: new object[] { 16, "Blommor", true, "blommor" });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "BlogCategoryId", "Content", "CreatedAt", "Image", "Introduction", "IsFeatured", "IsPublished", "PublishedAt", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { 1, 2, "<p> besök den https:\\scservices.se</p>", new DateTime(2024, 11, 18, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2769), "images/posts/lwbsypfb.rxe.png", "scservices har fått en ny mensida", true, true, new DateTime(2024, 11, 18, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2770), "ny-hemsida", "Ny hemsida", null, 2 },
                    { 2, 1, "<p> Du hittar oss på Södergatan 24 mellan Stortorget och Gustav Adolfs Torg. Cirka 10 minuter gångväg från Centralstationen. Ingång mellan Stadium och Indiska.</p><p>Varmt välkommen att kontakta oss för mer information&nbsp;om våra erbjudanden och bokning.</p>", new DateTime(2024, 11, 17, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2775), "images/posts/e41eigqw.de2.png", "Här finns vi", true, true, new DateTime(2024, 11, 17, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2776), "ny-hemsida", "Lexicon i Malmö", null, 4 },
                    { 5, 3, "<p> https://www.w3schools.com/cs/index.php</p><h2>What is C#?</h2><p>C# is pronounced \"C-Sharp\".</p><p>It is an object-oriented programming language created by Microsoft that runs on the .NET Framework.</p><p>C# has roots from the C family, and the language is close to other popular languages like&nbsp;<a href=\"https://www.w3schools.com/cpp/default.asp\" target=\"_blank\" style=\"color: inherit;\">C++</a>&nbsp;and&nbsp;<a href=\"https://www.w3schools.com/java/default.asp\" target=\"_blank\" style=\"color: inherit;\">Java</a>.</p><p>The first version was released in year 2002. The latest version,&nbsp;<strong>C# 12</strong>, was released in November 2023.</p><p>C# is used for:</p><ul><li>Mobile applications</li><li>Desktop applications</li><li>Web applications</li><li>Web services</li><li>Web sites</li><li>Games</li><li>VR</li><li>Database applications</li><li>And much, much more!</li></ul><h2>Why Use C#?</h2><ul><li>It is one of the most popular programming languages in the world</li><li>It is easy to learn and simple to use</li><li>It has huge community support</li><li>C# is an object-oriented language which gives a clear structure to programs and allows code to be reused, lowering development costs</li><li>As C# is close to&nbsp;<a href=\"https://www.w3schools.com/c/index.php\" target=\"_blank\" style=\"color: inherit;\">C</a>,&nbsp;<a href=\"https://www.w3schools.com/cpp/default.asp\" target=\"_blank\" style=\"color: inherit;\">C++</a>&nbsp;and&nbsp;<a href=\"https://www.w3schools.com/java/default.asp\" target=\"_blank\" style=\"color: inherit;\">Java</a>, it makes it easy for programmers to switch to C# or vice versa</li></ul><h2>Get Started</h2><p>This tutorial will teach you the basics of C#.</p><p>It is not necessary to have any prior programming experience.</p>", new DateTime(2024, 11, 13, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2782), "images/posts/kcukikkw.lb3.png", "C# (C-Sharp) is a programming language developed by Microsoft that runs on the .NET", true, true, new DateTime(2024, 11, 13, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2783), "guide", "Guide", null, 1 }
                });

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

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "BlogCategoryId", "Content", "CreatedAt", "Image", "Introduction", "IsFeatured", "IsPublished", "PublishedAt", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { 3, 16, "<p> <span style=\"color: rgb(71, 71, 71);\">Floribundarosor, en grupp rosor med mycket komplext ursprung. Grunden till gruppen utgörs av korsningar mellan polyantarosor och rosor i andra grupper. Gruppen inkluderar även produktnamn som miniflorarosor, castlerosor och palacerosor. Motsvarar beteckningarna Floribunda och Climbing Floribunda i Modern Roses 11.&nbsp;</span><a href=\"https://sv.wikipedia.org/wiki/Floribundarosor\" target=\"_blank\" style=\"color: var(--JKqx2);\">Wikipedia</a></p>", new DateTime(2024, 11, 20, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2778), "images/posts/u1q4qomy.loi.png", "Rikblommande rosor - floribunda", true, true, new DateTime(2024, 11, 20, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2778), "rosor", "Rosor", null, 5 },
                    { 4, 16, "<p><strong style=\"color: rgb(95, 99, 104);\">Lavendel</strong><span style=\"color: rgb(77, 81, 86);\">, Lavandula angustifolia, är en av de mest älskade trädgårdsväxterna. Alla bör unna sig&nbsp;</span><strong style=\"color: rgb(95, 99, 104);\">lavendel</strong><span style=\"color: rgb(77, 81, 86);\">, den trivs både i rabatten och sommarkrukan</span></p><p><br></p><p><a href=\"https://www.blomsterlandet.se/kundklubb/\" target=\"_blank\" style=\"color: rgb(222, 238, 241);\">Kundklubb</a><a href=\"https://www.blomsterlandet.se/hitta-din-butik/\" target=\"_blank\" style=\"color: rgb(222, 238, 241);\">Våra butiker</a></p><p><img src=\"https://www.blomsterlandet.se/contentassets/309cef56f7d444a0abc60d61ec24da04/lavendelhack.jpg\"></p><p>Lavendel räknas som halvbuske, eftersom den blir förvedad, och är därför inte härdig i hela landet. Ju längre norrut man bor desto viktigare är det att välja ett soligt, varmt och framförallt väldränerat läge. Lavendel älskar torr jord, gärna sandblandad, sol och värme. Även om lavendel under gynnsamma former kan klara sig i zon 5 är det att rekommendera att i zon 3 och norrut plantera lavendeln i en upphöjd rabatt – eller i krukor som du vinterförvarar ljust och frostfritt.</p><p><br></p><p>Lavendel räknas också som medicinalväxt och har lugnande och kramplösande egenskaper. Lavendelblommor ger utsökt smak i olika sorters kakor, både i småkakor, skorpor och sockerkakor.</p><p>Främst är det doften vi tycker så mycket om, denna somriga doft som i fantasin tar oss med på resor till Provence och Toscana.</p>", new DateTime(2024, 11, 14, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2780), "images/posts/yujd3vy3.mmp.png", "Lavendel, Lavandula angustifolia, är en av de mest älskade trädgårdsväxterna. Alla bör unna sig lavendel, den trivs både i rabatten och sommarkrukan", true, true, new DateTime(2024, 11, 14, 11, 11, 58, 789, DateTimeKind.Local).AddTicks(2781), "lavendel", "Lavendel", null, 3 }
                });
        }
    }
}
