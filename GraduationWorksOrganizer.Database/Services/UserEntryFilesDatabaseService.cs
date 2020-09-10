using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using System.Linq;
using System.Threading.Tasks;

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

        /// <summary>
        /// Метод който добавя нов файл и го връща с ИД
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ThesisUserEntryFileContent> AddAsync(ThesisUserEntryFileContent entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
