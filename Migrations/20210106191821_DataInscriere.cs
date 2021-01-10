using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Studenti.Migrations
{
    public partial class DataInscriere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataInscriere",
                table: "Student",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInscriere",
                table: "Student");
        }
    }
}
