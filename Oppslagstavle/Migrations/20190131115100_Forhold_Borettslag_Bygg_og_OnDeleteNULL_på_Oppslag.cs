using Microsoft.EntityFrameworkCore.Migrations;

namespace Oppslagstavle.Migrations
{
    public partial class Forhold_Borettslag_Bygg_og_OnDeleteNULL_på_Oppslag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DB_Oppslag_Personer_PersonId",
                table: "DB_Oppslag");

            migrationBuilder.AddColumn<int>(
                name: "BorettslagId",
                table: "DB_Bygg",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DB_Bygg_BorettslagId",
                table: "DB_Bygg",
                column: "BorettslagId");

            migrationBuilder.AddForeignKey(
                name: "FK_DB_Bygg_DB_Borettslag_BorettslagId",
                table: "DB_Bygg",
                column: "BorettslagId",
                principalTable: "DB_Borettslag",
                principalColumn: "BorettslagId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DB_Oppslag_Personer_PersonId",
                table: "DB_Oppslag",
                column: "PersonId",
                principalTable: "Personer",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DB_Bygg_DB_Borettslag_BorettslagId",
                table: "DB_Bygg");

            migrationBuilder.DropForeignKey(
                name: "FK_DB_Oppslag_Personer_PersonId",
                table: "DB_Oppslag");

            migrationBuilder.DropIndex(
                name: "IX_DB_Bygg_BorettslagId",
                table: "DB_Bygg");

            migrationBuilder.DropColumn(
                name: "BorettslagId",
                table: "DB_Bygg");

            migrationBuilder.AddForeignKey(
                name: "FK_DB_Oppslag_Personer_PersonId",
                table: "DB_Oppslag",
                column: "PersonId",
                principalTable: "Personer",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
