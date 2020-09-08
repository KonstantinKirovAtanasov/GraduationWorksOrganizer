using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services.Base;
using System.Linq;

namespace GraduationWorksOrganizer.Database.Services
{
    /// <summary>
    /// Сървиз 
    /// </summary>
    public class UserEntryFilesDatabaseService : BaseRepository<ThesisUserEntryFileContent>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dataContext"></param>
        public UserEntryFilesDatabaseService(GraduationWorksOrganizerDataContext dataContext)
            : base(dataContext)
        {

        }

        /// <summary>
        /// Метод който връща Query за FileContent-на 1 userEntry
        /// </summary>
        /// <returns></returns>
        public IQueryable<ThesisUserEntryFileContent> GetThesisFileContentQuery(int userEntryId)
        {
            return _dbContext.UserEntryFileContent.Where(tf => tf.UserEntryId == userEntryId);
        }
    }
}
