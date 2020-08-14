using Microsoft.AspNetCore.Identity;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Студент
    /// </summary>
    public class Student : IdentityUser
    {
        /// <summary>
        /// Специалност
        /// </summary>
        public virtual Specialty Specialty { get; set; }

        /// <summary>
        /// ИД на специалността
        /// </summary>
        public int SpecialtyId { get; set; }

        /// <summary>
        /// Група
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// Ид на групата
        /// </summary>
        public int GroupId { get; set; }
    }
}
