using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectApp.Migrations.ProjectDB
{
    public partial class AddColumnToReportJournal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ReportJournal",
                columns: new[] { "Id", "Author", "ChangeCount", "DevTime", "LanguageChange", "NameChange", "ProjLanguage" },
                values: new object[] { 1, "JohnDoe", 0, 1, false, false, "C#" });

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "ReportJournalId", "StartDate" },
                values: new object[] { new DateTime(2020, 9, 21, 14, 48, 8, 85, DateTimeKind.Local).AddTicks(8920), 1, new DateTime(2020, 9, 21, 14, 48, 8, 70, DateTimeKind.Local).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "ReportJournalId", "StartDate" },
                values: new object[] { new DateTime(2020, 9, 21, 14, 48, 8, 86, DateTimeKind.Local).AddTicks(670), 1, new DateTime(2020, 9, 21, 14, 48, 8, 86, DateTimeKind.Local).AddTicks(650) });

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "ProjectUserId", "ReportJournalId", "StartDate" },
                values: new object[] { new DateTime(2020, 9, 21, 14, 48, 8, 86, DateTimeKind.Local).AddTicks(710), "93879f86-de21-4285-8b8f-2f76770859cc", 1, new DateTime(2020, 9, 21, 14, 48, 8, 86, DateTimeKind.Local).AddTicks(700) });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectViewModel_ReportJournalId",
                table: "ProjectViewModel",
                column: "ReportJournalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProjectViewModel_ReportJournalId",
                table: "ProjectViewModel");

            migrationBuilder.DeleteData(
                table: "ReportJournal",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { null, new DateTime(2020, 9, 18, 20, 47, 30, 610, DateTimeKind.Local).AddTicks(5210) });

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { null, new DateTime(2020, 9, 18, 20, 47, 30, 625, DateTimeKind.Local).AddTicks(8010) });

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "ProjectUserId", "StartDate" },
                values: new object[] { null, null, new DateTime(2020, 9, 18, 20, 47, 30, 625, DateTimeKind.Local).AddTicks(8080) });
        }
    }
}
