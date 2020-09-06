using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
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
        private readonly IAsyncRepository<Specialty> _specialtiesdbService;
        private readonly ThesisViewModelService<ThesesViewModel> _themesService;
        private readonly UserManager<ApplicationIdentityBase> _userManager;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbService"></param>
        /// <param name="themesService"></param>
        public AddThesesModel(IAsyncRepository<Specialty> specialtiesdbService,
                              ThesisViewModelService<ThesesViewModel> themesService,
                              UserManager<ApplicationIdentityBase> userManager)
        {
            _specialtiesdbService = specialtiesdbService;
            _themesService = themesService;
            _userManager = userManager;
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
        public IEnumerable<Specialty> Specialties { get; set; }

        /// <summary>
        /// Гет
        /// </summary>
        /// <returns></returns>
        public async Task OnGet()
        {
            Specialties = await _specialtiesdbService.GetAll();
        }

        /// <summary>
        /// Пост
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            Input.CreatorId = _userManager.GetUserId(User).ToString();
            Input.Status = User.IsInRole(Constants.RoleNames.StudentRole) ? Enums.ThesesStatusType.Pending : Enums.ThesesStatusType.Accept;

            if (ModelState.IsValid)//&& await _themesService.Add(Input))
                return Redirect("BachelorThesesList");

            Specialties = await _specialtiesdbService.GetAll();
            return Page();
        }

        #endregion
    }
}
