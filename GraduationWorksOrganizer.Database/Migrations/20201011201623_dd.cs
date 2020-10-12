using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Commissions_CommissionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DefenceDates_Commissions_CommissionId",
                table: "DefenceDates");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropIndex(
                name: "IX_DefenceDates_CommissionId",
                table: "DefenceDates");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CommissionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CommissionId",
                table: "DefenceDates");

            migrationBuilder.DropColumn(
                name: "CommissionId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "DefenceDates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DefenceDates_TeacherId",
                table: "DefenceDates",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_DefenceDates_AspNetUsers_TeacherId",
                table: "DefenceDates",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DefenceDates_AspNetUsers_TeacherId",
                table: "DefenceDates");

            migrationBuilder.DropIndex(
                name: "IX_DefenceDates_TeacherId",
                table: "DefenceDates");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "DefenceDates");

            migrationBuilder.AddColumn<int>(
                name: "CommissionId",
                table: "DefenceDates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommissionId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    MainCommissionTeacherId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commissions_Deparments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Deparments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Commissions_AspNetUsers_MainCommissionTeacherId",
                        column: x => x.MainCommissionTeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefenceDates_CommissionId",
                table: "DefenceDates",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CommissionId",
                table: "AspNetUsers",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_DepartmentId",
                table: "Commissions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_MainCommissionTeacherId",
                table: "Commissions",
                column: "MainCommissionTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Commissions_CommissionId",
                table: "AspNetUsers",
                column: "CommissionId",
                principalTable: "Commissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DefenceDates_Commissions_CommissionId",
                table: "DefenceDates",
                column: "CommissionId",
                principalTable: "Commissions",
                principalColumn: "Id");
        }
    }
}
