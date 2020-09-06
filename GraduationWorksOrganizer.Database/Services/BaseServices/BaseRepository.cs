using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Core.Database.Models;
using GraduationWorksOrganizer.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Database.Services.Base
{
    /// <summary>
    /// Клас за базови действия с базата данни
    /// </summary>
    public class BaseRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : class, IDatabaseEntity
    {
        #region Declarations

        /// <summary>
        /// Контекст
        /// </summary>
        protected readonly GraduationWorksOrganizerDataContext _dbContext;

        #endregion

        #region Constructor

        /// <summary>
        /// КОнструктор
        /// </summary>
        /// <param name="dbContext"></param>
        public BaseRepository(GraduationWorksOrganizerDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Implementation IAsyncRepository

        /// <summary>
        /// Метод за добавяне
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public async Task Add(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод за изтриване
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public async Task Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод който връща всички елементи от дадения тип
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Метод който връща всички елементи от дадения тип по експешън
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Метод който връща обекта по ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        #endregion //  Implementation IAsyncRepository

        public IQueryable<Theses> GetAllIncluding(params Expression<Func<Theses, object>>[] propertySelectors)
        {
            IQueryable<Theses> resultQuery = _dbContext.Theses;
            if (propertySelectors != null)
            {
                foreach (Expression<Func<Theses, object>> propertySelector in propertySelectors)
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

        public IQueryable<Theses> GetAllIncluding(Expression<Func<Theses, object>> propertySelector)
        {
            IQueryable<Theses> resultQuery = _dbContext.Theses;
            if (propertySelector != null
                || propertySelector.ReturnType.IsAssignableFrom(typeof(IDatabaseEntity))
                || propertySelector.ReturnType.GenericTypeArguments.First().IsAssignableFrom(typeof(IDatabaseEntity)))
            {
                resultQuery = resultQuery.Include(propertySelector);
            }

            return resultQuery;
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
