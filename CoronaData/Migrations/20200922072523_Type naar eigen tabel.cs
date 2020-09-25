using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaData.Migrations
{
    public partial class Typenaareigentabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Producten");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Producten",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Naam" },
                values: new object[] { 1, "Mondmasker" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Naam" },
                values: new object[] { 2, "Handsanitizer" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Naam" },
                values: new object[] { 3, "OntsmettingsAlcohol" });

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 1,
                column: "TypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 2,
                column: "TypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 3,
                column: "TypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 4,
                column: "TypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 5,
                column: "TypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 6,
                column: "TypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 7,
                column: "TypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 8,
                column: "TypeId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Producten_TypeId",
                table: "Producten",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Type_Product",
                table: "Producten",
                column: "TypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Type_Product",
                table: "Producten");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_Producten_TypeId",
                table: "Producten");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Producten");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Producten",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
