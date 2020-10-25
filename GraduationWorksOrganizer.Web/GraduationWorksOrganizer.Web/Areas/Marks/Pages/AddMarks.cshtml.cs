using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Web.Areas.Marks.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.Marks.Pages
{
    [Authorize(Roles = Constants.RoleNames.TeacherRole)]
    public class AddMarksModel : PageModel
    {
        private readonly CombinedQueryBaseService<TeacherDefencesDates> _defenceDatesService;
        private readonly CombinedQueryBaseService<ThesisDefenceEvent> _defenceEventsService;
        private readonly CombinedQueryBaseService<ThesisMark> _marksService;
        private readonly UserManager<ApplicationIdentityBase> _userManager;

        public AddMarksModel(CombinedQueryBaseService<TeacherDefencesDates> defenceDatesService,
                             CombinedQueryBaseService<ThesisDefenceEvent> defenceEventsService,
                             CombinedQueryBaseService<ThesisMark> marksService,
                             UserManager<ApplicationIdentityBase> userManager)
        {
            _defenceDatesService = defenceDatesService;
            _defenceEventsService = defenceEventsService;
            _userManager = userManager;
            _marksService = marksService;
        }

        public IEnumerable<DefenceDateViewModel> DefenceDates { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public int UserEntryId { get; set; }

            [Required]
            public decimal ActualMark { get; set; }

            public List<RequermentInputPointsModel> RequermentsPoints { get; set; }

            public class RequermentInputPointsModel
            {
                public int RequermentId { get; set; }

                [Required]
                public decimal ActualPoints { get; set; }
            }
        }

        public void OnGet()
        {
            string teacherId = _userManager.GetUserId(User);
            DateTime currentDate = DateTime.Now;
            DefenceDates = _defenceDatesService.GetQuery().Where(dd => dd.TeacherId == teacherId && dd.EndDate <= currentDate)
                                                          .Select(dd => new DefenceDateViewModel() { Id = dd.Id, Description = dd.ShortDescription, FromDate = dd.StartingDate }).ToList();
            foreach (DefenceDateViewModel ddvm in DefenceDates)
            {
                ddvm.DefenceEntries = _defenceDatesService.GetQuery().Where(d => d.Id == d.Id).SelectMany(d => d.Defences.Select(de => de.ThesesUserEntry)).Select(tue => new DefenceEventUserEntryViewModel()
                {
                    StudentName = tue.Student.Name,
                    FacultyNumber = tue.Student.FacultyNumber,
                    SpecialtyName = tue.Student.Specialty.Name,
                    UserEntryId = tue.Id,
                    ThesesName = tue.Theses.Title,
                    Type = tue.Theses.Type,
                    Mark = tue.ThesisDefenceEvent != null && tue.ThesisDefenceEvent.ThesisMark != null ? tue.ThesisDefenceEvent.ThesisMark.Mark : 0,
                    Points = tue.ThesisDefenceEvent != null && tue.ThesisDefenceEvent.ThesisMark != null ? tue.ThesisDefenceEvent.ThesisMark.MarkResults.Sum(m => m.MarkPoints ?? 0) : 0,
                    Requerments = tue.Theses.Requerments.Select(r => new InnerRequermentViewwModel() { Id = r.Id, Description = r.Description, MaxPoints = r.MaxPointsCount })
                }).ToList();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            ThesisDefenceEvent thesesDE = _defenceEventsService.GetQuery().Include(p => p.ThesesUserEntry.Theses.Requerments)
                                                                          .FirstOrDefault(p => p.ThesesUserEntryId == Input.UserEntryId);
            ThesisMark thesesMark = new ThesisMark()
            {
                Date = DateTime.Now,
                Mark = Input.ActualMark,
            };
            thesesDE.ThesisMark = thesesMark;

            await _marksService.Add(thesesMark);

            OnGet();
            return Page();
        }
    }
}
