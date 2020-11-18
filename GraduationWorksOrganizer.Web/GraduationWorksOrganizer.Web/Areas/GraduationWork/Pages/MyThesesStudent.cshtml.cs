using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Services.Services;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Constants = GraduationWorksOrganizer.Common.Constants;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.Pages
{
    /// <summary>
    /// Mîèòå òåìè
    /// </summary>
    [Authorize(Roles = Constants.RoleNames.StudentRole)]
    public class MyThesesStudentModel : PageModel
    {
        #region Declarations

        private readonly ThesisViewModelService<PreviewThesisExtendedViewModel> _thesesVmService;
        private readonly UserManager<ApplicationIdentityBase> _userService;
        private readonly ThesisService _thesisService;

        #endregion

        #region Initialization

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="thesesVmService"></param>
        /// <param name=""></param>
        public MyThesesStudentModel(ThesisViewModelService<PreviewThesisExtendedViewModel> thesesVmService,
                                    UserManager<ApplicationIdentityBase> userService,
                                    ThesisService thesisService)
        {
            _thesesVmService = thesesVmService;
            _userService = userService;
            _thesisService = thesisService;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Теми
        /// </summary>
        public ICollection<CompositePreviewThesisViewModel> CurrentTheseses { get; set; }

        /// <summary>
        /// Пропърти за изпращане на заявка за одобрение
        /// </summary>
        [BindProperty]
        public AddThesisApprovementRequestViewModel Input { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task LoadPage()
        {
            string userId = _userService.GetUserId(User);
            IEnumerable<PreviewThesisViewModel> viewModels = _thesesVmService.GetViewModels(t => t.UserEntries.Any(e => e.StudentId == userId));
            CurrentTheseses = new Collection<CompositePreviewThesisViewModel>();
            foreach (PreviewThesisViewModel prvm in viewModels.OrderByDescending(p => p.CreationDate))
            {
                ThesesUserEntry thesesUserEntry = await _thesisService.GetUserEntry(userId, prvm.Id);
                if (thesesUserEntry.State != Common.Enums.ThesisUserEntryState.CompletedWithMarkItem)
                {
                    UserEntryBaseViewModel userEntry = new UserEntryBaseViewModel() { Id = thesesUserEntry.Id, State = thesesUserEntry.State };
                    CurrentTheseses.Add(new CompositePreviewThesisViewModel() { ThesisViewModel = prvm, UserEntry = userEntry });
                }
            }
        }

        /// <summary>
        /// On Get
        /// </summary>
        public async Task OnGet()
        {
            await LoadPage();
        }

        /// <summary>
        /// On Post
        /// </summary>
        /// <param name="thesisId"></param>
        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
                await _thesesVmService.SendForApprovement(Input);
            }

            await LoadPage();
        }

        #endregion

    }
}
