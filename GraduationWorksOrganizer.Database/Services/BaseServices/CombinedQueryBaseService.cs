using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Core.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Database.Services.BaseServices
{
    /// <summary>
    /// Базов клас на ДБ сървис който комбинира BaseRepository и IQueryProvider
    /// </summary>
    /// <typeparam name="TDatabaseEntity"></typeparam>
    public class CombinedQueryBaseService<TDatabaseEntity> : BaseRepository<TDatabaseEntity>, IQueryProvider<TDatabaseEntity> where TDatabaseEntity : class, IDatabaseEntity
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext"></param>
        public CombinedQueryBaseService(GraduationWorksOrganizerDataContext dbContext)
            : base(dbContext)
        {

        }

        /// <summary>
        /// Метод който връща Query
        /// </summary>
        /// <returns></returns>
        public IQueryable<TDatabaseEntity> GetQuery()
        {
            return _dbContext.Set<TDatabaseEntity>();
        }

        /// <summary>
        /// Метод койо връща Query с Including
        /// </summary>
        /// <param name="propertySelectors"></param>
        /// <returns></returns>
        public IQueryable<TDatabaseEntity> GetAllIncluding(params Expression<Func<TDatabaseEntity, object>>[] propertySelectors)
        {
            IQueryable<TDatabaseEntity> resultQuery = _dbContext.Set<TDatabaseEntity>();
            if (propertySelectors != null)
            {
                foreach (Expression<Func<TDatabaseEntity, object>> propertySelector in propertySelectors)
                {
                    if (propertySelector.ReturnType.IsAssignableFrom(typeof(IDatabaseEntity))
                        || propertySelector.ReturnType.GenericTypeArguments.First().IsAssignableFrom(typeof(IDatabaseEntity)))
                    {
                        resultQuery = resultQuery.Include(propertySelector);
                    }
                }
            }

            return resultQuery;
        }

        /// <summary>
        /// Метод койо връща Query с Including
        /// </summary>
        /// <param name="propertySelectors"></param>
        /// <returns></returns>
        public IQueryable<TDatabaseEntity> GetAllIncluding(Expression<Func<TDatabaseEntity, object>> propertySelector)
        {
            IQueryable<TDatabaseEntity> resultQuery = _dbContext.Set<TDatabaseEntity>();
            if (propertySelector != null
                || propertySelector.ReturnType.IsAssignableFrom(typeof(IDatabaseEntity))
                || propertySelector.ReturnType.GenericTypeArguments.First().IsAssignableFrom(typeof(IDatabaseEntity)))
            {
                resultQuery = resultQuery.Include(propertySelector);
            }

            return resultQuery;
        }

        /// <summary>
        /// Метод който връща обекта по ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TDatabaseEntity> GetById(int id, params Expression<Func<TDatabaseEntity, object>>[] propertySelectors)
        {
            return await GetAllIncluding(propertySelectors).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}


