using GraduationWorksOrganizer.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Database.Models
{
    public class Department
    {
        [EntityEnumValue]
        public int DepartmentId { get; set; }

        [EntityEnumName]
        public string DepartmentName { get; set; }

        public virtual Faculty Faculty { get; set; }

        public int FacultyId { get; set; }

        public virtual ICollection<Specialty> Specialties { get; set; }
    }
}
