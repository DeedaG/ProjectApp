using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectApp.Migrations
{
    public partial class EndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "ProjectViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "ProjectViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "ProjectViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProjectViewModel",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "ProjectViewModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "ProjectViewModel");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "ProjectViewModel");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "ProjectViewModel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProjectViewModel");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "ProjectViewModel");
        }
    }
}
