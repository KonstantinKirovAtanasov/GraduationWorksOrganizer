using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Core.Database.Models;
using GraduationWorksOrganizer.Database.Services.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GraduationWorksOrganizer.Common.Enums;

namespace GraduationWorksOrganizer.Database.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ThesesDatabaseService : BaseRepository, IThesesDatabaseService
    {
        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dataContext"></param>
        public ThesesDatabaseService(GraduationWorksOrganizerDataContext dbContext)
            : base(dbContext) { }

        #endregion

        /// <summary>
        /// метод който връща всички активни теми
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ITheses>> GetAllActive()
        {
            return await _dbContext.Theses.Where(t => t.Status == ThesesStatusType.Accept).ToListAsync();
        }

        /// <summary>
        /// Метод който връща всички теми за одобрение
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ITheses>> GetAllPending()
        {
            return await _dbContext.Theses.Include(p => p.Creator).Where(t => t.Status == ThesesStatusType.Pending).ToListAsync();
        }
    }
}
