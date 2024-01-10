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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedTime", "ModifiedTime", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 10, 21, 27, 21, 724, DateTimeKind.Local).AddTicks(3891), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000m, "Laptop" },
                    { 2, new DateTime(2024, 1, 10, 21, 27, 21, 724, DateTimeKind.Local).AddTicks(3897), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m, "Keyboard" },
                    { 3, new DateTime(2024, 1, 10, 21, 27, 21, 724, DateTimeKind.Local).AddTicks(3899), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, "Mouse" },
                    { 4, new DateTime(2024, 1, 10, 21, 27, 21, 724, DateTimeKind.Local).AddTicks(3901), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000m, "Monitor" },
                    { 5, new DateTime(2024, 1, 10, 21, 27, 21, 724, DateTimeKind.Local).AddTicks(3902), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500m, "Deck" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
