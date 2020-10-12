using GraduationWorksOrganizer.Core.Database.Models;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Модел за защита на работа
    /// </summary>
    public class ThesisDefenceEvent : IDatabaseEntity
    {
        /// <summary>
        /// Ид
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата на защита  
        /// </summary>
        public TeacherDefencesDates DefencesDate { get; set; }

        /// <summary>
        /// Ид на датата на защита
        /// </summary>
        public int DefenceDateId { get; set; }

        /// <summary>
        /// Тема
        /// </summary>
        public ThesesUserEntry ThesesUserEntry { get; set; }

        /// <summary>
        /// Ид на темата
        /// </summary>
        public int ThesesUserEntryId { get; set; }

        /// <summary>
        /// Оценка
        /// </summary>
        public ThesisMark ThesisMark { get; set; }

        /// <summary>
        /// Ид на оценката
        /// </summary>
        public int? ThesisMarkId { get; set; }
    }
}
