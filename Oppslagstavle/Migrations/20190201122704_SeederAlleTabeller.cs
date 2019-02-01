using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oppslagstavle.Migrations
{
    public partial class SeederAlleTabeller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DB_Borettslag",
                columns: new[] { "BorettslagId", "DatoOpprettet", "Navn" },
                values: new object[] { 2, new DateTime(2018, 1, 31, 22, 12, 0, 0, DateTimeKind.Unspecified), "McDonalds" });

            migrationBuilder.InsertData(
                table: "DB_Bygg",
                columns: new[] { "ByggId", "BorettslagId", "ByggNavn", "ByggNr", "ByggType" },
                values: new object[] { 2, 1, "B", 2, "Rekkehus" });

            migrationBuilder.InsertData(
                table: "DB_Enheter",
                columns: new[] { "EnhetId", "ByggId", "EnhetsNr" },
                values: new object[,]
                {
                    { 2, 1, 30 },
                    { 3, 1, 500 }
                });

            migrationBuilder.InsertData(
                table: "Personer",
                columns: new[] { "PersonId", "Epost", "Etternavn", "Fornavn", "Fulltnavn", "Lowercase_Epost", "PersonType", "Tlf", "EnhetId" },
                values: new object[] { 7, "Hillary.Clinton@gov.com", "Clinton", "Hillary", "Hillary Clinton", "hillary.clinton@gov.com", 1, "17161514", 1 });

            migrationBuilder.InsertData(
                table: "Personer",
                columns: new[] { "PersonId", "Epost", "Etternavn", "Fornavn", "Fulltnavn", "Lowercase_Epost", "PersonType", "Tlf", "BorettslagId", "Styreleder" },
                values: new object[,]
                {
                    { 2, "Donald.Duck@andebymail.ab", "Duck", "Donald", "Donald Duck", "donald.duck@andebymail.ab", 2, "12345678", 1, true },
                    { 3, "Elvis.Presley@kentucky.us", "Presley", "Elvis", "Elvis Presley", "elvis.presley@kentucky.us", 2, "12131415", 1, false },
                    { 4, "Skrue.McDuck@andebymail.ab", "McDuck", "Skrue", "Skrue McDuck", "skrue.mcduck@andebymail.ab", 2, "65748392", 1, false }
                });

            migrationBuilder.InsertData(
                table: "DB_Bygg",
                columns: new[] { "ByggId", "BorettslagId", "ByggNavn", "ByggNr", "ByggType" },
                values: new object[] { 3, 2, "C", 3, "Blokk" });

            migrationBuilder.InsertData(
                table: "DB_Enheter",
                columns: new[] { "EnhetId", "ByggId", "EnhetsNr" },
                values: new object[,]
                {
                    { 4, 2, 1 },
                    { 5, 2, 90 }
                });

            migrationBuilder.InsertData(
                table: "DB_Oppslag",
                columns: new[] { "OppslagId", "Bilde", "Deltakelse", "PersonId", "SluttDato", "SluttTid", "StartDato", "StartTid", "Tekst", "Tittel" },
                values: new object[,]
                {
                    { 1, "URL", true, 2, new DateTime(2018, 1, 31, 22, 12, 0, 0, DateTimeKind.Unspecified), "15:00", new DateTime(2018, 1, 31, 22, 12, 0, 0, DateTimeKind.Unspecified), "14:00", "Nå er det noen som har lagt igjen søppel i oppgangen flere ganger. Dette er ikke tillatt da det lukter søppel i hele oppgangen. Når man tar søpla ut av døra skal man gå hele veien ut døra og kaste søpla i søppeldunkene! Mvh Styret", "Søppel i oppgang" },
                    { 2, "URL", true, 3, new DateTime(2018, 1, 31, 22, 12, 0, 0, DateTimeKind.Unspecified), "15:00", new DateTime(2018, 1, 31, 22, 12, 0, 0, DateTimeKind.Unspecified), "14:00", "Det er ikke tillatt med dyrehold i Borettslaget! Skal du ha kjæledyr, vennligst flytt. Mvh Styret", "Hund og katt" },
                    { 4, "URL", true, 3, new DateTime(2018, 1, 31, 22, 12, 0, 0, DateTimeKind.Unspecified), "15:00", new DateTime(2018, 1, 31, 22, 12, 0, 0, DateTimeKind.Unspecified), "14:00", "Styret har fått mail fra kommunen om at søppeltømming vil skje på mandager fra nå av. Mvh Styret", "Ny dato for søppeltømming" },
                    { 5, "URL", true, 3, new DateTime(2018, 1, 31, 22, 12, 0, 0, DateTimeKind.Unspecified), "15:00", new DateTime(2018, 1, 31, 22, 12, 0, 0, DateTimeKind.Unspecified), "14:00", "Det har oppstått et problem med porten vår som gjør at den ikke lukker seg ordentlig. Vi ber derfor våre beboere om å se til at porten går ordentlig igjen etter seg slik at ikke uvedkommende får adgang. Mvh Styret", "Lukk porten etter dere" },
                    { 3, "URL", true, 4, new DateTime(2018, 1, 31, 22, 12, 0, 0, DateTimeKind.Unspecified), "15:00", new DateTime(2018, 1, 31, 22, 12, 0, 0, DateTimeKind.Unspecified), "14:00", "Nå er det tid for sommerfest! Dette vil foregå i bakgården hvor det er to stk grill tilgjengelig. Ta med mat og drikke og godt humør! Mvh Styret", "Sommerfest" }
                });

            migrationBuilder.InsertData(
                table: "Personer",
                columns: new[] { "PersonId", "Epost", "Etternavn", "Fornavn", "Fulltnavn", "Lowercase_Epost", "PersonType", "Tlf", "BorettslagId", "Styreleder" },
                values: new object[,]
                {
                    { 5, "Ole.Olsen@Olsenmail.ole", "Olsen", "Ole", "Ole Olsen", "ole.olsen@olsenmail.ole", 2, "90182039", 2, false },
                    { 6, "Gunnar.Solstad@norgemail.no", "Solstad", "Gunnar", "Gunnar Solstad", "gunnar.solstad@norgemail.no", 2, "25252525", 2, true }
                });

            migrationBuilder.InsertData(
                table: "Personer",
                columns: new[] { "PersonId", "Epost", "Etternavn", "Fornavn", "Fulltnavn", "Lowercase_Epost", "PersonType", "Tlf", "EnhetId" },
                values: new object[,]
                {
                    { 8, "Cheesy.McSteak@Mccern.no", "McSteak", "Cheesy", "Cheesy McSteak", "cheesy.mcsteak@mccern.no", 1, "25252525", 2 },
                    { 9, "Chicken.McSalsa@Mccern.no", "McSalsa", "Chicken", "Chicken McSalsa", "chicken.mcsalsa@mccern.no", 1, "25252525", 3 }
                });

            migrationBuilder.InsertData(
                table: "Personer",
                columns: new[] { "PersonId", "Epost", "Etternavn", "Fornavn", "Fulltnavn", "Lowercase_Epost", "PersonType", "Tlf", "EnhetId" },
                values: new object[] { 10, "Big.McBigmac@Mccern.no", "McBigmac", "Big", "Big McBigmac", "big.mcbigmac@mccern.no", 1, "25252525", 4 });

            migrationBuilder.InsertData(
                table: "Personer",
                columns: new[] { "PersonId", "Epost", "Etternavn", "Fornavn", "Fulltnavn", "Lowercase_Epost", "PersonType", "Tlf", "EnhetId" },
                values: new object[] { 11, "Quarter.Pounder@Mccern.no", "Pounder", "Quarter", "Quarter Pounder", "quarter.pounder@mccern.no", 1, "25252525", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DB_Bygg",
                keyColumn: "ByggId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DB_Oppslag",
                keyColumn: "OppslagId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DB_Oppslag",
                keyColumn: "OppslagId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DB_Oppslag",
                keyColumn: "OppslagId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DB_Oppslag",
                keyColumn: "OppslagId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DB_Oppslag",
                keyColumn: "OppslagId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Personer",
                keyColumn: "PersonId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Personer",
                keyColumn: "PersonId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Personer",
                keyColumn: "PersonId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Personer",
                keyColumn: "PersonId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Personer",
                keyColumn: "PersonId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Personer",
                keyColumn: "PersonId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Personer",
                keyColumn: "PersonId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DB_Borettslag",
                keyColumn: "BorettslagId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DB_Enheter",
                keyColumn: "EnhetId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DB_Enheter",
                keyColumn: "EnhetId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DB_Enheter",
                keyColumn: "EnhetId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DB_Enheter",
                keyColumn: "EnhetId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Personer",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personer",
                keyColumn: "PersonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personer",
                keyColumn: "PersonId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DB_Bygg",
                keyColumn: "ByggId",
                keyValue: 2);
        }
    }
}
