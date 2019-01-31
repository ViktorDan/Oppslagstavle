using Microsoft.EntityFrameworkCore.Migrations;

namespace Oppslagstavle.Migrations
{
    public partial class Forhold_Enheter_Beboere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnhetId",
                table: "Personer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personer_EnhetId",
                table: "Personer",
                column: "EnhetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personer_DB_Enheter_EnhetId",
                table: "Personer",
                column: "EnhetId",
                principalTable: "DB_Enheter",
                principalColumn: "EnhetId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personer_DB_Enheter_EnhetId",
                table: "Personer");

            migrationBuilder.DropIndex(
                name: "IX_Personer_EnhetId",
                table: "Personer");

            migrationBuilder.DropColumn(
                name: "EnhetId",
                table: "Personer");
        }
    }
}
