using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gemeenten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 50, nullable: false),
                    Postcode = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gemeenten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producten",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(maxLength: 50, nullable: false),
                    Prijs = table.Column<decimal>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adressen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GemeenteId = table.Column<int>(nullable: false),
                    Straatnaam = table.Column<string>(maxLength: 50, nullable: false),
                    Huisnr = table.Column<string>(maxLength: 7, nullable: false),
                    Bus = table.Column<string>(maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adressen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gemeente_Adres",
                        column: x => x.GemeenteId,
                        principalTable: "Gemeenten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    Klantnr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Familienaam = table.Column<string>(maxLength: 50, nullable: true),
                    Voornaam = table.Column<string>(maxLength: 50, nullable: true),
                    Telefoonnr = table.Column<string>(maxLength: 15, nullable: true),
                    Gsmnr = table.Column<string>(maxLength: 15, nullable: true),
                    AdresId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.Klantnr);
                    table.ForeignKey(
                        name: "FK_Klanten_Adressen_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adressen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locaties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    AdresId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locaties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locaties_Adressen_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adressen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bestellingen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellingen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klant_Bestelling",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Klantnr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bestellijnen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Aantal = table.Column<int>(nullable: false),
                    Prijs = table.Column<decimal>(nullable: false),
                    BestellingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellijnen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bestellijnen_Bestellingen_BestellingId",
                        column: x => x.BestellingId,
                        principalTable: "Bestellingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bestellijn_Product",
                        column: x => x.ProductId,
                        principalTable: "Producten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adressen_GemeenteId",
                table: "Adressen",
                column: "GemeenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellijnen_BestellingId",
                table: "Bestellijnen",
                column: "BestellingId");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellijnen_ProductId",
                table: "Bestellijnen",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellingen_KlantId",
                table: "Bestellingen",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Klanten_AdresId",
                table: "Klanten",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Locaties_AdresId",
                table: "Locaties",
                column: "AdresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bestellijnen");

            migrationBuilder.DropTable(
                name: "Locaties");

            migrationBuilder.DropTable(
                name: "Bestellingen");

            migrationBuilder.DropTable(
                name: "Producten");

            migrationBuilder.DropTable(
                name: "Klanten");

            migrationBuilder.DropTable(
                name: "Adressen");

            migrationBuilder.DropTable(
                name: "Gemeenten");
        }
    }
}
