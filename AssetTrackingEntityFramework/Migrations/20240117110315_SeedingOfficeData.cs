using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetTrackingEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class SeedingOfficeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Phones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Computers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfficeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfficeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfficeId",
                value: null);

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Country", "Currency", "CurrencyRate" },
                values: new object[,]
                {
                    { 1, "Sweden", "SEK", 10.46f },
                    { 2, "USA", "USD", 1f },
                    { 3, "Iceland", "ISK", 137.4f }
                });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfficeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfficeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfficeId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_OfficeId",
                table: "Phones",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_OfficeId",
                table: "Computers",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Offices_OfficeId",
                table: "Computers",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Offices_OfficeId",
                table: "Phones",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Offices_OfficeId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Offices_OfficeId",
                table: "Phones");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropIndex(
                name: "IX_Phones_OfficeId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Computers_OfficeId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Computers");
        }
    }
}
