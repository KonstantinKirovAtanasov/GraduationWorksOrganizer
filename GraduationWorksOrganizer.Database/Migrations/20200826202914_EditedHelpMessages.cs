using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class EditedHelpMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: "Моля, попълнете имейл за потвърждение на регистрацията");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: "Моля попълнете вашата парола. (Паролата трябва да съдържа поне 8 символа, главна буква, малка буква както и поне едно число)");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "Title" },
                values: new object[] { "Моля, повторете вашата парола.", "Потвърдажане на парола" });

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Content",
                value: "Изберете факултет от падащото меню.");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Content",
                value: "Изберете катедра от падащото меню.");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 6,
                column: "Content",
                value: "Изберете специалност от падащото меню.");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 7,
                column: "Content",
                value: "Изберете група от падащото меню.");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 8,
                column: "Content",
                value: "Моля, попълнете вашите имена.");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 9,
                column: "Content",
                value: "Моля, попълнете вашето ЕГН или ЛЧН.");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 10,
                column: "Content",
                value: "Моля, попълнете вашия факултетен номер.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: "тест");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: "тест");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "Title" },
                values: new object[] { "тест", "Потжърьдажане на парола" });

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Content",
                value: "тест");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 5,
                column: "Content",
                value: "тест");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 6,
                column: "Content",
                value: "тест");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 7,
                column: "Content",
                value: "тест");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 8,
                column: "Content",
                value: "тест");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 9,
                column: "Content",
                value: "тест");

            migrationBuilder.UpdateData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 10,
                column: "Content",
                value: "тест");
        }
    }
}
