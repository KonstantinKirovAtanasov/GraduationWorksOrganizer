using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class _ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefenceEvents_Theses_ThesisId",
                table: "DefenceEvents");

            migrationBuilder.DropIndex(
                name: "IX_DefenceEvents_ThesisId",
                table: "DefenceEvents");

            migrationBuilder.DropColumn(
                name: "ThesisId",
                table: "DefenceEvents");

            migrationBuilder.AddColumn<string>(
                name: "ResponseDescription",
                table: "ThesisApprovementRequest",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseDescription",
                table: "ThesisApprovementRequest");

            migrationBuilder.AddColumn<int>(
                name: "ThesisId",
                table: "DefenceEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DefenceEvents_ThesisId",
                table: "DefenceEvents",
                column: "ThesisId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DefenceEvents_Theses_ThesisId",
                table: "DefenceEvents",
                column: "ThesisId",
                principalTable: "Theses",
                principalColumn: "Id");
        }
    }
}
