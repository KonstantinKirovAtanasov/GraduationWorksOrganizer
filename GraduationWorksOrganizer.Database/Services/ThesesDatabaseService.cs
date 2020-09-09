using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using System;
using System.Linq;

namespace GraduationWorksOrganizer.Database.Services
{
    /// <summary>
    /// ДБ Сървис за работа с теми
    /// </summary>
    public class ThesesDatabaseService : CombinedQueryBaseService<Theses>
    {
        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dataContext"></param>
        public ThesesDatabaseService(GraduationWorksOrganizerDataContext dbContext)
            : base(dbContext)
        {
        }


        #endregion

        #region Methods

        /// <summary>
        /// Метод който връща Query
        /// </summary>
        /// <returns></returns>
        public IQueryable<Theses> GetQuery()
        {
            return _dbContext.Theses;
        }

        /// <summary>
        /// Метод който връща всички записани студенти според темата
        /// </summary>
        /// <param name="thesisId"></param>
        /// <returns></returns>
        public IQueryable<ThesesUserEntry> GetThesisUserEntries(int thesisId)
        {
            return _dbContext.ThesesUserEntries.Where(tue => tue.ThesesId == thesisId);
        }

        #endregion
    }
}
