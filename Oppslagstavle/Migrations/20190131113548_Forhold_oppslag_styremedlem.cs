using Microsoft.EntityFrameworkCore.Migrations;

namespace Oppslagstavle.Migrations
{
    public partial class Forhold_oppslag_styremedlem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "DB_Oppslag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DB_Oppslag_PersonId",
                table: "DB_Oppslag",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_DB_Oppslag_Personer_PersonId",
                table: "DB_Oppslag",
                column: "PersonId",
                principalTable: "Personer",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DB_Oppslag_Personer_PersonId",
                table: "DB_Oppslag");

            migrationBuilder.DropIndex(
                name: "IX_DB_Oppslag_PersonId",
                table: "DB_Oppslag");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "DB_Oppslag");
        }
    }
}
