using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Core.Database.Models
{
    /// <summary>
    /// Интерфейс за преподавател
    /// </summary>
    public interface ITeacher
    {
        /// <summary>
        /// Ид на учителя
        /// </summary>
        string TeacherId { get; set; }

    }
}
