using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduationWorksOrganizer.Database.Migrations
{
    public partial class AddedHelpMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HelpMessages",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpMessages", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "HelpMessages",
                columns: new[] { "Key", "Content", "Title" },
                values: new object[,]
                {
                    { "email", "тест", "Имейл" },
                    { "password", "тест", "Парола" },
                    { "confirmpassword", "тест", "Потжърьдажане на парола" },
                    { "faculty", "тест", "Факултет" },
                    { "department", "тест", "Катедра" },
                    { "specialty", "тест", "Специалност" },
                    { "group", "тест", "Група" },
                    { "names", "тест", "Имена" },
                    { "personalnumber", "тест", "ЕГН" },
                    { "facultynumber", "тест", "Факултетен Номер" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HelpMessages");
        }
    }
}
