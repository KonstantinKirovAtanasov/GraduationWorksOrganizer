using GraduationWorksOrganizer.Core.Additional;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Additional.SMTP
{
    public class ComformationEmailSender : IEmailSender, Microsoft.AspNetCore.Identity.UI.Services.IEmailSender, IDisposable
    {
        private SmtpClient smtp;

        public ISMTPConfiguration Configurations { get; private set; }

        public ComformationEmailSender()
        {
            smtp = new SmtpClient();
            SetConfigurations(SMTPConfiguration.Default);
        }

        public async Task SendComfirmationMessageAsync(string reciever, string comfirmationLink)
        {
            MailMessage message = new MailMessage(new MailAddress(Configurations.UserEmail), new MailAddress(reciever));
            message.Body = Configurations.MessageTemplate.Replace("#ConfirmationLink#", comfirmationLink);
            message.Subject = "Confirmation";
            message.IsBodyHtml = Configurations.IsHTML;

            try
            {
                await smtp.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                //TODO: Log Exceptions
            }
        }

        public void SetConfigurations(ISMTPConfiguration config)
        {
            Configurations = config;

            smtp.Host = Configurations.SMTPHost;
            smtp.Port = Configurations.SMTPPort;
            smtp.EnableSsl = Configurations.UseSSl;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Credentials = new NetworkCredential()
            {
                UserName = Configurations.UserEmail,
                Password = Configurations.UserEmailPassword
            };
            Configurations.UserEmailPassword = string.Empty;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await smtp.SendMailAsync(new MailMessage(new MailAddress(Configurations.UserEmail), new MailAddress(email))
            {
                Body = htmlMessage,
                Subject = subject,
            });
        }

        public void Dispose()
        {
            smtp.Dispose();
        }
    }
}
