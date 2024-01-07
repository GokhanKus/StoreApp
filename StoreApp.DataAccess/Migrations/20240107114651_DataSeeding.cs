using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedTime", "ModifiedTime", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 7, 14, 46, 50, 924, DateTimeKind.Local).AddTicks(7659), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000m, "Laptop" },
                    { 2, new DateTime(2024, 1, 7, 14, 46, 50, 924, DateTimeKind.Local).AddTicks(7663), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m, "Keyboard" },
                    { 3, new DateTime(2024, 1, 7, 14, 46, 50, 924, DateTimeKind.Local).AddTicks(7665), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, "Mouse" },
                    { 4, new DateTime(2024, 1, 7, 14, 46, 50, 924, DateTimeKind.Local).AddTicks(7666), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000m, "Monitor" },
                    { 5, new DateTime(2024, 1, 7, 14, 46, 50, 924, DateTimeKind.Local).AddTicks(7668), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500m, "Deck" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
