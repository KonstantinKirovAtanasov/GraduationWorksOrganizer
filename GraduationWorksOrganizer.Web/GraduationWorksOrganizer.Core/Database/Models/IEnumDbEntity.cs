using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Core.Database.Models
{
    /// <summary>
    /// Интерфейс за ентити което играе ролята на енумерация
    /// </summary>
    public interface IEnumDbEntity : IDatabaseEntity
    {
        /// <summary>
        /// Пропърти за име
        /// </summary>
        int Name { get; set; }
    }
}
