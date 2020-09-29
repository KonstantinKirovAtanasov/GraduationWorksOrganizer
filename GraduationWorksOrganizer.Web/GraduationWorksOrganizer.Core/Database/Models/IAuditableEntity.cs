using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Core.Database.Models
{
    public interface IAuditableEntity
    {
        DateTime CreationDate { get; set; }

        DateTime LastModified { get; set; }
    }
}
