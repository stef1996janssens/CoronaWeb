using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoronaData.Migrations
{
    public partial class LocatieDatumVanDatumTot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Locaties");

            migrationBuilder.AddColumn<DateTime>(
                name: "Tot",
                table: "Locaties",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Van",
                table: "Locaties",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tot",
                table: "Locaties");

            migrationBuilder.DropColumn(
                name: "Van",
                table: "Locaties");

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Locaties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
