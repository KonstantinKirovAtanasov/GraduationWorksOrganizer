using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Core.Database.Models;
using GraduationWorksOrganizer.Database.Models;
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
        private readonly IThesesDatabaseService _dbService;

        #endregion

        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        public PendingThesesListModel(IThesesDatabaseService dbService)
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

        public async Task OnGet()
        {
            await InitializeViewModelItems();
        }

        /// <summary>
        /// Метод който инициализира реквизити от VM
        /// </summary>
        /// <returns></returns>
        private async Task InitializeViewModelItems()
        {
            IEnumerable<Theses> theses = (await _dbService.GetAllPending()).Cast<Theses>();
            Theses = theses.Select(t => new ThesesViewModel()
            {
                ThesesId = t.Id,
                SpecialtyId = t.TargetSpecialtyId,
                Title = t.Title,
                Description = t.Description,
                Type = t.Type,
                Creator = t.Creator.Name,
                CreationDate = t.CreationDate,
            });
        }
    }
}