using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectApp.Migrations.ProjectDB
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });


            migrationBuilder.InsertData(
                table: "ChartData",
                columns: new[] { "Id"},
                values: new object[] { 1 });

            migrationBuilder.InsertData(
                table: "ProjectViewModel",
                columns: new[] { "Id", "EndDate", "Info", "Language", "Name", "ProjectDataId", "StartDate" },
                values: new object[] { 1, null, "test1", "Test1", "Test1", 1, null });

            migrationBuilder.InsertData(
                table: "ProjectViewModel",
                columns: new[] { "Id", "EndDate", "Info", "Language", "Name", "ProjectDataId", "StartDate" },
                values: new object[] { 2, null, "test2", "Test2", "Test2", 1, null });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
