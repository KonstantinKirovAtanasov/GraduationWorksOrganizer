using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Services.MapEntitiesServices.ViewModels;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.Pages
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Policy = Constants.PolicyNames.AddTheses)]
    public class AddThesesModel : PageModel
    {
        private readonly IAsyncRepository<Subject> _subjectsdbService;
        private readonly ThesisViewModelService<ThesesViewModel> _themesService;
        private readonly UserManager<ApplicationIdentityBase> _userManager;
        private readonly TeachersDatabaseService _teachersDatabaseServce;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbService"></param>
        /// <param name="themesService"></param>
        public AddThesesModel(IAsyncRepository<Subject> subjectsdbService,
                              ThesisViewModelService<ThesesViewModel> themesService,
                              UserManager<ApplicationIdentityBase> userManager,
                              TeachersDatabaseService teachersDatabaseServce)
        {
            _subjectsdbService = subjectsdbService;
            _themesService = themesService;
            _userManager = userManager;
            _teachersDatabaseServce = teachersDatabaseServce;
        }


        #region Properties

        /// <summary>
        /// ВМ за създаване на теза
        /// </summary>
        [BindProperty]
        public AddThesisViewModel Input { get; set; }

        /// <summary>
        /// Специалностти
        /// </summary>
        public IEnumerable<Subject> Subjects { get; set; }

        /// <summary>
        /// Гет
        /// </summary>
        /// <returns></returns>
        public async Task OnGet()
        {
            string teacherid = _userManager.GetUserId(User);
            Teacher teacher = await _teachersDatabaseServce.GetTeacher(teacherid);
            if (teacher == null)
                return;
            Subjects = await _subjectsdbService.GetAll(s => s.Specialty.DepartmentId == teacher.DepartmentId);
        }

        /// <summary>
        /// Пост
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            Input.CreatorId = _userManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                await _themesService.AddAsync(Input);
                return Redirect("BachelorThesesList");
            }

            string teacherid = _userManager.GetUserId(User);
            Teacher teacher = await _teachersDatabaseServce.GetTeacher(teacherid);
            if (teacher == null)
                return NotFound();
            Subjects = await _subjectsdbService.GetAll(s => s.Specialty.DepartmentId == teacher.DepartmentId);

            return Page();
        }

        #endregion
    }
}
