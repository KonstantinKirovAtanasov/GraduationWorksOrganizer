using GraduationWorksOrganizer.Common.Attributes;
using GraduationWorksOrganizer.Core.Database.Models;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Модел за предмет
    /// </summary>
    public class Subject : IDatabaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [EntityEnumValue]
        public int Id { get; set; }

        /// <summary>
        /// Специалност
        /// </summary>
        public Specialty Specialty { get; set; }

        /// <summary>
        /// Ид на Специалността
        /// </summary>
        public int SpecialtyId { get; set; }

        /// <summary>
        /// Име на друпата
        /// </summary>
        [EntityEnumName]
        public string Name { get; set; }
    }
}
