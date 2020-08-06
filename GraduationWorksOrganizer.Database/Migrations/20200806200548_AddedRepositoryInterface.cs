using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class AddedRepositoryInterface : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Specialties_SpecialtyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Deparments_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Deparments_Faculties_FacultyId",
                table: "Deparments");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialties_Deparments_DepartmentId",
                table: "Specialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deparments",
                table: "Deparments");

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "SpecialtyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "SpecialtyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "SpecialtyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "SpecialtyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "SpecialtyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Deparments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deparments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Deparments",
                keyColumn: "DepartmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "FacultyId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Deparments");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Specialties",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Faculties",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Deparments",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deparments",
                table: "Deparments",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "FacultyName" },
                values: new object[] { 1, "Факултет Компютърни системи и технологии" });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "FacultyName" },
                values: new object[] { 2, "Факултет по телекомуникации" });

            migrationBuilder.InsertData(
                table: "Deparments",
                columns: new[] { "Id", "DepartmentName", "FacultyId" },
                values: new object[] { 1, "Програмиране и компютърни технологии", 1 });

            migrationBuilder.InsertData(
                table: "Deparments",
                columns: new[] { "Id", "DepartmentName", "FacultyId" },
                values: new object[] { 2, "Компютърни системи", 1 });

            migrationBuilder.InsertData(
                table: "Deparments",
                columns: new[] { "Id", "DepartmentName", "FacultyId" },
                values: new object[] { 3, "Радиокомуникации и видеотехнологии", 2 });

            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "DepartmentId", "SpecialtyName", "SpecialtyType" },
                values: new object[,]
                {
                    { 1, 1, "Графичен и web дизайн", 0 },
                    { 2, 2, "Компютърно и софтуерно инженерство", 0 },
                    { 3, 2, "Компютърно и софтуерно инженерство", 1 },
                    { 4, 3, "Телекомуникации", 0 },
                    { 5, 3, "Телекомуникационно инженерство", 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Specialties_SpecialtyId",
                table: "AspNetUsers",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Deparments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Deparments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deparments_Faculties_FacultyId",
                table: "Deparments",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialties_Deparments_DepartmentId",
                table: "Specialties",
                column: "DepartmentId",
                principalTable: "Deparments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Specialties_SpecialtyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Deparments_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Deparments_Faculties_FacultyId",
                table: "Deparments");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialties_Deparments_DepartmentId",
                table: "Specialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deparments",
                table: "Deparments");

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Deparments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deparments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Deparments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Deparments");

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Specialties",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Deparments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties",
                column: "SpecialtyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faculties",
                table: "Faculties",
                column: "FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deparments",
                table: "Deparments",
                column: "DepartmentId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Specialties_SpecialtyId",
                table: "AspNetUsers",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Deparments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Deparments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Deparments_Faculties_FacultyId",
                table: "Deparments",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialties_Deparments_DepartmentId",
                table: "Specialties",
                column: "DepartmentId",
                principalTable: "Deparments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
