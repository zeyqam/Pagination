using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello_PB101.Migrations
{
    public partial class CreatedSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SofDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "Key", "SofDeleted", "Value" },
                values: new object[] { 1, new DateTime(2024, 5, 22, 6, 28, 21, 643, DateTimeKind.Local).AddTicks(3329), "Header logo", false, "logo.png" });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "Key", "SofDeleted", "Value" },
                values: new object[] { 2, new DateTime(2024, 5, 22, 6, 28, 21, 643, DateTimeKind.Local).AddTicks(3333), "Phone", false, "3456688" });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedDate", "Key", "SofDeleted", "Value" },
                values: new object[] { 3, new DateTime(2024, 5, 22, 6, 28, 21, 643, DateTimeKind.Local).AddTicks(3336), "Address", false, "Ehmedli" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreatedDate", "Description", "Image", "SofDeleted", "Title" },
                values: new object[] { 1, new DateTime(2024, 5, 22, 3, 5, 42, 345, DateTimeKind.Local).AddTicks(7205), "Reshadin blogu", "blog-feature-img-1.jpg", false, "Title1" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreatedDate", "Description", "Image", "SofDeleted", "Title" },
                values: new object[] { 2, new DateTime(2024, 5, 22, 3, 5, 42, 345, DateTimeKind.Local).AddTicks(7208), "Ilqarin blogu", "blog-feature-img-3.jpg", false, "Title2" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreatedDate", "Description", "Image", "SofDeleted", "Title" },
                values: new object[] { 3, new DateTime(2024, 5, 22, 3, 5, 42, 345, DateTimeKind.Local).AddTicks(7209), "Hacixanin blogu", "blog-feature-img-4.jpg", false, "Title3" });
        }
    }
}
