using Microsoft.EntityFrameworkCore.Migrations;

namespace ReversiMvcApp.Migrations
{
    public partial class CreatedSpeler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Speler",
                columns: table => new
                {
                    GUID = table.Column<string>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    AantalGewonnen = table.Column<int>(nullable: false),
                    AantalVerloren = table.Column<int>(nullable: false),
                    AantalGelijk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speler", x => x.GUID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speler");
        }
    }
}
