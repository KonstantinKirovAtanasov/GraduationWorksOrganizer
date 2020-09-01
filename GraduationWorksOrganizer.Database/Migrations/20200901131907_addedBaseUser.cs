using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class addedBaseUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApprovalId",
                table: "Theses",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Theses_ApprovalId",
                table: "Theses",
                column: "ApprovalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Theses_AspNetUsers_ApprovalId",
                table: "Theses",
                column: "ApprovalId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Theses_AspNetUsers_ApprovalId",
                table: "Theses");

            migrationBuilder.DropIndex(
                name: "IX_Theses_ApprovalId",
                table: "Theses");

            migrationBuilder.DropColumn(
                name: "ApprovalId",
                table: "Theses");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
