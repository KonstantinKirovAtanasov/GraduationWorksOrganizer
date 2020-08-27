using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class addedStudentAndTeacherProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacultyNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cabinet",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScienceDegree",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacultyNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PersonalNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cabinet",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ScienceDegree",
                table: "AspNetUsers");
        }
    }
}
