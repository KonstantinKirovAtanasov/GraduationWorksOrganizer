using GraduationWorksOrganizer.Core.Database.Models;
using System;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ThesisApprovementRequest : IDatabaseEntity, IAuditableEntity
    {
        /// <summary>
        /// Ид
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тема 
        /// </summary>
        public ThesesUserEntry ThesesUserEntry { get; set; }

        /// <summary>
        /// Ид на тезата
        /// </summary>
        public int ThesesUserEntryId { get; set; }

        /// <summary>
        /// Наблюдаващ темата
        /// </summary>
        public Teacher ThemeObserver { get; set; }

        /// <summary>
        /// Id на наблюдаващ темата
        /// </summary>
        public string ThemeObserverId { get; set; }

        /// <summary>
        /// Описание на Request-а
        /// </summary>
        public string RequestDescription { get; set; }

        /// <summary>
        /// Описание на Request-а
        /// </summary>
        public string ResponseDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}
