using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReversiMvcApp.Migrations
{
    public partial class AddedIdentityToSpeler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Kleur",
                table: "Speler",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Speler",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Speler",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Speler",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Speler",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Speler",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Speler",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Speler",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Speler",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Speler",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Speler",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Speler",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Speler",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Speler",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Speler",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Speler");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Speler");

            migrationBuilder.AlterColumn<string>(
                name: "Kleur",
                table: "Speler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
