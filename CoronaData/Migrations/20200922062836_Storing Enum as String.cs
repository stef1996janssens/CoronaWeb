using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaData.Migrations
{
    public partial class StoringEnumasString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Producten",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "mondmasker");

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "mondmasker");

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "mondmasker");

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: "mondmasker");

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: "handgel");

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: "handgel");

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 7,
                column: "Type",
                value: "ontsmettingsalcohol");

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 8,
                column: "Type",
                value: "ontsmettingsalcohol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Producten",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 6,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 7,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 8,
                column: "Type",
                value: 2);
        }
    }
}
