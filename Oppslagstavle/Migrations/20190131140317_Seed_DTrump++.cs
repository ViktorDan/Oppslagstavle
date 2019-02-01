using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oppslagstavle.Migrations
{
    public partial class Seed_DTrump : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Opprettet",
                table: "DB_Borettslag",
                newName: "DatoOpprettet");

            migrationBuilder.InsertData(
                table: "DB_Borettslag",
                columns: new[] { "BorettslagId", "DatoOpprettet", "Navn" },
                values: new object[] { 1, new DateTime(2018, 1, 31, 22, 12, 0, 0, DateTimeKind.Unspecified), "The White House" });

            migrationBuilder.InsertData(
                table: "DB_Bygg",
                columns: new[] { "ByggId", "BorettslagId", "ByggNavn", "ByggNr", "ByggType" },
                values: new object[] { 1, 1, "A", 1, "Blokk" });

            migrationBuilder.InsertData(
                table: "DB_Enheter",
                columns: new[] { "EnhetId", "ByggId", "EnhetsNr" },
                values: new object[] { 1, 1, 3 });

            migrationBuilder.InsertData(
                table: "Personer",
                columns: new[] { "PersonId", "Epost", "Etternavn", "Fornavn", "Fulltnavn", "Lowercase_Epost", "PersonType", "Tlf", "EnhetId" },
                values: new object[] { 1, "Donald.Trump@gov.com", "Trump", "Donald", "Donald Trump", "donald.trump@gov.com", 1, "12121212", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personer",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DB_Enheter",
                keyColumn: "EnhetId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DB_Bygg",
                keyColumn: "ByggId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DB_Borettslag",
                keyColumn: "BorettslagId",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "DatoOpprettet",
                table: "DB_Borettslag",
                newName: "Opprettet");
        }
    }
}
