using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaData.Migrations
{
    public partial class TypenaarSoortwijzigen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "SoortId",
                table: "Producten",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductSoorten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSoorten", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProductSoorten",
                columns: new[] { "Id", "Naam" },
                values: new object[] { 1, "Mondmasker" });

            migrationBuilder.InsertData(
                table: "ProductSoorten",
                columns: new[] { "Id", "Naam" },
                values: new object[] { 2, "Handsanitizer" });

            migrationBuilder.InsertData(
                table: "ProductSoorten",
                columns: new[] { "Id", "Naam" },
                values: new object[] { 3, "OntsmettingsAlcohol" });

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 1,
                column: "SoortId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 2,
                column: "SoortId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 3,
                column: "SoortId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 4,
                column: "SoortId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 5,
                column: "SoortId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 6,
                column: "SoortId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 7,
                column: "SoortId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Producten",
                keyColumn: "Id",
                keyValue: 8,
                column: "SoortId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Producten_SoortId",
                table: "Producten",
                column: "SoortId");

            migrationBuilder.AddForeignKey(
                name: "FK_Soort_Product",
                table: "Producten",
                column: "SoortId",
                principalTable: "ProductSoorten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soort_Product",
                table: "Producten");

            migrationBuilder.DropTable(
                name: "ProductSoorten");

            migrationBuilder.DropIndex(
                name: "IX_Producten_SoortId",
                table: "Producten");

            migrationBuilder.DropColumn(
                name: "SoortId",
                table: "Producten");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Producten",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
    }
}
