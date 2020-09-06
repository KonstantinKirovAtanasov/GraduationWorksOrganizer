﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class ThesesEntriesTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThesesUserEntries");

            migrationBuilder.CreateTable(
                name: "ThesesUserEntries",
                columns: table => new
                {
                    ThesesId = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesesUserEntries", x => new { x.StudentId, x.ThesesId });
                    table.ForeignKey(
                        name: "FK_ThesesUserEntries_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThesesUserEntries_Theses_ThesesId",
                        column: x => x.ThesesId,
                        principalTable: "Theses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThesesUserEntries_ThesesId",
                table: "ThesesUserEntries",
                column: "ThesesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThesesUserEntries");

            migrationBuilder.CreateTable(
                name: "ThesesUserEntry",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ThesesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesesUserEntry", x => new { x.StudentId, x.ThesesId });
                    table.ForeignKey(
                        name: "FK_ThesesUserEntry_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThesesUserEntry_Theses_ThesesId",
                        column: x => x.ThesesId,
                        principalTable: "Theses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThesesUserEntry_ThesesId",
                table: "ThesesUserEntry",
                column: "ThesesId");
        }
    }
}
