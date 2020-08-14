using GraduationWorksOrganizer.Core.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Група
    /// </summary>
    public class Group : IDatabaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Специалност
        /// </summary>
        public Specialty Specialty { get; set; }

        /// <summary>
        /// Ид на Специалността
        /// </summary>
        public int SpecialtyId { get; set; }

        /// <summary>
        /// Студенти
        /// </summary>
        public ICollection<Student> Students { get; set; }

        /// <summary>
        /// Година на откриване на групата
        /// </summary>
        public int FromYear { get; set; }

        /// <summary>
        /// Име на друпата
        /// </summary>
        public string GroupName { get; set; }
    }
}
