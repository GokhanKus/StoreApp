using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreAppUI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Summary = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedTime", "ModifiedTime" },
                values: new object[,]
                {
                    { 1, "Book", new DateTime(2024, 1, 19, 12, 57, 29, 821, DateTimeKind.Local).AddTicks(9601), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Electronic", new DateTime(2024, 1, 19, 12, 57, 29, 821, DateTimeKind.Local).AddTicks(9604), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedTime", "ImageUrl", "ModifiedTime", "Price", "ProductName", "Summary" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 1, 19, 12, 57, 29, 822, DateTimeKind.Local).AddTicks(1111), "1.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000m, "Laptop", "" },
                    { 2, 2, new DateTime(2024, 1, 19, 12, 57, 29, 822, DateTimeKind.Local).AddTicks(1113), "2.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m, "Keyboard", "" },
                    { 3, 2, new DateTime(2024, 1, 19, 12, 57, 29, 822, DateTimeKind.Local).AddTicks(1188), "3.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, "Mouse", "" },
                    { 4, 2, new DateTime(2024, 1, 19, 12, 57, 29, 822, DateTimeKind.Local).AddTicks(1190), "4.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000m, "Monitor", "" },
                    { 5, 2, new DateTime(2024, 1, 19, 12, 57, 29, 822, DateTimeKind.Local).AddTicks(1192), "5.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500m, "Deck", "" },
                    { 6, 1, new DateTime(2024, 1, 19, 12, 57, 29, 822, DateTimeKind.Local).AddTicks(1193), "6.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 165m, "Guns, Germs and Steel", "" },
                    { 7, 1, new DateTime(2024, 1, 19, 12, 57, 29, 822, DateTimeKind.Local).AddTicks(1195), "7.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45m, "1984", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
