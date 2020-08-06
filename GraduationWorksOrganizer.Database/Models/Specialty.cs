using GraduationWorksOrganizer.Common.Attributes;
using System.Collections.Generic;

namespace GraduationWorksOrganizer.Database.Models
{
    public class Specialty
    {
        [EntityEnumValue]
        public int SpecialtyId { get; set; }

        [EntityEnumName]
        public string SpecialtyName { get; set; }

        public SpecialtyType SpecialtyType { get; set; }

        public virtual Department Department { get; set; }

        public int DepartmentId { get; set; }
    }
}
