using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectApp.Migrations.ProjectDB
{
    public partial class AddJournalUpdateTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 9, 21, 20, 11, 46, 129, DateTimeKind.Local).AddTicks(3730), new DateTime(2020, 9, 21, 20, 11, 46, 111, DateTimeKind.Local).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 9, 21, 20, 11, 46, 129, DateTimeKind.Local).AddTicks(5630), new DateTime(2020, 9, 21, 20, 11, 46, 129, DateTimeKind.Local).AddTicks(5600) });

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 9, 21, 20, 11, 46, 129, DateTimeKind.Local).AddTicks(5680), new DateTime(2020, 9, 21, 20, 11, 46, 129, DateTimeKind.Local).AddTicks(5670) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 9, 21, 14, 48, 8, 85, DateTimeKind.Local).AddTicks(8920), new DateTime(2020, 9, 21, 14, 48, 8, 70, DateTimeKind.Local).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 9, 21, 14, 48, 8, 86, DateTimeKind.Local).AddTicks(670), new DateTime(2020, 9, 21, 14, 48, 8, 86, DateTimeKind.Local).AddTicks(650) });

            migrationBuilder.UpdateData(
                table: "ProjectViewModel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 9, 21, 14, 48, 8, 86, DateTimeKind.Local).AddTicks(710), new DateTime(2020, 9, 21, 14, 48, 8, 86, DateTimeKind.Local).AddTicks(700) });
        }
    }
}
