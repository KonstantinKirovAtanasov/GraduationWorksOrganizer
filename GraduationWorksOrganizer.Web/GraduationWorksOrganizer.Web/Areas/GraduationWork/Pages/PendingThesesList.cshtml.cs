using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Core.Database.Models;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.Pages
{
    [Authorize(Policy = Constants.PolicyNames.ApproveTheses)]
    public class PendingThesesListModel : PageModel
    {
        #region Declarations

        /// <summary>
        /// сървис за работа с базата данни
        /// </summary>
        private readonly ThesisService<ThesesViewModel> _dbService;

        #endregion

        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        public PendingThesesListModel(ThesisService<ThesesViewModel> dbService)
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