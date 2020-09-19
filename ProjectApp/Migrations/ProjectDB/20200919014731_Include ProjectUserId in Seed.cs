using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectApp.Migrations.ProjectDB
{
    public partial class IncludeProjectUserIdinSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportJournal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(nullable: true),
                    NameChange = table.Column<bool>(nullable: false),
                    ProjLanguage = table.Column<string>(nullable: true),
                    LanguageChange = table.Column<bool>(nullable: false),
                    DevTime = table.Column<int>(nullable: false),
                    ChangeCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportJournal", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ProjectUserId", "StartDate" },
                values: new object[] { "93879f86-de21-4285-8b8f-2f76770859cc", new DateTime(2020, 9, 18, 20, 47, 30, 610, DateTimeKind.Local).AddTicks(5210) });

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ProjectUserId", "StartDate" },
                values: new object[] { "93879f86-de21-4285-8b8f-2f76770859cc", new DateTime(2020, 9, 18, 20, 47, 30, 625, DateTimeKind.Local).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2020, 9, 18, 20, 47, 30, 625, DateTimeKind.Local).AddTicks(8080));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportJournal");

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ProjectUserId", "StartDate" },
                values: new object[] { null, new DateTime(2020, 9, 17, 21, 52, 1, 85, DateTimeKind.Local).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ProjectUserId", "StartDate" },
                values: new object[] { null, new DateTime(2020, 9, 17, 21, 52, 1, 101, DateTimeKind.Local).AddTicks(380) });

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 3,
                column: "StartDate",
                value: new DateTime(2020, 9, 17, 21, 52, 1, 101, DateTimeKind.Local).AddTicks(440));
        }
    }
}
