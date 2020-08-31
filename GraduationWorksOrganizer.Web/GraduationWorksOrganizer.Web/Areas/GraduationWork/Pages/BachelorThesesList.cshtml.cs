using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Core.Database.Models;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.Pages
{
    [Authorize(Policy = Constants.PolicyNames.ViewTheses)]
    public class BachelorThesesListModel : PageModel
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
        public BachelorThesesListModel(IThesesDatabaseService dbService)
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

        private async Task InitializeViewModelItems()
        {
            IEnumerable<ITheses> theses = await _dbService.GetAllActive();
            Theses = theses.Select(t => new ThesesViewModel()
            {
                ThesesId = t.Id,
                SpecialtyId = t.TargetSpecialtyId,
                Title = t.Title,
                Description = t.Description,
                Type = t.Type,
                Creator = (t as Theses).Creator.UserName,
            });
        }
    }
}
