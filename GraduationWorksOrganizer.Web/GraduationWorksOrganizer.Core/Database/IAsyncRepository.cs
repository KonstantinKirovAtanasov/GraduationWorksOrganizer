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
    public interface IAsyncRepository<TEntity> where TEntity : class, IDatabaseEntity
    {
        /// <summary>
        /// Метод който връща обекта по ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetById(int id);

        /// <summary>
        /// Метод който връща всички елементи от дадения тип
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Метод който връща всички елементи от дадения тип по експешън
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Метод за добавяне
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        Task Add(TEntity entity);

        /// <summary>
        /// Метод за изтриване
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        Task Delete(TEntity entity);
    }
}
