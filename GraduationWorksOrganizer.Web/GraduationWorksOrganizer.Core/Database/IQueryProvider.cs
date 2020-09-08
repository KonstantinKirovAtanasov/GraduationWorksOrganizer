using System.Linq;

namespace GraduationWorksOrganizer.Core.Database.Models
{
    /// <summary>
    /// Сървис за работа с базата данни който връща Query
    /// </summary>
    /// <typeparam name="TDatanaseEntity"></typeparam>
    public interface IQueryProvider<TDatanaseEntity> where TDatanaseEntity : class, IDatabaseEntity
    {
        /// <summary>
        /// метод който връща Query 
        /// </summary>
        /// <returns></returns>
        IQueryable<TDatanaseEntity> GetQuery();
    }
}
