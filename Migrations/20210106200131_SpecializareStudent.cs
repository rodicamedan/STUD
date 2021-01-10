using Microsoft.EntityFrameworkCore.Migrations;

namespace Studenti.Migrations
{
    public partial class SpecializareStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacultateID",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDFacultate",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Facultate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeFacultate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Specializare",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializare", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SpecializareStudent",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(nullable: false),
                    IDSpecializare = table.Column<int>(nullable: false),
                    SpecializareID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializareStudent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpecializareStudent_Specializare_SpecializareID",
                        column: x => x.SpecializareID,
                        principalTable: "Specializare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecializareStudent_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_FacultateID",
                table: "Student",
                column: "FacultateID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializareStudent_SpecializareID",
                table: "SpecializareStudent",
                column: "SpecializareID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializareStudent_StudentID",
                table: "SpecializareStudent",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Facultate_FacultateID",
                table: "Student",
                column: "FacultateID",
                principalTable: "Facultate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Facultate_FacultateID",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Facultate");

            migrationBuilder.DropTable(
                name: "SpecializareStudent");

            migrationBuilder.DropTable(
                name: "Specializare");

            migrationBuilder.DropIndex(
                name: "IX_Student_FacultateID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "FacultateID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "IDFacultate",
                table: "Student");
        }
    }
}
