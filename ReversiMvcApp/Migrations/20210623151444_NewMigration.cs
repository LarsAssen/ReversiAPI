using Microsoft.EntityFrameworkCore.Migrations;

namespace ReversiMvcApp.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AandeBeurt",
                table: "Spel",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speler1GUID",
                table: "Spel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speler2GUID",
                table: "Spel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spel_Speler1GUID",
                table: "Spel",
                column: "Speler1GUID");

            migrationBuilder.CreateIndex(
                name: "IX_Spel_Speler2GUID",
                table: "Spel",
                column: "Speler2GUID");

            migrationBuilder.AddForeignKey(
                name: "FK_Spel_Speler_Speler1GUID",
                table: "Spel",
                column: "Speler1GUID",
                principalTable: "Speler",
                principalColumn: "GUID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Spel_Speler_Speler2GUID",
                table: "Spel",
                column: "Speler2GUID",
                principalTable: "Speler",
                principalColumn: "GUID",
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

            migrationBuilder.DropIndex(
                name: "IX_Spel_Speler1GUID",
                table: "Spel");

            migrationBuilder.DropIndex(
                name: "IX_Spel_Speler2GUID",
                table: "Spel");

            migrationBuilder.DropColumn(
                name: "Speler1GUID",
                table: "Spel");

            migrationBuilder.DropColumn(
                name: "Speler2GUID",
                table: "Spel");

            migrationBuilder.AlterColumn<string>(
                name: "AandeBeurt",
                table: "Spel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
