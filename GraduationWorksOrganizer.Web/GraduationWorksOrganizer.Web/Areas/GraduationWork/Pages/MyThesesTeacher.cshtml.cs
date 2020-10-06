using AutoMapper;
using GraduationWorksOrganizer.Additional.Services;
using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Services.Services;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.Pages
{
    [Authorize(Roles = Constants.RoleNames.TeacherRole)]
    public class MyThesesTeacherModel : PageModel
    {

        #region Declarations
        private readonly ThesisApprovementService _thesesApprovementService;
        private readonly UserManager<ApplicationIdentityBase> _userManager;
        private readonly MapperService _mapper;

        #endregion

        #region Constructor     

        public MyThesesTeacherModel(ThesisApprovementService thesesApprovementService,
                                    UserManager<ApplicationIdentityBase> userManager,
                                    MapperService mapper)
        {
            _thesesApprovementService = thesesApprovementService;
            _userManager = userManager;
            _mapper = mapper;
        }

        #endregion

        #region Properties

        public IEnumerable<MyThesesTeacherViewModel> Theseses { get; set; }

        #endregion

        #region Methods

        public async Task OnGet()
        {
            string userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
                return;

            IEnumerable<ThesesUserEntry> theses = await _thesesApprovementService.GetTeacherTheses(userId);
            IEnumerable<PreviewThesisViewModel> thesesViewModels = _mapper.GetViewModels<PreviewThesisViewModel>(theses.Select(ue => ue.Theses));
            IEnumerable<UserEntryViewModel> userEntryViewModels = _mapper.GetViewModels<UserEntryViewModel>(theses);

            Theseses = CreateMyThesesTeacherViewModels(thesesViewModels, userEntryViewModels);
        }

        private IEnumerable<MyThesesTeacherViewModel> CreateMyThesesTeacherViewModels(IEnumerable<PreviewThesisViewModel> thesesViewModels, IEnumerable<UserEntryViewModel> userEntryViewModels)
        {
            for (int i = 0; i < thesesViewModels.Count(); i++)
            {
                if (userEntryViewModels.ElementAt(i).State != Enums.ThesisUserEntryState.Initialized && userEntryViewModels.ElementAt(i).State != Enums.ThesisUserEntryState.CompletedWithMarkItem)
                    yield return new MyThesesTeacherViewModel()
                    {
                        ThesesViewModel = thesesViewModels.ElementAt(i),
                        UserEntry = userEntryViewModels.ElementAt(i),
                    };
            }
        }

        #endregion

    }
}
