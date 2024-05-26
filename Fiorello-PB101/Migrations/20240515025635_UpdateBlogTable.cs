using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello_PB101.Migrations
{
    public partial class UpdateBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 6, 56, 35, 108, DateTimeKind.Local).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Image" },
                values: new object[] { new DateTime(2024, 5, 15, 6, 56, 35, 108, DateTimeKind.Local).AddTicks(2658), "blog-feature-img-3.jpg" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Image" },
                values: new object[] { new DateTime(2024, 5, 15, 6, 56, 35, 108, DateTimeKind.Local).AddTicks(2662), "blog-feature-img-4.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 15, 6, 28, 40, 125, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Image" },
                values: new object[] { new DateTime(2024, 5, 15, 6, 28, 40, 125, DateTimeKind.Local).AddTicks(8151), "blog-feature-img-2.jpg" });

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Image" },
                values: new object[] { new DateTime(2024, 5, 15, 6, 28, 40, 125, DateTimeKind.Local).AddTicks(8156), "blog-feature-img-3.jpg" });
        }
    }
}
