using GraduationWorksOrganizer.Core.Database.Models;
using System.Collections.Generic;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Модел за комисия
    /// </summary>
    public class Commission : IDatabaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Катедра
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// Катедра от която е комисията
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Главен Преподавател
        /// </summary>
        public Teacher MainCommissionTeacher { get; set; }

        /// <summary>
        /// Ид на главния преподавател в комисията
        /// </summary>
        public string MainCommissionTeacherId { get; set; }

        /// <summary>
        /// Преподаватели в комисията
        /// </summary>
        public ICollection<Teacher> CommissionTeachers { get; set; }

        /// <summary>
        /// Дати за защита
        /// </summary>
        public ICollection<CommissionDefencesDates> CommissionDefencesDates { get; set; }
    }
}
