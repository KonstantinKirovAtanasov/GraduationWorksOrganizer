using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Core.Database.Models
{
    /// <summary>
    /// Интерфейс за обект от базата данни
    /// </summary>
    public interface IDatabaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        int Id { get; set; }
    }
}
