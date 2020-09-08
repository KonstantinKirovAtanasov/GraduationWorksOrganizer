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
        public CommissionDefencesDates DefencesDate { get; set; }

        /// <summary>
        /// Ид на датата на защита
        /// </summary>
        public int DefenceDateId { get; set; }

        /// <summary>
        /// Студент
        /// </summary>
        public Student Student { get; set; }

        /// <summary>
        /// Ид на студента
        /// </summary>
        public string StudentId { get; set; }

        /// <summary>
        /// Тема
        /// </summary>
        public Theses Thesis { get; set; }

        /// <summary>
        /// Ид на темата
        /// </summary>
        public int ThesisId { get; set; }

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
