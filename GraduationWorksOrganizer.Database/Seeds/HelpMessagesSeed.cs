using GraduationWorksOrganizer.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
            typeBuilder.HasData(new HelpMessage() { Id = 1, Key = "email", Title = "Имейл", Content = "Моля, попълнете имейл за потвърждение на регистрацията" });
            typeBuilder.HasData(new HelpMessage() { Id = 2, Key = "password", Title = "Парола", Content = "Моля попълнете вашата парола. (Паролата трябва да съдържа поне 8 символа, главна буква, малка буква както и поне едно число)" });
            typeBuilder.HasData(new HelpMessage() { Id = 3, Key = "confirmpassword", Title = "Потвърдажане на парола", Content = "Моля, повторете вашата парола." });
            typeBuilder.HasData(new HelpMessage() { Id = 4, Key = "faculty", Title = "Факултет", Content = "Изберете факултет от падащото меню." });
            typeBuilder.HasData(new HelpMessage() { Id = 5, Key = "department", Title = "Катедра", Content = "Изберете катедра от падащото меню." });
            typeBuilder.HasData(new HelpMessage() { Id = 6, Key = "specialty", Title = "Специалност", Content = "Изберете специалност от падащото меню." });
            typeBuilder.HasData(new HelpMessage() { Id = 7, Key = "group", Title = "Група", Content = "Изберете група от падащото меню." });
            typeBuilder.HasData(new HelpMessage() { Id = 8, Key = "names", Title = "Имена", Content = "Моля, попълнете вашите имена." });
            typeBuilder.HasData(new HelpMessage() { Id = 9, Key = "personalnumber", Title = "ЕГН", Content = "Моля, попълнете вашето ЕГН или ЛЧН." });
            typeBuilder.HasData(new HelpMessage() { Id = 10, Key = "facultynumber", Title = "Факултетен Номер", Content = "Моля, попълнете вашия факултетен номер." });
            typeBuilder.HasData(new HelpMessage() { Id = 11, Key = "defaultregisterstudenthelpmessage", Title = "Регистрация на студент", Content = "Моля, попълнете полетата във формата за регистрация на студент и натиснете бутона 'Регистрация'. (за да се регистрирате успешно в системата, трябва да попълните полетата с верни данни, след което да потвърдите вашата регистрация на чрез имейл за потвърждение. Имейлът за потвърждение ще бъде изпратен на посочената от вас поща.)." });
            typeBuilder.HasData(new HelpMessage() { Id = 12, Key = "defaultregisterteacherhelpmessage", Title = "Регистрация на преподавател", Content = "Моля, попълнете полетата във формата за регистрация на преподавател и натиснете бутона 'Регистрация'. (за да се регистрирате успешно в системата, трябва да попълните полетата с верни данни, след което да потвърдите вашата регистрация на чрез имейл за потвърждение. Имейлът за потвърждение ще бъде изпратен на посочената от вас поща.)." });
            typeBuilder.HasData(new HelpMessage() { Id = 13, Key = "cabinet", Title = "Кабинет", Content = "тест" });
            typeBuilder.HasData(new HelpMessage() { Id = 14, Key = "phonenumber", Title = "Телефонен номер", Content = "тест" });
            typeBuilder.HasData(new HelpMessage() { Id = 15, Key = "sciencedegree", Title = "Научна степен", Content = "тест" });
            //typeBuilder.HasData(new HelpMessage() { Id = 15, Key = "names", Title = "Имена", Content = "Моля, попълнете вашите имена." });
            //typeBuilder.HasData(new HelpMessage() { Id = 16, Key = "names", Title = "Имена", Content = "Моля, попълнете вашите имена." });
            //typeBuilder.HasData(new HelpMessage() { Id = 17, Key = "names", Title = "Имена", Content = "Моля, попълнете вашите имена." });

        }
    }
}
