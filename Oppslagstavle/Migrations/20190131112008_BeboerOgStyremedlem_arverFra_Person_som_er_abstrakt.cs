using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oppslagstavle.Migrations
{
    public partial class BeboerOgStyremedlem_arverFra_Person_som_er_abstrakt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DB_Beboere");

            migrationBuilder.DropTable(
                name: "DB_Styremedlemmer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DB_Personer",
                table: "DB_Personer");

            migrationBuilder.RenameTable(
                name: "DB_Personer",
                newName: "Personer");

            migrationBuilder.AddColumn<int>(
                name: "PersonType",
                table: "Personer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Styreleder",
                table: "Personer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personer",
                table: "Personer",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Personer",
                table: "Personer");

            migrationBuilder.DropColumn(
                name: "PersonType",
                table: "Personer");

            migrationBuilder.DropColumn(
                name: "Styreleder",
                table: "Personer");

            migrationBuilder.RenameTable(
                name: "Personer",
                newName: "DB_Personer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DB_Personer",
                table: "DB_Personer",
                column: "PersonId");

            migrationBuilder.CreateTable(
                name: "DB_Beboere",
                columns: table => new
                {
                    BeboerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_Beboere", x => x.BeboerId);
                });

            migrationBuilder.CreateTable(
                name: "DB_Styremedlemmer",
                columns: table => new
                {
                    StyremedlemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Styreleder = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_Styremedlemmer", x => x.StyremedlemId);
                });
        }
    }
}
