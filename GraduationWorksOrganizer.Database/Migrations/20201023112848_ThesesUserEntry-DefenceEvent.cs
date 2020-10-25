using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class ThesesUserEntryDefenceEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThesisDefenceEventId",
                table: "ThesesUserEntries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Marks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Marks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ThesesUserEntries_ThesisDefenceEventId",
                table: "ThesesUserEntries",
                column: "ThesisDefenceEventId",
                unique: true,
                filter: "[ThesisDefenceEventId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ThesesUserEntries_DefenceEvents_ThesisDefenceEventId",
                table: "ThesesUserEntries",
                column: "ThesisDefenceEventId",
                principalTable: "DefenceEvents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThesesUserEntries_DefenceEvents_ThesisDefenceEventId",
                table: "ThesesUserEntries");

            migrationBuilder.DropIndex(
                name: "IX_ThesesUserEntries_ThesisDefenceEventId",
                table: "ThesesUserEntries");

            migrationBuilder.DropColumn(
                name: "ThesisDefenceEventId",
                table: "ThesesUserEntries");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Marks");
        }
    }
}
