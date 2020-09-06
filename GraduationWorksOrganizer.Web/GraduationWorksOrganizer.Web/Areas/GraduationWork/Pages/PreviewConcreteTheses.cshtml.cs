using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using static GraduationWorksOrganizer.Common.Enums;

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
        /// Сървис
        /// </summary>
        private readonly ThesisService<PreviewThesisViewModel> _thesisService;

        /// <summary>
        /// Дб сървис
        /// </summary>
        private readonly IAsyncRepository _dbService;

        #endregion

        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="thesesService"></param>
        public PreviewConcreteThesesModel(ThesisService<PreviewThesisViewModel> thesesService, IAsyncRepository dbService)
        {
            _thesisService = thesesService;
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
            Thesis = await _thesisService.GetViewModel(thesisId);
        }

        /// <summary>
        /// Пост
        /// </summary>
        /// <returns></returns>
        public async Task OnPost()
        {
            await Task.CompletedTask;
        }
        #endregion
    }
}
