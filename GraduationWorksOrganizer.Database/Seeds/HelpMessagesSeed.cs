using GraduationWorksOrganizer.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraduationWorksOrganizer.Database.Seeds
{
    /// <summary>
    /// Клас с данните за seed на HelpMessages
    /// </summary>
    internal static class HelpMessagesSeed
    {
        /// <summary>
        /// Метод който сийдва данните
        /// </summary>
        /// <param name="typeBuilder"></param>
        internal static void SeedData(this EntityTypeBuilder<HelpMessage> typeBuilder)
        {
            typeBuilder.HasData(new HelpMessage() { Key = "email", Title = "Имейл", Content = "тест" });
            typeBuilder.HasData(new HelpMessage() { Key = "password", Title = "Парола", Content = "тест" });
            typeBuilder.HasData(new HelpMessage() { Key = "confirmpassword", Title = "Потжърьдажане на парола", Content = "тест" });
            typeBuilder.HasData(new HelpMessage() { Key = "faculty", Title = "Факултет", Content = "тест" });
            typeBuilder.HasData(new HelpMessage() { Key = "department", Title = "Катедра", Content = "тест" });
            typeBuilder.HasData(new HelpMessage() { Key = "specialty", Title = "Специалност", Content = "тест" });
            typeBuilder.HasData(new HelpMessage() { Key = "group", Title = "Група", Content = "тест" });
            typeBuilder.HasData(new HelpMessage() { Key = "names", Title = "Имена", Content = "тест" });
            typeBuilder.HasData(new HelpMessage() { Key = "personalnumber", Title = "ЕГН", Content = "тест" });
            typeBuilder.HasData(new HelpMessage() { Key = "facultynumber", Title = "Факултетен Номер", Content = "тест" });
        }
    }
}
