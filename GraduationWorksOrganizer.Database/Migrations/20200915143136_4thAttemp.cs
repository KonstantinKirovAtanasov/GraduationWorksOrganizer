using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class _4thAttemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThesesUserEntries_AspNetUsers_ThemeObserverId",
                table: "ThesesUserEntries");

            migrationBuilder.DropIndex(
                name: "IX_ThesesUserEntries_ThemeObserverId",
                table: "ThesesUserEntries");

            migrationBuilder.DropColumn(
                name: "ThemeObserverId",
                table: "ThesesUserEntries");

            migrationBuilder.CreateTable(
                name: "ThesisApprovementRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThesesUserEntryId = table.Column<int>(nullable: false),
                    ThemeObserverId = table.Column<string>(nullable: true),
                    RequestDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisApprovementRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThesisApprovementRequest_AspNetUsers_ThemeObserverId",
                        column: x => x.ThemeObserverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThesisApprovementRequest_ThesesUserEntries_ThesesUserEntryId",
                        column: x => x.ThesesUserEntryId,
                        principalTable: "ThesesUserEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThesisApprovementRequest_ThemeObserverId",
                table: "ThesisApprovementRequest",
                column: "ThemeObserverId");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisApprovementRequest_ThesesUserEntryId",
                table: "ThesisApprovementRequest",
                column: "ThesesUserEntryId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThesisApprovementRequest");

            migrationBuilder.AddColumn<string>(
                name: "ThemeObserverId",
                table: "ThesesUserEntries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThesesUserEntries_ThemeObserverId",
                table: "ThesesUserEntries",
                column: "ThemeObserverId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThesesUserEntries_AspNetUsers_ThemeObserverId",
                table: "ThesesUserEntries",
                column: "ThemeObserverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
