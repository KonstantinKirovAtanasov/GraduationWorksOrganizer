using System;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels
{
    /// <summary>
    /// VM за теза
    /// </summary>
    public class ThesesViewModel
    {
        /// <summary>
        /// Ид на тезата
        /// </summary>
        public int ThesesId { get; set; }

        /// <summary>
        /// Ид на специалността
        /// </summary>
        public int SpecialtyId { get; set; }

        /// <summary>
        /// Заглавие
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Създател
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        ///Дата на създаване
        /// </summary>
        public DateTime CreationDate { get; set; }
    }
}
