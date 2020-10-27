using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Web.Areas.Marks.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GraduationWorksOrganizer.Web.Areas.Marks.Pages
{
    public class MyMarkItemsStudentModel : PageModel
    {
        private readonly CombinedQueryBaseService<ThesisMark> _marksService;
        private readonly UserManager<ApplicationIdentityBase> _userManager;
        private readonly CombinedQueryBaseService<ThesesUserEntry> _userEntryDbService;
        private readonly CombinedQueryBaseService<ThesisDefenceEvent> _defenceEventsDbService;

        public MyMarkItemsStudentModel(CombinedQueryBaseService<ThesisMark> marksService,
                                       UserManager<ApplicationIdentityBase> userManager,
                                       CombinedQueryBaseService<ThesesUserEntry> userEntryDbService,
                                       CombinedQueryBaseService<ThesisDefenceEvent> defenceEventsDbService)
        {
            _marksService = marksService;
            _userManager = userManager;
            _userEntryDbService = userEntryDbService;
            _defenceEventsDbService = defenceEventsDbService;
        }

        public IEnumerable<MarkItemViewModel> MarkItems { get; set; }

        public decimal OverAllResult { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync()
        {
            string userId = _userManager.GetUserId(User);
            MarkItems = await _userEntryDbService.GetQuery().Where(ue => ue.StudentId == userId).Select(ue => new MarkItemViewModel()
            {
                SubjectName = ue.Theses.Subject.Name,
                Date = ue.ThesisDefenceEvent.ThesisMark.CreationDate,
                ThesesTitle = ue.Theses.Title,
                ThesesType = ue.Theses.Type,
                ThesesPoints = ue.Theses.Requerments.Sum(p => p.MaxPointsCount),
                DefenceEventId = ue.ThesisDefenceEventId
            }).ToListAsync();

            foreach (MarkItemViewModel markItem in MarkItems)
            {
                if (markItem.DefenceEventId != null)
                {
                    ThesisDefenceEvent de = await _defenceEventsDbService.GetById(markItem.DefenceEventId.Value, p => p.ThesisMark, p => p.DefencesDate.Teacher, p => p.ThesisMark.MarkResults);
                    markItem.MarkPoints = de.ThesisMark?.MarkResults?.Sum(m => m.MarkPoints ?? 0);
                    markItem.TeacherName = de.DefencesDate.Teacher.Name;
                    markItem.TeacherScienceDegree = de.DefencesDate.Teacher.ScienceDegree;
                    markItem.MarkValue = de.ThesisMark?.Mark;
                }

            }

            OverAllResult = MarkItems.Where(p => p.MarkValue.HasValue).Average(p => p.MarkValue.Value);
        }
    }
}
