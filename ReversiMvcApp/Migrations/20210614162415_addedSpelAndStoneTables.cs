using Microsoft.EntityFrameworkCore.Migrations;

namespace ReversiMvcApp.Migrations
{
    public partial class addedSpelAndStoneTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Speler",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kleur",
                table: "Speler",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpelID",
                table: "Speler",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Spel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Omschrijving = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    Speler1Token = table.Column<string>(nullable: true),
                    Speler2Token = table.Column<string>(nullable: true),
                    AandeBeurt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stone",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kleur = table.Column<string>(nullable: true),
                    xLocation = table.Column<int>(nullable: false),
                    yLocation = table.Column<int>(nullable: false),
                    SpelID = table.Column<int>(nullable: true)
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
                name: "FK_Speler_Spel_SpelID",
                table: "Speler");

            migrationBuilder.DropTable(
                name: "Stone");

            migrationBuilder.DropTable(
                name: "Spel");

            migrationBuilder.DropIndex(
                name: "IX_Speler_SpelID",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "Kleur",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "SpelID",
                table: "Speler");
        }
    }
}
