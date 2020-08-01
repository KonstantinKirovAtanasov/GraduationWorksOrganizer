using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class FacultiesDepartmentsSpecialties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyId);
                });

            migrationBuilder.CreateTable(
                name: "Deparments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deparments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Deparments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    SpecialtyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialtyName = table.Column<string>(nullable: true),
                    SpecialtyType = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.SpecialtyId);
                    table.ForeignKey(
                        name: "FK_Specialties_Deparments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Deparments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "FacultyId", "FacultyName" },
                values: new object[] { 1, "Факултет Компютърни системи и технологии" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "FacultyId", "FacultyName" },
                values: new object[] { 2, "Факултет по телекомуникации" });

            migrationBuilder.InsertData(
                table: "Deparments",
                columns: new[] { "DepartmentId", "DepartmentName", "FacultyId" },
                values: new object[] { 1, "Програмиране и компютърни технологии", 1 });

            migrationBuilder.InsertData(
                table: "Deparments",
                columns: new[] { "DepartmentId", "DepartmentName", "FacultyId" },
                values: new object[] { 2, "Компютърни системи", 1 });

            migrationBuilder.InsertData(
                table: "Deparments",
                columns: new[] { "DepartmentId", "DepartmentName", "FacultyId" },
                values: new object[] { 3, "Радиокомуникации и видеотехнологии", 2 });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "SpecialtyId", "DepartmentId", "SpecialtyName", "SpecialtyType" },
                values: new object[,]
                {
                    { 1, 1, "Графичен и web дизайн", 0 },
                    { 2, 2, "Компютърно и софтуерно инженерство", 0 },
                    { 3, 2, "Компютърно и софтуерно инженерство", 1 },
                    { 4, 3, "Телекомуникации", 0 },
                    { 5, 3, "Телекомуникационно инженерство", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SpecialtyId",
                table: "AspNetUsers",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Deparments_FacultyId",
                table: "Deparments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_DepartmentId",
                table: "Specialties",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Specialties_SpecialtyId",
                table: "AspNetUsers",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Deparments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Deparments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Specialties_SpecialtyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Deparments_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Deparments");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SpecialtyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "AspNetUsers");
        }
    }
}
