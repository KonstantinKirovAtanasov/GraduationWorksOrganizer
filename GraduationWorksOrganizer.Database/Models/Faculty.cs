using GraduationWorksOrganizer.Common.Attributes;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Факултет
    /// </summary>
    public class Faculty
    {
        [EntityEnumValue]
        public int FacultyId { get; set; }

        [EntityEnumName]
        public string FacultyName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
