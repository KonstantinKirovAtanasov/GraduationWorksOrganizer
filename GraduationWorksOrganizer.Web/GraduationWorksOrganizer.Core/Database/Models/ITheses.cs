using System;
using static GraduationWorksOrganizer.Common.Enums;

namespace GraduationWorksOrganizer.Core.Database.Models
{
    /// <summary>
    /// Интерфейс за модел (тема)
    /// </summary>
    public interface ITheses : IDatabaseEntity
    {
        /// <summary>
        /// Дата на създаване на темата
        /// </summary>
        DateTime CreationDate { get; set; }

        /// <summary>
        /// Заглавие
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Статус на тезата
        /// </summary>
        ThesesStatusType Status { get; set; }

        /// <summary>
        /// Ид на Създателя на темата
        /// </summary>
        string CreatorId { get; set; }

        /// <summary>
        /// Id на специалност
        /// </summary>
        int TargetSpecialtyId { get; set; }
    }
}
