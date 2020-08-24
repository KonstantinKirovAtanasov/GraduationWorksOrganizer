using GraduationWorksOrganizer.Core.Additional;

namespace GraduationWorksOrganizer.Additional.SMTP
{
    /// <summary>
    /// Клас с конфигурация за SMTP
    /// </summary>
    public class SMTPConfiguration : ISMTPConfiguration
    {
        /// <summary>
        /// Дефоутна Конфигурация
        /// </summary>
        public static SMTPConfiguration Default = new SMTPConfiguration()
        {
            IsHTML = true,
            SMTPHost = "smtp.gmail.com",
            SMTPPort = 587,
            UserEmail = "",
            UserEmailPassword = "",
            MessageTemplate = "#ConfirmationLink#",
            UseSSl = true
        };

        public bool IsHTML { get; set; }

        public string SMTPHost { get; set; }

        public int SMTPPort { get; set; }

        public bool UseSSl { get; set; }

        public string UserEmail { get; set; }

        public string UserEmailPassword { get; set; }

        public string MessageTemplate { get; set; }
    }
}
