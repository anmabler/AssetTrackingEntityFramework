using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetTrackingEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Computers",
                columns: new[] { "Id", "Brand", "EndOfLife", "Model", "Price", "PurchaseDate" },
                values: new object[,]
                {
                    { 1, "Apple", new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "MacBook", 1500, new DateTime(2020, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Asus", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ROG 550", 900, new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Lenovo", new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "D300", 750, new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Brand", "EndOfLife", "Model", "Price", "PurchaseDate" },
                values: new object[,]
                {
                    { 1, "Apple", new DateTime(2026, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "IPhone 14", 1400, new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Samsung", new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Galaxy S20+", 1000, new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Nokia", new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "3310", 100, new DateTime(2021, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
