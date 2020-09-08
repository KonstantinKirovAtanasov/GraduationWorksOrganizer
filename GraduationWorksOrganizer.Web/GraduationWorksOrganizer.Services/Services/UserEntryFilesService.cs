using GraduationWorksOrganizer.Database.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Services.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class UserEntryFilesService
    {
        /// <summary>
        /// Сървис за работа с базата
        /// </summary>
        private UserEntryFilesDatabaseService _databaseService;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserEntryFilesService(UserEntryFilesDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }


    }
}
