using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeCount.Data.Migrations
{
    public partial class SlagMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slag",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CreatedAt", "FirstName", "LastJob", "LastName", "Mail", "Phone", "Resume", "Slag", "StudyLevel", "YearsOfExperinces" },
                values: new object[] { 1, new DateTime(2022, 10, 14, 23, 16, 47, 37, DateTimeKind.Local).AddTicks(6438), "Younes", "Software Enginner at Concepment S.a.r.l.", "ERRAJI", "younes-erraji@mail.com", "0651656799", null, null, "Bac+2", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Slag",
                table: "Applications");
        }
    }
}
