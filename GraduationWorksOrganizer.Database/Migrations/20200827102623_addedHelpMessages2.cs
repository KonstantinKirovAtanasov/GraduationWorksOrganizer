using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class addedHelpMessages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HelpMessages",
                columns: new[] { "Id", "Content", "Key", "Title" },
                values: new object[,]
                {
                    { 12, "Моля, попълнете полетата във формата за регистрация на преподавател и натиснете бутона 'Регистрация'. (за да се регистрирате успешно в системата, трябва да попълните полетата с верни данни, след което да потвърдите вашата регистрация на чрез имейл за потвърждение. Имейлът за потвърждение ще бъде изпратен на посочената от вас поща.).", "defaultregisterteacherhelpmessage", "Регистрация на преподавател" },
                    { 13, "тест", "cabinet", "Кабинет" },
                    { 14, "тест", "phonenumber", "Телефонен номер" },
                    { 15, "тест", "sciencedegree", "Научна степен" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
