using GraduationWorksOrganizer.Common.Attributes;
using GraduationWorksOrganizer.Core.Database.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Факултет
    /// </summary>
    public class Faculty : IDatabaseEntity
    {
        [EntityEnumValue]
        public int Id { get; set; }

        [EntityEnumName]
        public string FacultyName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
