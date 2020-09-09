using GraduationWorksOrganizer.Core.Database.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace GraduationWorksOrganizer.Core.Database
{
    /// <summary>
    /// интерфейс за работа с базатаа данни
    /// </summary>
    /// <typeparam name="TDatanaseEntity"></typeparam>
    public interface IQueryProvider<TDatabaseEntity> where TDatabaseEntity : class, IDatabaseEntity
    {
        /// <summary>
        /// Метод който връща Query-то
        /// </summary>
        /// <returns></returns>
        IQueryable<TDatabaseEntity> GetQuery();

        /// <summary>
        /// Query което Include-ва няколко неща
        /// </summary>
        /// <param name="propertySelectors"></param>
        /// <returns></returns>
        IQueryable<TDatabaseEntity> GetAllIncluding(params Expression<Func<TDatabaseEntity, object>>[] propertySelectors);

        /// <summary>
        /// Query с Include на нещо неща
        /// </summary>
        /// <param name="propertySelectors"></param>
        /// <returns></returns>
        IQueryable<TDatabaseEntity> GetAllIncluding(Expression<Func<TDatabaseEntity, object>> propertySelector);
    }
}
