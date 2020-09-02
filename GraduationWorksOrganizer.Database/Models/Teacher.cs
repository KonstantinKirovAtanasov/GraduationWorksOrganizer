using GraduationWorksOrganizer.Database.Models.Base;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Учител
    /// </summary>
    public class Teacher : ApplicationIdentityBase
    {
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
