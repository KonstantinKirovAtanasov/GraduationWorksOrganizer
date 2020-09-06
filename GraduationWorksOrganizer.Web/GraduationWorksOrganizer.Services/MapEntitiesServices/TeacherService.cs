using AutoMapper;
using GraduationWorksOrganizer.Core.Services;
using GraduationWorksOrganizer.Core.ViewModels;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Services.MapEntitiesServices
{
    /// <summary>
    /// Сървис за работа с учители
    /// </summary>
    public class TeacherService<TViewModel> : IViewModelService<TViewModel, Teacher> where TViewModel : IAutoMapperViewModel, new()
    {
        #region Declarations

        /// <summary>
        /// ДБ сървис
        /// </summary>
        private readonly TeachersDatabaseService _databaseService;

        /// <summary>
        /// Аутомаппер
        /// </summary>
        private readonly Mapper _automapper;

        #endregion

        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        public TeacherService(TeachersDatabaseService databaseService)
        {
            _databaseService = databaseService;
            _automapper = new Mapper(new TViewModel().GetMapperConfiguration());
        }

        #endregion

        /// <summary>
        /// Метод който връща всички учителски ВМ
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TViewModel> GetViewModels()
        {
            IQueryable<Teacher> teachers = _databaseService.GetTeachers().Include(t => t.Department);
            foreach (Teacher teacher in teachers)
                yield return _automapper.Map<TViewModel>(teacher);
        }
    }
}
