using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Services.Services;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.Pages
{
    /// <summary>
    /// Модел за преглед на тема
    /// </summary>
    [Authorize]
    public class PreviewConcreteThesesModel : PageModel
    {
        #region Declarations

        /// <summary>
        /// Сървиси
        /// </summary>
        private readonly ThesisViewModelService<PreviewThesisViewModel> _thesesVmService;
        private readonly ThesisService _thesisService;
        private readonly IAsyncRepository<Theses> _thesisDbService;
        private readonly UserManager<ApplicationIdentityBase> _userService;

        #endregion

        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="thesesService"></param>
        public PreviewConcreteThesesModel(ThesisViewModelService<PreviewThesisViewModel> thesesVmService,
                                          IAsyncRepository<Theses> thesisDbService,
                                          UserManager<ApplicationIdentityBase> userService,
                                          ThesisService thesisService)
        {
            _thesesVmService = thesesVmService;
            _thesisService = thesisService;
            _thesisDbService = thesisDbService;
            _userService = userService;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Теза
        /// </summary>
        public PreviewThesisViewModel Thesis { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// OnGet
        /// </summary>
        /// <param name="thesisId"></param>
        public async Task OnGet(int thesisId)
        {
            Thesis = await _thesesVmService.GetViewModel(thesisId);
        }

        /// <summary>
        /// Handler за записване на за тема
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostApplyForTheThesis(int thesisId)
        {
            string userId = _userService.GetUserId(User);
            await _thesisService.ApplyForTheThesis(userId, thesisId);
            return Redirect("MyTheses");
        }

        /// <summary>
        /// Handler за Одобрение на тема
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostApprove(int thesisId)
        {
            Theses thesis = await _thesisDbService.GetById(thesisId);
            thesis.Approval = await _userService.GetUserAsync(User);
            if (await _thesisService.ApproveThesis(thesis))
                return Redirect("BachelorThesesList");

            return Page();
        }

        /// <summary>
        /// Handler за отказване на тема
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostReject(int thesisId)
        {
            Theses thesis = await _thesisDbService.GetById(thesisId);
            thesis.Approval = await _userService.GetUserAsync(User);
            if (await _thesisService.RejectThesis(thesis))
                return Redirect("BachelorThesesList");

            return Page();
        }
        #endregion
    }
}
