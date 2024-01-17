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
                    { 1, "Book", new DateTime(2024, 1, 17, 20, 21, 46, 929, DateTimeKind.Local).AddTicks(2539), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Electronic", new DateTime(2024, 1, 17, 20, 21, 46, 929, DateTimeKind.Local).AddTicks(2546), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedTime", "ModifiedTime", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 17, 20, 21, 46, 929, DateTimeKind.Local).AddTicks(3999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000m, "Laptop" },
                    { 2, 1, new DateTime(2024, 1, 17, 20, 21, 46, 929, DateTimeKind.Local).AddTicks(4003), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m, "Keyboard" },
                    { 3, 1, new DateTime(2024, 1, 17, 20, 21, 46, 929, DateTimeKind.Local).AddTicks(4005), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, "Mouse" },
                    { 4, 1, new DateTime(2024, 1, 17, 20, 21, 46, 929, DateTimeKind.Local).AddTicks(4007), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000m, "Monitor" },
                    { 5, 1, new DateTime(2024, 1, 17, 20, 21, 46, 929, DateTimeKind.Local).AddTicks(4008), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500m, "Deck" },
                    { 6, 2, new DateTime(2024, 1, 17, 20, 21, 46, 929, DateTimeKind.Local).AddTicks(4010), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55m, "History" },
                    { 7, 2, new DateTime(2024, 1, 17, 20, 21, 46, 929, DateTimeKind.Local).AddTicks(4012), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45m, "Hamlet" }
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
