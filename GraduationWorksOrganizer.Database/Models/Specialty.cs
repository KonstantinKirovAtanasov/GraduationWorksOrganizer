using System.Collections.Generic;

namespace GraduationWorksOrganizer.Database.Models
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }

        public string SpecialtyName { get; set; }

        public SpecialtyType SpecialtyType { get; set; }

        public virtual Department Department { get; set; }

        public int DepartmentId { get; set; }
    }
}
