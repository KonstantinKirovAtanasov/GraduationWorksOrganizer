using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Services.Commissions
{
    /// <summary>
    /// Сървис за работа с комисии
    /// </summary>
    public class CommissionsService
    {

        #region Declarations

        /// <summary>
        /// Сървис за работа с базата данни
        /// </summary>
        private readonly TeachersDatabaseService _teachersDbService;

        #endregion

        #region Initialization

        public CommissionsService(TeachersDatabaseService teachersDbService)
        {
            _teachersDbService = teachersDbService;
        }

        #endregion

        #region ICommisssionService

        /// <summary>
        /// Метод за създаване на комисия
        /// </summary>
        /// <param name="mainTeacher"></param>
        /// <param name="teachers"></param>
        /// <returns></returns>
        public async Task CreateCommission(Teacher mainTeacher, ICollection<Teacher> teachers)
        {
            Teacher mainContextTeacher = await _teachersDbService.GetTeacher(mainTeacher);
            IEnumerable<Teacher> contextTeachers = await _teachersDbService.GetManyTeachers(teachers);
            Commission commission = new Commission();
            commission.MainCommissionTeacher = mainContextTeacher;
            commission.DepartmentId = mainContextTeacher.DepartmentId;
            commission.CommissionTeachers = new List<Teacher>(contextTeachers);
        }

        #endregion
    }
}
