using GraduationWorksOrganizer.Database.Models;
using System.Linq;

namespace GraduationWorksOrganizer.Database.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ThesesDatabaseService
    {
        #region Declarations

        /// <summary>
        /// Дата контекст
        /// </summary>
        private GraduationWorksOrganizerDataContext _dbContext;

        #endregion

        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dataContext"></param>
        public ThesesDatabaseService(GraduationWorksOrganizerDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод който връща всички теми
        /// </summary>
        /// <returns></returns>
        public IQueryable<Theses> GetAll()
        {
            return _dbContext.Theses;
        }

        #endregion
    }
}
