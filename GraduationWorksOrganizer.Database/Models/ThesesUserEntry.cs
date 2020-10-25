using GraduationWorksOrganizer.Core.Database.Models;
using System;
using System.Collections.Generic;
using static GraduationWorksOrganizer.Common.Enums;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Модел за записвания за теми
    /// </summary>
    public class ThesesUserEntry : IDatabaseEntity, IAuditableEntity
    {
        /// <summary>
        /// Ид
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// Статус за етапа на записаната тема
        /// </summary>
        public ThesisUserEntryState State { get; set; }

        /// <summary>
        /// Изпращания за удобрение дати за защита
        /// </summary>
        public ICollection<ThesisApprovementRequest> ThesesRequests { get; set; }

        public ThesisDefenceEvent ThesisDefenceEvent { get; set; }

        public int? ThesisDefenceEventId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastModified { get; set; }
    }
}
