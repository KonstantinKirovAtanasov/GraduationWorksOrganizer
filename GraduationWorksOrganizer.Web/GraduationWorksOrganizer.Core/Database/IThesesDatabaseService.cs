using GraduationWorksOrganizer.Core.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Core.Database
{
    /// <summary>
    /// Сървис за работа с базата данни (Тези)
    /// </summary>
    public interface IThesesDatabaseService : IAsyncRepository
    {
        /// <summary>
        /// Метод който връща всички активни теми
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ITheses>> GetAllActive();

        /// <summary>
        /// Метод който връща всички теми които чакат одобрение
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ITheses>> GetAllPending();
    }
}
