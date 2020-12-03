using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Common
{
    /// <summary>
    /// Файл с изброени типове
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// Статус на тема
        /// </summary>
        public enum ThesesStatusType
        {
            Accept,
            Reject,
            Pending,
        }

        public enum ThesisUserEntryState
        {
            Initialized = 1,
            SendForApprovement = 2,
            Approve = 3,
            CompletedWithMarkItem = 5,
        }

        public enum ExportFileType
        {
            JSON,
            SVC,
        }
    }
}
