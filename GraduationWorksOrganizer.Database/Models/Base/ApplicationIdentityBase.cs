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
        /// Релация за снимка
        /// </summary>
        public FileContent Image { get; set; }

        /// <summary>
        /// Ид на снимката
        /// </summary>
        public int ImageId { get; set; }
    }
}
