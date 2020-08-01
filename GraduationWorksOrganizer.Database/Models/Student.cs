using Microsoft.AspNetCore.Identity;

namespace GraduationWorksOrganizer.Database.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Student : IdentityUser
    {
        public virtual Specialty Specialty { get; set; }

        public int SpecialtyId { get; set; }
    }
}
