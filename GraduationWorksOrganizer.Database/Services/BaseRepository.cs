using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Core.Database.Models;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод за изтриване
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Delete<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод за промяна
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Edit<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод който връща всички елементи от дадения тип
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class, IDatabaseEntity
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод който връща всички елементи от дадения тип по експешън
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IDatabaseEntity
        {
            throw new NotImplementedException();
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
        Task IAsyncRepository.Add<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод за изтриване
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        Task IAsyncRepository.Delete<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод за промяна
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        async Task IAsyncRepository.Edit<TEntity>(TEntity entity)
        {
            TEntity dbEntity = await _dbContext.Set<TEntity>().FindAsync(entity.Id);
        }

        /// <summary>
        /// Метод който връща всички елементи от дадения тип
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> IAsyncRepository.GetAll<TEntity>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод който връща всички елементи от дадения тип по експешън
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> IAsyncRepository.GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод който връща обекта по ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> IAsyncRepository.GetById<TEntity>(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
