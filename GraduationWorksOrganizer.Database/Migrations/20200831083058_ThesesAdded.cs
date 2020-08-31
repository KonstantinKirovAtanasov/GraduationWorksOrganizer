using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class ThesesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7550788a-eda8-459f-9964-55d0ecc70301");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fe665ab-dbd4-4dd9-8683-f704729a5f87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9f64a38-a798-42a8-9d7c-f52da489cfbb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa380cf7-756d-446e-82ec-240e53466fd4");

            migrationBuilder.CreateTable(
                name: "Theses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    TargetSpecialtyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Theses_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Theses_Specialties_TargetSpecialtyId",
                        column: x => x.TargetSpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Theses_CreatorId",
                table: "Theses",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Theses_TargetSpecialtyId",
                table: "Theses",
                column: "TargetSpecialtyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Theses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f9f64a38-a798-42a8-9d7c-f52da489cfbb", "4033e4da-d94b-4c76-afc6-077e529d9eb8", "Teacher", null },
                    { "9fe665ab-dbd4-4dd9-8683-f704729a5f87", "a1141fd0-0b36-441f-90c1-944e731e8e1b", "Student", null },
                    { "fa380cf7-756d-446e-82ec-240e53466fd4", "970c7f68-8af0-4f88-8f0c-68b00f809b84", "PromotedTeacher", null },
                    { "7550788a-eda8-459f-9964-55d0ecc70301", "7a1fd821-9f34-4ae8-b626-c2933ad8595e", "Admin", null }
                });
        }
    }
}
