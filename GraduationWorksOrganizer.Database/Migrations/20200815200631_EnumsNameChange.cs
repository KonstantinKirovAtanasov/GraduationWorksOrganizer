using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class EnumsNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Group_GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_Specialties_SpecialtyId",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "SpecialtyName",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "FacultyName",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Deparments");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_Group_SpecialtyId",
                table: "Groups",
                newName: "IX_Groups_SpecialtyId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Specialties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Faculties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Deparments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Deparments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Програмиране и компютърни технологии");

            migrationBuilder.UpdateData(
                table: "Deparments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Компютърни системи");

            migrationBuilder.UpdateData(
                table: "Deparments",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Радиокомуникации и видеотехнологии");

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Факултет Компютърни системи и технологии");

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Факултет по телекомуникации");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "39");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "40");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "41");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "42");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "43");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Графичен и web дизайн");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Компютърно и софтуерно инженерство");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Компютърно и софтуерно инженерство");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Телекомуникации");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Телекомуникационно инженерство");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groups_GroupId",
                table: "AspNetUsers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Specialties_SpecialtyId",
                table: "Groups",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groups_GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Specialties_SpecialtyId",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Specialties");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Deparments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_SpecialtyId",
                table: "Group",
                newName: "IX_Group_SpecialtyId");

            migrationBuilder.AddColumn<string>(
                name: "SpecialtyName",
                table: "Specialties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacultyName",
                table: "Faculties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Deparments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Group",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Deparments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DepartmentName",
                value: "Програмиране и компютърни технологии");

            migrationBuilder.UpdateData(
                table: "Deparments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DepartmentName",
                value: "Компютърни системи");

            migrationBuilder.UpdateData(
                table: "Deparments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DepartmentName",
                value: "Радиокомуникации и видеотехнологии");

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1,
                column: "FacultyName",
                value: "Факултет Компютърни системи и технологии");

            migrationBuilder.UpdateData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 2,
                column: "FacultyName",
                value: "Факултет по телекомуникации");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 1,
                column: "GroupName",
                value: "39");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 2,
                column: "GroupName",
                value: "40");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 3,
                column: "GroupName",
                value: "41");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 4,
                column: "GroupName",
                value: "42");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Id",
                keyValue: 5,
                column: "GroupName",
                value: "43");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1,
                column: "SpecialtyName",
                value: "Графичен и web дизайн");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2,
                column: "SpecialtyName",
                value: "Компютърно и софтуерно инженерство");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3,
                column: "SpecialtyName",
                value: "Компютърно и софтуерно инженерство");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4,
                column: "SpecialtyName",
                value: "Телекомуникации");

            migrationBuilder.UpdateData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5,
                column: "SpecialtyName",
                value: "Телекомуникационно инженерство");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Group_GroupId",
                table: "AspNetUsers",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Specialties_SpecialtyId",
                table: "Group",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "Id");
        }
    }
}
