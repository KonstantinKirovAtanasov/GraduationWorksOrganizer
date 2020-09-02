using GraduationWorksOrganizer.Core.Database.Models;
using GraduationWorksOrganizer.Web.SharedViewModels;
using System.Collections.Generic;

namespace GraduationWorksOrganizer.Web.Areas.Commissions.ViewModels
{
    /// <summary>
    /// ВМ за създаване на комисия
    /// </summary>
    public class CreateCommissionInputViewModel
    {
        /// <summary>
        /// Ид на главен преподавател
        /// </summary>
        public TeacherViewModel MainTeacher { get; set; }

        /// <summary>
        /// Учители
        /// </summary>
        public IEnumerable<TeacherViewModel> Teachers { get; set; }
    }
}
