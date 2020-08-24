using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Core.Additional
{
    /// <summary>
    /// Интерфейс за изпращане на имейли
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Конфигурация на СМТП
        /// </summary>
        ISMTPConfiguration Configurations { get; }

        /// <summary>
        /// Метод за промяна на конфигурацията на СМТП
        /// </summary>
        /// <param name="config"></param>
        void SetConfigurations(ISMTPConfiguration config);

        /// <summary>
        /// Метод за изпращне на съобщение за активация
        /// </summary>
        /// <param name="reciever">Получател</param>
        /// <param name="comfirmationLink">Линк за потвърждение</param>
        /// <returns></returns>
        Task SendComfirmationMessageAsync(string reciever, string comfirmationLink);
    }
}
