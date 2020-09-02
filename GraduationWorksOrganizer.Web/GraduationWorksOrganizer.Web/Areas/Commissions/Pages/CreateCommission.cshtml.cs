using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Core.Services;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Services.Commissions;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Web.Areas.Commissions.ViewModels;
using GraduationWorksOrganizer.Web.SharedViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace GraduationWorksOrganizer.Web.Areas.Commissions.Pages
{
    /// <summary>
    /// Page за създаване на комисия
    /// </summary>
    public class CreateCommissionModel : PageModel
    {
        #region Declarations

        /// <summary>
        /// Сървис за работа с комисии
        /// </summary>
        private readonly CommissionsService _commissionsService;

        /// <summary>
        /// Сървис за работа с базата данни
        /// </summary>
        private readonly IAsyncRepository _repository;

        /// <summary>
        /// Сървис за работа с учители
        /// </summary>
        private readonly TeacherService<TeacherViewModel> _teacherService;

        #endregion

        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        public CreateCommissionModel(IAsyncRepository asyncRepository,
                                     CommissionsService commissionsService,
                                     TeacherService<TeacherViewModel> teacherService)
        {
            _commissionsService = commissionsService;
            _repository = asyncRepository;
            _teacherService = teacherService;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Инпут
        /// </summary>
        [BindProperty]
        public CreateCommissionInputViewModel Input { get; set; }

        /// <summary>
        /// Учители
        /// </summary>
        public IEnumerable<TeacherViewModel> Тeachers { get; set; }

        #endregion

        public void OnGet()
        {
            Тeachers = _teacherService.GetViewModels().ToList();
        }

        public void OnPost()
        {

        }
    }
}
