using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Core.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Database.Services
{
    /// <summary>
    /// Клас за базови действия с базата данни
    /// </summary>
    public class BaseRepository : IRepository, IAsyncRepository
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

        #region Implementation IRepository

        /// <summary>
        /// Метод за добавяне
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Add<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Метод за изтриване
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Delete<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity
        {
            TEntity contextEntity = _dbContext.Set<TEntity>().Find(entity);
            _dbContext.Entry(contextEntity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Метод който връща всички елементи от дадения тип
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class, IDatabaseEntity
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Метод който връща всички елементи от дадения тип по експешън
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IDatabaseEntity
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList();
        }

        /// <summary>
        /// Метод който връща обекта по ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById<TEntity>(int id) where TEntity : class, IDatabaseEntity
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        #endregion //  Implementation IRepository

        #region  Implementation IAsyncRepository

        /// <summary>
        /// Метод за добавяне
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        async Task IAsyncRepository.Add<TEntity>(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод за изтриване
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        async Task IAsyncRepository.Delete<TEntity>(TEntity entity)
        {
            TEntity contextEntity = await _dbContext.Set<TEntity>().FindAsync(entity.Id);
            _dbContext.Entry(contextEntity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод който връща всички елементи от дадения тип
        /// </summary>
        /// <returns></returns>
        async Task<IEnumerable<TEntity>> IAsyncRepository.GetAll<TEntity>()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Метод който връща всички елементи от дадения тип по експешън
        /// </summary>
        /// <returns></returns>
        async Task<IEnumerable<TEntity>> IAsyncRepository.GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Метод който връща обекта по ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        async Task<TEntity> IAsyncRepository.GetById<TEntity>(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        #endregion
    }
}
