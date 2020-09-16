using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class changeRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefenceEvents_AspNetUsers_StudentId",
                table: "DefenceEvents");

            migrationBuilder.DropIndex(
                name: "IX_DefenceEvents_StudentId",
                table: "DefenceEvents");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "DefenceEvents");

            migrationBuilder.AddColumn<int>(
                name: "ThesesUserEntryId",
                table: "DefenceEvents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DefenceEvents_ThesesUserEntryId",
                table: "DefenceEvents",
                column: "ThesesUserEntryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DefenceEvents_ThesesUserEntries_ThesesUserEntryId",
                table: "DefenceEvents",
                column: "ThesesUserEntryId",
                principalTable: "ThesesUserEntries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefenceEvents_ThesesUserEntries_ThesesUserEntryId",
                table: "DefenceEvents");

            migrationBuilder.DropIndex(
                name: "IX_DefenceEvents_ThesesUserEntryId",
                table: "DefenceEvents");

            migrationBuilder.DropColumn(
                name: "ThesesUserEntryId",
                table: "DefenceEvents");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "DefenceEvents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DefenceEvents_StudentId",
                table: "DefenceEvents",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefenceEvents_AspNetUsers_StudentId",
                table: "DefenceEvents",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
