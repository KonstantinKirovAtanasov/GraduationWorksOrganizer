using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Web.Areas.Reports.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GraduationWorksOrganizer.Common.Enums;

namespace GraduationWorksOrganizer.Web.Areas.Reports.Pages
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Roles = Common.Constants.RoleNames.StudentRole)]
    public class EndedThesesArchiveModel : PageModel
    {

        #region Declarations
        private readonly CombinedQueryBaseService<ThesesUserEntry> _userEntryDbService;
        private readonly UserManager<ApplicationIdentityBase> _userService;

        #endregion

        #region Initialization

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="thesesVmService"></param>
        /// <param name=""></param>
        public EndedThesesArchiveModel(CombinedQueryBaseService<ThesesUserEntry> userEntryDbService,
                                       UserManager<ApplicationIdentityBase> userService)
        {
            _userService = userService;
            _userEntryDbService = userEntryDbService;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Теми
        /// </summary>
        public ICollection<PreviewArchiveTheses> Theseses { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task LoadPage()
        {
            string userId = _userService.GetUserId(User);
            Theseses = await _userEntryDbService.GetQuery()
                                                .Where(p => p.State == ThesisUserEntryState.CompletedWithMarkItem)
                                                .Select(p => new PreviewArchiveTheses()
                                                {
                                                    CreatorScienceDegree = p.Theses.Creator.ScienceDegree,
                                                    CreatorName = p.Theses.Creator.Name,
                                                    UserEntryId = p.Id,
                                                    ReviewerName = p.ThesisDefenceEvent.DefencesDate.Teacher.Name,
                                                    ReviewerScienceDegree = p.ThesisDefenceEvent.DefencesDate.Teacher.ScienceDegree,
                                                    MarkDate = p.ThesisDefenceEvent.ThesisMark.Date,
                                                    MarkResult = p.ThesisDefenceEvent.ThesisMark.Mark,
                                                    SubjectName = p.Theses.Subject.Name,
                                                    ThesesTitle = p.Theses.Title,
                                                    ThesesType = p.Theses.Type,
                                                })
                                                .OrderByDescending(p => p.MarkDate)
                                                .ToListAsync();

        }

        /// <summary>
        /// On Get
        /// </summary>
        public async Task OnGet()
        {
            await LoadPage();
        }

        #endregion
    }
}
