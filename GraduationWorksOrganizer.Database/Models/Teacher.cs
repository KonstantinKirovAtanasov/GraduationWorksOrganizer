using Microsoft.AspNetCore.Identity;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// Учител
    /// </summary>
    public class Teacher : IdentityUser
    {
        public string TeacherName { get; set; }

        public virtual Department Department { get; set; }

        public int DepartmentId { get; set; }
    }
}
