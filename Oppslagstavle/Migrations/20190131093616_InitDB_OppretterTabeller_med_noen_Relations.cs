using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oppslagstavle.Migrations
{
    public partial class InitDB_OppretterTabeller_med_noen_Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "DB_Borettslag",
                columns: table => new
                {
                    BorettslagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Navn = table.Column<string>(nullable: true),
                    Opprettet = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_Borettslag", x => x.BorettslagId);
                });

            migrationBuilder.CreateTable(
                name: "DB_Bygg",
                columns: table => new
                {
                    ByggId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ByggNr = table.Column<int>(nullable: false),
                    ByggType = table.Column<string>(nullable: true),
                    ByggNavn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_Bygg", x => x.ByggId);
                });

            migrationBuilder.CreateTable(
                name: "DB_Enheter",
                columns: table => new
                {
                    EnhetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnhetsNr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_Enheter", x => x.EnhetId);
                });

            migrationBuilder.CreateTable(
                name: "DB_Oppslag",
                columns: table => new
                {
                    OppslagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tittel = table.Column<string>(nullable: true),
                    Tekst = table.Column<string>(nullable: true),
                    Bilde = table.Column<string>(nullable: true),
                    StartDato = table.Column<DateTime>(nullable: false),
                    SluttDato = table.Column<DateTime>(nullable: false),
                    StartTid = table.Column<string>(nullable: true),
                    SluttTid = table.Column<string>(nullable: true),
                    Deltakelse = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_Oppslag", x => x.OppslagId);
                });

            migrationBuilder.CreateTable(
                name: "DB_Personer",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fornavn = table.Column<string>(nullable: true),
                    Etternavn = table.Column<string>(nullable: true),
                    Fulltnavn = table.Column<string>(nullable: true),
                    Epost = table.Column<string>(nullable: true),
                    Lowercase_Epost = table.Column<string>(nullable: true),
                    Tlf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_Personer", x => x.PersonId);
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

            migrationBuilder.CreateTable(
                name: "DB_OppslagIBygg",
                columns: table => new
                {
                    ByggId = table.Column<int>(nullable: false),
                    OppslagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_OppslagIBygg", x => new { x.ByggId, x.OppslagId });
                    table.ForeignKey(
                        name: "FK_DB_OppslagIBygg_DB_Bygg_ByggId",
                        column: x => x.ByggId,
                        principalTable: "DB_Bygg",
                        principalColumn: "ByggId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DB_OppslagIBygg_DB_Oppslag_OppslagId",
                        column: x => x.OppslagId,
                        principalTable: "DB_Oppslag",
                        principalColumn: "OppslagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DB_OppslagIBygg_OppslagId",
                table: "DB_OppslagIBygg",
                column: "OppslagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DB_Beboere");

            migrationBuilder.DropTable(
                name: "DB_Borettslag");

            migrationBuilder.DropTable(
                name: "DB_Enheter");

            migrationBuilder.DropTable(
                name: "DB_OppslagIBygg");

            migrationBuilder.DropTable(
                name: "DB_Personer");

            migrationBuilder.DropTable(
                name: "DB_Styremedlemmer");

            migrationBuilder.DropTable(
                name: "DB_Bygg");

            migrationBuilder.DropTable(
                name: "DB_Oppslag");
        }
    }
}
