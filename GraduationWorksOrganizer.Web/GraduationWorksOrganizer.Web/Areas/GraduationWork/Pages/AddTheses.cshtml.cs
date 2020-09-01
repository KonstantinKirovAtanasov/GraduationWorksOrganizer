using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.Pages
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Policy = Constants.PolicyNames.AddTheses)]
    public class AddThesesModel : PageModel
    {
        private readonly IAsyncRepository _dbService;
        private readonly IThesesDatabaseService _themesService;
        private readonly UserManager<ApplicationIdentityBase> _userManager;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbService"></param>
        /// <param name="themesService"></param>
        public AddThesesModel(IAsyncRepository dbService,
                              IThesesDatabaseService themesService,
                              UserManager<ApplicationIdentityBase> userManager)
        {
            _dbService = dbService;
            _themesService = themesService;
            _userManager = userManager;
        }


        #region Properties

        [BindProperty]
        public AddThesesViewModel Input { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task OnGet()
        {
            Specialties = await _dbService.GetAll<Specialty>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Theses theses = await CreateTheses();
                SetThesesStatusByUser(theses);
                await _themesService.Add(theses);
                return Redirect("BachelorThesesList");
            }

            Specialties = await _dbService.GetAll<Specialty>();
            return Page();
        }

        /// <summary>
        /// Метод който сетва статус на модела тема
        /// </summary>
        /// <param name="theses"></param>
        private void SetThesesStatusByUser(Theses theses)
        {
            if (this.User.IsInRole(Constants.RoleNames.StudentRole))
                theses.Status = Enums.ThesesStatusType.Pending;

            if (this.User.IsInRole(Constants.RoleNames.TeacherRole)
                || this.User.IsInRole(Constants.RoleNames.PromotedTeacherRole))
                theses.Status = Enums.ThesesStatusType.Accept;

        }

        /// <summary>
        /// Метод който създава модел за теза
        /// </summary>
        /// <returns></returns>
        private async Task<Theses> CreateTheses()
        {
            return new Theses()
            {
                CreationDate = DateTime.Now,
                Creator = await _userManager.GetUserAsync(this.User),
                Type = Input.Type,
                Title = Input.Title,
                TargetSpecialtyId = Input.SpecialtyId,
                Description = Input.Description,
            };
        }

        #endregion
    }
}
