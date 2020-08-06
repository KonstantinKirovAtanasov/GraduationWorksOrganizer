using GraduationWorksOrganizer.Common.Attributes;
using GraduationWorksOrganizer.Core.Database.Models;

namespace GraduationWorksOrganizer.Database.Models
{
    public class Specialty : IDatabaseEntity
    {
        [EntityEnumValue]
        public int Id { get; set; }

        [EntityEnumName]
        public string SpecialtyName { get; set; }

        public SpecialtyType SpecialtyType { get; set; }

        public virtual Department Department { get; set; }

        public int DepartmentId { get; set; }
    }
}
