using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaData.Migrations
{
    public partial class DatumLocatieToevoegenTijdverwijderen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locaties_Adressen_AdresId",
                table: "Locaties");

            migrationBuilder.DropColumn(
                name: "Tijdstip",
                table: "Locaties");

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Locaties",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Locaties",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Locaties_Adressen_AdresId",
                table: "Locaties",
                column: "AdresId",
                principalTable: "Adressen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locaties_Adressen_AdresId",
                table: "Locaties");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Locaties");

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Locaties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "Tijdstip",
                table: "Locaties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Locaties_Adressen_AdresId",
                table: "Locaties",
                column: "AdresId",
                principalTable: "Adressen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
