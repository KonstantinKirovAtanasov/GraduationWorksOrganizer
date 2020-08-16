using GraduationWorksOrganizer.Common.Attributes;
using GraduationWorksOrganizer.Core.Database.Models;
using System.Collections.Generic;

namespace GraduationWorksOrganizer.Database.Models
{
    public class Department : IEnumDbEntity, IDatabaseEntity
    {
        [EntityEnumValue]
        public int Id { get; set; }

        [EntityEnumName]
        public string Name { get; set; }

        public virtual Faculty Faculty { get; set; }

        public int FacultyId { get; set; }

        public virtual ICollection<Specialty> Specialties { get; set; }
    }
}
