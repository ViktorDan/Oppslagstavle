using Microsoft.EntityFrameworkCore.Migrations;

namespace Oppslagstavle.Migrations
{
    public partial class Seed_OppslagIBygg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DB_OppslagIBygg",
                columns: new[] { "ByggId", "OppslagId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DB_OppslagIBygg",
                keyColumns: new[] { "ByggId", "OppslagId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DB_OppslagIBygg",
                keyColumns: new[] { "ByggId", "OppslagId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "DB_OppslagIBygg",
                keyColumns: new[] { "ByggId", "OppslagId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "DB_OppslagIBygg",
                keyColumns: new[] { "ByggId", "OppslagId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "DB_OppslagIBygg",
                keyColumns: new[] { "ByggId", "OppslagId" },
                keyValues: new object[] { 2, 5 });
        }
    }
}
