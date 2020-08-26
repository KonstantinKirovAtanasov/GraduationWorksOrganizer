using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class AddedNewDefaultMessageForStudentRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HelpMessages",
                columns: new[] { "Id", "Content", "Key", "Title" },
                values: new object[] { 11, "Моля, попълнете полетата във формата за регистрация на студент и натиснете бутона 'Регистрация'. (за да се регистрирате успешно в системата, трябва да попълните полетата с верни данни, след което да потвърдите вашата регистрация на чрез имейл за потвърждение. Имейлът за потвърждение ще бъде изпратен на посочената от вас поща.).", "defaultregisterstudenthelpmessage", "Регистрация на студент" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HelpMessages",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
