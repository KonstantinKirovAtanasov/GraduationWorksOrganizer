using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.Pages
{
    /// <summary>
    /// M���� ����
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
        /// �����������
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
        /// ����� ����
        /// </summary>
        public IEnumerable<PreviewThesisExtendedViewModel> Theseses { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// O� get
        /// </summary>
        public void OnGet()
        {
            string userId = _userService.GetUserId(User);
            Theseses = _thesesVmService.GetViewModels(t => t.UserEntries.Any(e => e.StudentId == userId));
        }

        /// <summary>
        /// ����� ����� Handel-�� ��������� �� ����
        /// </summary>
        /// <param name="thesisId"></param>
        public void OnPostDeleteThesis(int thesisId)
        {

        }
        #endregion

    }
}
