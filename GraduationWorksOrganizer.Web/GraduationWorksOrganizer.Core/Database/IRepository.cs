using GraduationWorksOrganizer.Core.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Core.Database
{
    /// <summary>
    /// Интерфейс за репоситори
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Метод който връща обекта по ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById<TEntity>(int id) where TEntity : class, IDatabaseEntity;

        /// <summary>
        /// Метод който връща всички елементи от дадения тип
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class, IDatabaseEntity;

        /// <summary>
        /// Метод който връща всички елементи от дадения тип по експешън
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IDatabaseEntity;

        /// <summary>
        /// Метод за добавяне
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void Add<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity;

        /// <summary>
        /// Метод за изтриване
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void Delete<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity;

        /// <summary>
        /// Метод за промяна
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void Edit<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity;
    }

    /// <summary>
    /// Интерфейс за репоситори
    /// </summary>
    public interface IAsyncRepository
    {
        /// <summary>
        /// Метод който връща обекта по ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetById<TEntity>(int id) where TEntity : class, IDatabaseEntity;

        /// <summary>
        /// Метод който връща всички елементи от дадения тип
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class, IDatabaseEntity;

        /// <summary>
        /// Метод който връща всички елементи от дадения тип по експешън
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IDatabaseEntity;

        /// <summary>
        /// Метод за добавяне
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        Task Add<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity;

        /// <summary>
        /// Метод за изтриване
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        Task Delete<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity;

        /// <summary>
        /// Метод за промяна
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        Task Edit<TEntity>(TEntity entity) where TEntity : class, IDatabaseEntity;
    }
}
