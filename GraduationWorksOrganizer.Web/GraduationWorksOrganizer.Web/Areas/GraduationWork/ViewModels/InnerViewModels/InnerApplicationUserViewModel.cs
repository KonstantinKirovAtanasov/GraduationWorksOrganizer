using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels.InnerViewModels
{
    /// <summary>
    /// ВМ за Усер
    /// </summary>
    public class InnerApplicationUserViewModel
    {
        /// <summary>
        /// Ид
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
    }

    public class InnerStudentViewModel : InnerApplicationUserViewModel
    {
        /// <summary>
        /// Факултетен номер
        /// </summary>
        public string FacultyNumber { get; set; }
    }
}
