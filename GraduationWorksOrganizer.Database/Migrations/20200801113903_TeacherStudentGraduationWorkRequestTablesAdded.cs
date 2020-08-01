using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class TeacherStudentGraduationWorkRequestTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GraduationWorkBlanckRequests",
                columns: table => new
                {
                    GraduationWorkBlanckRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduationWorkBlanckRequests", x => x.GraduationWorkBlanckRequestId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GraduationWorkBlanckRequests");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
