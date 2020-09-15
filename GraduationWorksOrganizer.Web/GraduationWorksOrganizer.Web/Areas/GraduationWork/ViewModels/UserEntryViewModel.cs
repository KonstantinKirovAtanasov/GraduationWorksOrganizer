using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GraduationWorksOrganizer.Common.Enums;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels
{
    /// <summary>
    /// ВМ за UserEntry
    /// </summary>
    public class UserEntryViewModel
    {
        /// <summary>
        /// Ид на UserEntry
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public ThesisUserEntryState State { get; set; }
    }
}
