using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using System.Linq;

namespace GraduationWorksOrganizer.Database.Services
{
    /// <summary>
    /// Сървиз 
    /// </summary>
    public class UserEntryFilesDatabaseService : CombinedQueryBaseService<ThesisUserEntryFileContent>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dataContext"></param>
        public UserEntryFilesDatabaseService(GraduationWorksOrganizerDataContext dataContext)
            : base(dataContext)
        {

        }
    }
}
