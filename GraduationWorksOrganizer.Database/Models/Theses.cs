using GraduationWorksOrganizer.Core.Database.Models;
using Microsoft.AspNetCore.Identity;
using System;
using static GraduationWorksOrganizer.Common.Enums;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Модел за тема
    /// </summary>
    public class Theses : ITheses
    {
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
        /// Статус
        /// </summary>
        public ThesesStatusType Status { get; set; }

        /// <summary>
        /// Създател
        /// </summary>
        public IdentityUser Creator { get; set; }

        /// <summary>
        /// Ид на Създателя на темата
        /// </summary>
        public string CreatorId { get; set; }

        /// <summary>
        /// Специалност
        /// </summary>
        public Specialty TargetSpecialty { get; set; }

        /// <summary>
        /// Id на специалност
        /// </summary>
        public int TargetSpecialtyId { get; set; }
    }
}
