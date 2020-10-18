using GraduationWorksOrganizer.Core.Database.Models;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Модел за изискване към тема
    /// </summary>
    public class ThesisRequerment : IDatabaseEntity
    {
        /// <summary>
        /// Ид
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Теза
        /// </summary>
        public Theses Theses { get; set; }

        /// <summary>
        /// Ид на тезата
        /// </summary>
        public int ThesesId { get; set; }

        /// <summary>
        /// Максимален брой точки
        /// </summary>
        public decimal MaxPointsCount { get; set; }

        /// <summary>
        /// Максимален брой точки
        /// </summary>
        public decimal? MarkPoints { get; set; }

        public int? ThesesMarkId { get; set; }

        public ThesisMark ThesesMark { get; set; }
    }
}
