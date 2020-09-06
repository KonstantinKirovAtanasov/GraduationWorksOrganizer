using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Модел за записвания за теми
    /// </summary>
    public class ThesesUserEntry
    {
        /// <summary>
        /// Teма
        /// </summary>
        public Theses Theses { get; set; }

        /// <summary>
        /// Id на темата
        /// </summary>
        public int ThesesId { get; set; }

        /// <summary>
        /// Студент
        /// </summary>
        public Student Student { get; set; }

        /// <summary>
        /// Ид на студента
        /// </summary>
        public string StudentId { get; set; }
    }
}
