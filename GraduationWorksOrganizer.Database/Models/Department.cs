using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Database.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public virtual Faculty Faculty { get; set; }

        public int FacultyId { get; set; }

        public virtual ICollection<Specialty> Specialties { get; set; }
    }
}
