using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class MyThesesModel : PageModel
    {
        #region Declarations

        private readonly ThesisViewModelService<PreviewThesisExtendedViewModel> _thesesVmService;
        private readonly UserManager<ApplicationIdentityBase> _userService;

        #endregion

        #region Initialization

        /// <summary>
        /// Êîíñòðóêòîð
        /// </summary>
        /// <param name="thesesVmService"></param>
        /// <param name=""></param>
        public MyThesesModel(ThesisViewModelService<PreviewThesisExtendedViewModel> thesesVmService,
                             UserManager<ApplicationIdentityBase> userService)
        {
            _thesesVmService = thesesVmService;
            _userService = userService;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Теми
        /// </summary>
        public ICollection<CompositePreviewThesisViewModel> Theseses { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// On Get
        /// </summary>
        public async Task OnGet()
        {
            string userId = _userService.GetUserId(User);
            IEnumerable<PreviewThesisViewModel> viewModels = _thesesVmService.GetViewModels(t => t.UserEntries.Any(e => e.StudentId == userId));
            Theseses = new Collection<CompositePreviewThesisViewModel>();
            foreach (PreviewThesisViewModel prvm in viewModels)
            {
                ThesesUserEntry thesesUserEntry = await _thesesVmService.GetUserEntry(userId, prvm.Id);
                UserEntryViewModel userEntry = new UserEntryViewModel() { Id = thesesUserEntry.Id };
                Theseses.Add(new CompositePreviewThesisViewModel() { ThesisViewModel = prvm, UserEntry = userEntry });
            }
        }

        /// <summary>
        /// ìåòîä êîéòî Handel-âà èçòðèâàíå íà òåìà
        /// </summary>
        /// <param name="thesisId"></param>
        public void OnPostDeleteThesis(int thesisId)
        {


        }
        #endregion

    }
}
