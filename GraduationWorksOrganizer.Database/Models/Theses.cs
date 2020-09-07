using GraduationWorksOrganizer.Core.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using System;
using System.Collections.Generic;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Модел за тема
    /// </summary>
    public class Theses : IDatabaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Theses()
        {
            Requerments = new HashSet<ThesisRequerment>();
            UserEntries = new HashSet<ThesesUserEntry>();
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата на създаване
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Заглавие
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// тип
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Създател
        /// </summary>
        public ApplicationIdentityBase Creator { get; set; }

        /// <summary>
        /// Ид на Създателя на темата
        /// </summary>
        public string CreatorId { get; set; }

        /// <summary>
        /// Специалност
        /// </summary>
        public Subject Subject { get; set; }

        /// <summary>
        /// Id на специалност
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Изисквания
        /// </summary>
        public ICollection<ThesisRequerment> Requerments { get; set; }

        /// <summary>
        /// Записвания
        /// </summary>
        public ICollection<ThesesUserEntry> UserEntries { get; set; }
    }
}
