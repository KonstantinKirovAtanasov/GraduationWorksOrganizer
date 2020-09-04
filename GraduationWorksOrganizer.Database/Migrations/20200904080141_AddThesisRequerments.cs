using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class AddThesisRequerments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThesisRequerments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    ThesesId = table.Column<int>(nullable: false),
                    MaxPointsCount = table.Column<decimal>(nullable: false),
                    MarkPoints = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisRequerments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThesisRequerments_Theses_ThesesId",
                        column: x => x.ThesesId,
                        principalTable: "Theses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThesisRequerments_ThesesId",
                table: "ThesisRequerments",
                column: "ThesesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThesisRequerments");
        }
    }
}
