using GraduationWorksOrganizer.Core.Database.Models;
using System;
using System.Collections.Generic;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Оценка на защитата
    /// </summary>
    public class ThesisMark : IDatabaseEntity, IAuditableEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Оценка
        /// </summary>
        public decimal Mark { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Резилтат
        /// </summary>
        public ICollection<ThesisRequerment> MarkResults { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}
