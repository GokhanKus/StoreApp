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
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Line1 = table.Column<string>(type: "TEXT", nullable: false),
                    Line2 = table.Column<string>(type: "TEXT", nullable: true),
                    Line3 = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    GiftWrap = table.Column<bool>(type: "INTEGER", nullable: false),
                    Shipped = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
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
                    ShowCase = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "CartLine",
                columns: table => new
                {
                    CartLineId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLine", x => x.CartLineId);
                    table.ForeignKey(
                        name: "FK_CartLine_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartLine_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedTime" },
                values: new object[,]
                {
                    { 1, "Book", new DateTime(2024, 1, 28, 13, 20, 7, 54, DateTimeKind.Local).AddTicks(9017) },
                    { 2, "Electronic", new DateTime(2024, 1, 28, 13, 20, 7, 54, DateTimeKind.Local).AddTicks(9020) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedTime", "ImageUrl", "Price", "ProductName", "ShowCase", "Summary" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 1, 28, 13, 20, 7, 55, DateTimeKind.Local).AddTicks(458), "1.jpg", 30000m, "Laptop", false, "" },
                    { 2, 2, new DateTime(2024, 1, 28, 13, 20, 7, 55, DateTimeKind.Local).AddTicks(461), "2.jpg", 1000m, "Keyboard", false, "" },
                    { 3, 2, new DateTime(2024, 1, 28, 13, 20, 7, 55, DateTimeKind.Local).AddTicks(464), "3.jpg", 500m, "Mouse", false, "" },
                    { 4, 2, new DateTime(2024, 1, 28, 13, 20, 7, 55, DateTimeKind.Local).AddTicks(516), "4.jpg", 5000m, "Monitor", false, "" },
                    { 5, 2, new DateTime(2024, 1, 28, 13, 20, 7, 55, DateTimeKind.Local).AddTicks(518), "5.jpg", 1500m, "Deck", false, "" },
                    { 6, 1, new DateTime(2024, 1, 28, 13, 20, 7, 55, DateTimeKind.Local).AddTicks(520), "6.jpg", 165m, "Guns, Germs and Steel", false, "" },
                    { 7, 1, new DateTime(2024, 1, 28, 13, 20, 7, 55, DateTimeKind.Local).AddTicks(522), "7.jpg", 45m, "1984", false, "" },
                    { 8, 2, new DateTime(2024, 1, 28, 13, 20, 7, 55, DateTimeKind.Local).AddTicks(524), "8.jpg", 450m, "Xp-Pen", true, "" },
                    { 9, 2, new DateTime(2024, 1, 28, 13, 20, 7, 55, DateTimeKind.Local).AddTicks(526), "9.jpg", 15000m, "Galaxy FE", true, "" },
                    { 10, 2, new DateTime(2024, 1, 28, 13, 20, 7, 55, DateTimeKind.Local).AddTicks(528), "10.jpg", 400m, "Hp Mouse", true, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_OrderId",
                table: "CartLine",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_ProductId",
                table: "CartLine",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartLine");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
