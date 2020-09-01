
using System.ComponentModel.DataAnnotations;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels
{
    /// <summary>
    /// Клас за добавяне на тема
    /// </summary>
    public class AddThesesViewModel
    {
        /// <summary>
        /// Заглавие
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Специалност
        /// </summary>
        [Required]
        public int SpecialtyId { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        [Required]
        public string Type { get; set; }
    }
}
