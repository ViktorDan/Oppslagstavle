using Microsoft.EntityFrameworkCore.Migrations;

namespace Oppslagstavle.Migrations
{
    public partial class Forhold_Bygg_Enheter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ByggId",
                table: "DB_Enheter",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DB_Enheter_ByggId",
                table: "DB_Enheter",
                column: "ByggId");

            migrationBuilder.AddForeignKey(
                name: "FK_DB_Enheter_DB_Bygg_ByggId",
                table: "DB_Enheter",
                column: "ByggId",
                principalTable: "DB_Bygg",
                principalColumn: "ByggId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DB_Enheter_DB_Bygg_ByggId",
                table: "DB_Enheter");

            migrationBuilder.DropIndex(
                name: "IX_DB_Enheter_ByggId",
                table: "DB_Enheter");

            migrationBuilder.DropColumn(
                name: "ByggId",
                table: "DB_Enheter");
        }
    }
}
