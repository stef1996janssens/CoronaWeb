using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaData.Migrations
{
    public partial class Seedingproducten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Klanten");

            migrationBuilder.InsertData(
                table: "Producten",
                columns: new[] { "Id", "Naam", "Prijs", "Type" },
                values: new object[,]
                {
                    { 1, "Mondmasker Herbruikbaar Zwart", 4.99m, 0 },
                    { 2, "Mondmasker Herbruikbaar Wit", 4.99m, 0 },
                    { 3, "Wegwerp Mondmasker 5 stuks", 4.75m, 0 },
                    { 4, "Wegwerp Mondmasker 10 stuks", 7.5m, 0 },
                    { 5, "HandSanitizer 150ml", 4.0m, 1 },
                    { 6, "HandSanitizer 500ml", 9.95m, 1 },
                    { 7, "Ontsmettingsalcohol 70% 250ml", 6.0m, 2 },
                    { 8, "Ontsmettingsalcohol 90% 250ml", 12.5m, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Klanten",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
