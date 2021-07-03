using Microsoft.EntityFrameworkCore.Migrations;

namespace ReversiMvcApp.Migrations
{
    public partial class MoreEnumChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Speler",
                columns: table => new
                {
                    GUID = table.Column<string>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AantalGewonnen = table.Column<int>(nullable: false),
                    AantalVerloren = table.Column<int>(nullable: false),
                    AantalGelijk = table.Column<int>(nullable: false),
                    SpelID = table.Column<int>(nullable: true),
                    Kleur = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speler", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "Spel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Omschrijving = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Speler1Token = table.Column<string>(nullable: true),
                    Speler1GUID = table.Column<string>(nullable: true),
                    Speler2Token = table.Column<string>(nullable: true),
                    Speler2GUID = table.Column<string>(nullable: true),
                    AandeBeurt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Spel_Speler_Speler1GUID",
                        column: x => x.Speler1GUID,
                        principalTable: "Speler",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spel_Speler_Speler2GUID",
                        column: x => x.Speler2GUID,
                        principalTable: "Speler",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stone",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpelID = table.Column<int>(nullable: true),
                    Kleur = table.Column<string>(nullable: true),
                    xLocation = table.Column<int>(nullable: false),
                    yLocation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stone", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stone_Spel_SpelID",
                        column: x => x.SpelID,
                        principalTable: "Spel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spel_Speler1GUID",
                table: "Spel",
                column: "Speler1GUID");

            migrationBuilder.CreateIndex(
                name: "IX_Spel_Speler2GUID",
                table: "Spel",
                column: "Speler2GUID");

            migrationBuilder.CreateIndex(
                name: "IX_Speler_SpelID",
                table: "Speler",
                column: "SpelID");

            migrationBuilder.CreateIndex(
                name: "IX_Stone_SpelID",
                table: "Stone",
                column: "SpelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Speler_Spel_SpelID",
                table: "Speler",
                column: "SpelID",
                principalTable: "Spel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spel_Speler_Speler1GUID",
                table: "Spel");

            migrationBuilder.DropForeignKey(
                name: "FK_Spel_Speler_Speler2GUID",
                table: "Spel");

            migrationBuilder.DropTable(
                name: "Stone");

            migrationBuilder.DropTable(
                name: "Speler");

            migrationBuilder.DropTable(
                name: "Spel");
        }
    }
}
