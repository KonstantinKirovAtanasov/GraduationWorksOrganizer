using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Web.Areas.Reports.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.Reports.Pages
{
    public class ThesesInProcessReportModel : PageModel
    {

        private readonly CombinedQueryBaseService<ThesesUserEntry> _userEntryDbService;
        private readonly TeachersDatabaseService _teacherDbService;
        private readonly UserManager<ApplicationIdentityBase> _userManager;

        public ThesesInProcessReportModel(CombinedQueryBaseService<ThesesUserEntry> userEntryDbService,
                                          TeachersDatabaseService teacherDbService,
                                          UserManager<ApplicationIdentityBase> userManager)
        {
            _userEntryDbService = userEntryDbService;
            _teacherDbService = teacherDbService;
            _userManager = userManager;
        }

        public IEnumerable<ThesesInProgresViewModel> ThesesInProgress { get; private set; }

        public async Task OnGetAsync()
        {

            ThesesInProgress = await GetQuery().Select(p => new ThesesInProgresViewModel()
            {
                StudentFacultyNumber = p.Student.FacultyNumber,
                StudentName = p.Student.Name,
                SubjectName = p.Theses.Subject.Name,
                MaxPoints = p.Theses.Requerments.Sum(r => r.MaxPointsCount),
                ThesesTitle = p.Theses.Title,
                ThesesType = p.Theses.Type,
                ThesesUserEntryId = p.Id,
                State = p.State,
                ThesesCreationDate = p.Theses.CreationDate,
                LastUpdate = p.LastModified,
                ProgressStart = p.CreationDate
            }).ToListAsync();
        }

        public IQueryable<ThesesUserEntry> GetQuery()
        {
            string userId = _userManager.GetUserId(User);
            bool admin = User.IsInRole(Common.Constants.RoleNames.AdminRole);
            return _userEntryDbService.GetQuery().Where(p => (admin || p.Theses.CreatorId == userId || p.ThesisDefenceEvent.DefencesDate.TeacherId == userId)
                                                          && p.State != Common.Enums.ThesisUserEntryState.CompletedWithMarkItem);
        }
    }
}
