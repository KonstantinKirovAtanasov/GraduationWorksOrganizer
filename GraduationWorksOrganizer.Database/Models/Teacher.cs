using Microsoft.AspNetCore.Identity;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Учител
    /// </summary>
    public class Teacher : IdentityUser
    {
        /// <summary>
        /// Имена
        /// </summary>
        public string TeacherName { get; set; }

        /// <summary>
        /// Катедра
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// ИД на катедрата
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Кабинет
        /// </summary>
        public string Cabinet { get; set; }

        /// <summary>
        /// Научна степен
        /// </summary>
        public string ScienceDegree { get; set; }
    }
}
