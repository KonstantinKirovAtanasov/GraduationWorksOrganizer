using Microsoft.AspNetCore.Identity;

namespace GraduationWorksOrganizer.Database.Models.Base
{
    /// <summary>
    /// Модел за Идентичност в приложенеито
    /// </summary>
    public class ApplicationIdentityBase : IdentityUser
    {
        /// <summary>
        /// Име
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Снимка
        /// </summary>
        public byte[] Image { get; set; }
    }
}
