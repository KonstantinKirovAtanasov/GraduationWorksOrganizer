using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class IdAddedOnHelpMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HelpMessages",
                table: "HelpMessages");

            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Key",
                keyValue: "confirmpassword");

            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Key",
                keyValue: "department");

            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Key",
                keyValue: "email");

            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Key",
                keyValue: "faculty");

            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Key",
                keyValue: "facultynumber");

            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Key",
                keyValue: "group");

            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Key",
                keyValue: "names");

            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Key",
                keyValue: "password");

            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Key",
                keyValue: "personalnumber");

            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Key",
                keyValue: "specialty");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "HelpMessages",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HelpMessages",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HelpMessages",
                table: "HelpMessages",
                column: "Id");

            migrationBuilder.InsertData(
                table: "HelpMessages",
                columns: new[] { "Id", "Content", "Key", "Title" },
                values: new object[,]
                {
                    { 1, "тест", "email", "Имейл" },
                    { 2, "тест", "password", "Парола" },
                    { 3, "тест", "confirmpassword", "Потжърьдажане на парола" },
                    { 4, "тест", "faculty", "Факултет" },
                    { 5, "тест", "department", "Катедра" },
                    { 6, "тест", "specialty", "Специалност" },
                    { 7, "тест", "group", "Група" },
                    { 8, "тест", "names", "Имена" },
                    { 9, "тест", "personalnumber", "ЕГН" },
                    { 10, "тест", "facultynumber", "Факултетен Номер" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HelpMessages",
                table: "HelpMessages");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HelpMessages");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "HelpMessages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HelpMessages",
                table: "HelpMessages",
                column: "Key");
        }
    }
}
