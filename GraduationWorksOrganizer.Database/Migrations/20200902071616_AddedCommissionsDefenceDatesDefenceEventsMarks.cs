using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class AddedCommissionsDefenceDatesDefenceEventsMarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommissionId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(nullable: false),
                    MainCommissionTeacherId = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefenceDates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallNumber = table.Column<string>(nullable: true),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    MaxThesisCount = table.Column<int>(nullable: false),
                    CommissionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefenceDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefenceDates_Commissions_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commissions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DefenceEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefenceDateId = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: true),
                    ThesisId = table.Column<int>(nullable: false),
                    ThesisMarkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefenceEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefenceEvents_DefenceDates_DefenceDateId",
                        column: x => x.DefenceDateId,
                        principalTable: "DefenceDates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DefenceEvents_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DefenceEvents_Theses_ThesisId",
                        column: x => x.ThesisId,
                        principalTable: "Theses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DefenceEvents_Marks_ThesisMarkId",
                        column: x => x.ThesisMarkId,
                        principalTable: "Marks",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DefenceDates_CommissionId",
                table: "DefenceDates",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_DefenceEvents_DefenceDateId",
                table: "DefenceEvents",
                column: "DefenceDateId");

            migrationBuilder.CreateIndex(
                name: "IX_DefenceEvents_StudentId",
                table: "DefenceEvents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DefenceEvents_ThesisId",
                table: "DefenceEvents",
                column: "ThesisId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DefenceEvents_ThesisMarkId",
                table: "DefenceEvents",
                column: "ThesisMarkId",
                unique: true,
                filter: "[ThesisMarkId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Commissions_CommissionId",
                table: "AspNetUsers",
                column: "CommissionId",
                principalTable: "Commissions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Commissions_CommissionId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DefenceEvents");

            migrationBuilder.DropTable(
                name: "DefenceDates");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CommissionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CommissionId",
                table: "AspNetUsers");
        }
    }
}
