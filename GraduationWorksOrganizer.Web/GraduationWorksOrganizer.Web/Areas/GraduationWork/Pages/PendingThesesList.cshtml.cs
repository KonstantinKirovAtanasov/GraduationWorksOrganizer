using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.Pages
{
    [Authorize(Policy = Constants.PolicyNames.ApproveTheses)]
    public class PendingThesesListModel : PageModel
    {
        #region Declarations

        /// <summary>
        /// сървис за работа с базата данни
        /// </summary>
        private readonly ThesisViewModelService<ThesesViewModel> _dbService;

        #endregion

        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        public PendingThesesListModel(ThesisViewModelService<ThesesViewModel> dbService)
        {
            _dbService = dbService;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Тези
        /// </summary>
        public IEnumerable<ThesesViewModel> Theses { get; set; }

        #endregion

        public void OnGet()
        {
            InitializeViewModelItems();
        }

        /// <summary>
        /// Метод който инициализира ВМ
        /// </summary>
        private void InitializeViewModelItems()
        {
            Theses = _dbService.GetViewModels().Where(vm => vm.Status == Enums.ThesesStatusType.Pending);
        }
    }
}