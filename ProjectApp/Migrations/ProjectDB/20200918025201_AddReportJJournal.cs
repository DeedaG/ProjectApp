using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectApp.Migrations.ProjectDB
{
    public partial class AddReportJJournal : Migration
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
                    ShortTime = table.Column<int>(nullable: false),
                    LongTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportJournal", x => x.Id);
                });

            //migrationBuilder.UpdateData(
            //    table: "ChartData",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    column: "ChartUserId",
            //    value: "93879f86-de21-4285-8b8f-2f76770859cc");

            //migrationBuilder.UpdateData(
            //    table: "ProjectViewModel",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    columns: new[] { "Language", "StartDate" },
            //    values: new object[] { "Ruby", new DateTime(2020, 9, 17, 21, 52, 1, 85, DateTimeKind.Local).AddTicks(7470) });

            //migrationBuilder.UpdateData(
            //    table: "ProjectViewModel",
            //    keyColumn: "Id",
            //    keyValue: 2,
            //    columns: new[] { "Language", "StartDate" },
            //    values: new object[] { "React", new DateTime(2020, 9, 17, 21, 52, 1, 101, DateTimeKind.Local).AddTicks(380) });

            //migrationBuilder.InsertData(
            //    table: "ProjectViewModel",
            //    columns: new[] { "Id", "EndDate", "Info", "Language", "Name", "ProjectDataId", "ProjectUserId", "StartDate" },
            //    values: new object[] { 3, null, "test2", "C#", "Test3", 1, null, new DateTime(2020, 9, 17, 21, 52, 1, 101, DateTimeKind.Local).AddTicks(440) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportJournal");

            //migrationBuilder.DeleteData(
            //    table: "ProjectViewModel",
            //    keyColumn: "Id",
            //    keyValue: 3);


            //migrationBuilder.UpdateData(
            //    table: "ChartData",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    column: "ChartUserId",
            //    value: null);

            //migrationBuilder.UpdateData(
            //    table: "ProjectViewModel",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    columns: new[] { "Language", "StartDate" },
            //    values: new object[] { "Test1", null });

            //migrationBuilder.UpdateData(
            //    table: "ProjectViewModel",
            //    keyColumn: "Id",
            //    keyValue: 2,
            //    columns: new[] { "Language", "StartDate" },
            //    values: new object[] { "Test2", null });
        }
    }
}
