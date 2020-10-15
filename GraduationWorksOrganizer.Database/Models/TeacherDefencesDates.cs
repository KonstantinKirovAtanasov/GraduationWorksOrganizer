using GraduationWorksOrganizer.Core.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Модел за дати за защита 
    /// </summary>
    public class TeacherDefencesDates : IDatabaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Кратко описание
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Номер на зала
        /// </summary>
        public string HallNumber { get; set; }

        /// <summary>
        /// Начало
        /// </summary>
        public DateTime StartingDate { get; set; }

        /// <summary>
        /// Край
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Максимален брой защити
        /// </summary>
        public int MaxThesisCount { get; set; }

        /// <summary>
        /// Преподавател
        /// </summary>
        public Teacher Teacher { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public string TeacherId { get; set; }

        /// <summary>
        /// Защити
        /// </summary>
        public ICollection<ThesisDefenceEvent> Defences { get; set; }
    }
}
