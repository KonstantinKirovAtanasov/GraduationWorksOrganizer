using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class MarksThesesRequerment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThesesMarkId",
                table: "ThesisRequerments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThesisRequerments_ThesesMarkId",
                table: "ThesisRequerments",
                column: "ThesesMarkId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThesisRequerments_Marks_ThesesMarkId",
                table: "ThesisRequerments",
                column: "ThesesMarkId",
                principalTable: "Marks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThesisRequerments_Marks_ThesesMarkId",
                table: "ThesisRequerments");

            migrationBuilder.DropIndex(
                name: "IX_ThesisRequerments_ThesesMarkId",
                table: "ThesisRequerments");

            migrationBuilder.DropColumn(
                name: "ThesesMarkId",
                table: "ThesisRequerments");
        }
    }
}
