using Microsoft.EntityFrameworkCore.Migrations;

namespace Oppslagstavle.Migrations
{
    public partial class Forhold_Styremedlem_Borettslag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BorettslagId",
                table: "Personer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personer_BorettslagId",
                table: "Personer",
                column: "BorettslagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personer_DB_Borettslag_BorettslagId",
                table: "Personer",
                column: "BorettslagId",
                principalTable: "DB_Borettslag",
                principalColumn: "BorettslagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personer_DB_Borettslag_BorettslagId",
                table: "Personer");

            migrationBuilder.DropIndex(
                name: "IX_Personer_BorettslagId",
                table: "Personer");

            migrationBuilder.DropColumn(
                name: "BorettslagId",
                table: "Personer");
        }
    }
}
