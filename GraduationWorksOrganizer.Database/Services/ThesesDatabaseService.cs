using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services.Base;
using System;
using System.Linq;

namespace GraduationWorksOrganizer.Database.Services
{
    /// <summary>
    /// ДБ Сървис за работа с теми
    /// </summary>
    public class ThesesDatabaseService : BaseRepository<Theses>
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

        #endregion
    }
}
