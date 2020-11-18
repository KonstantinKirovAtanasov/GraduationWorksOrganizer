using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Core.Database;
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
using static GraduationWorksOrganizer.Web.Areas.Marks.Pages.AddMarksModel.InputModel;

namespace GraduationWorksOrganizer.Web.Areas.Marks.Pages
{
    [Authorize(Roles = Constants.RoleNames.TeacherRole)]
    public class AddMarksModel : PageModel
    {
        private readonly CombinedQueryBaseService<TeacherDefencesDates> _defenceDatesService;
        private readonly CombinedQueryBaseService<ThesisDefenceEvent> _defenceEventsService;
        private readonly CombinedQueryBaseService<ThesesUserEntry> _userEntryDbService;
        private readonly CombinedQueryBaseService<ThesisMark> _marksService;
        private readonly UserManager<ApplicationIdentityBase> _userManager;

        public AddMarksModel(CombinedQueryBaseService<TeacherDefencesDates> defenceDatesService,
                             CombinedQueryBaseService<ThesisDefenceEvent> defenceEventsService,
                             CombinedQueryBaseService<ThesisMark> marksService,
                             UserManager<ApplicationIdentityBase> userManager,
                             CombinedQueryBaseService<ThesesUserEntry> userEntryDbService)
        {
            _defenceDatesService = defenceDatesService;
            _defenceEventsService = defenceEventsService;
            _userManager = userManager;
            _marksService = marksService;
            _userEntryDbService = userEntryDbService;
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

        public async Task OnGet()
        {
            string teacherId = _userManager.GetUserId(User);
            DateTime currentDate = DateTime.Now;
            DefenceDates = await _defenceDatesService.GetQuery().Where(dd => dd.TeacherId == teacherId && dd.EndDate <= currentDate)
                                                          .Select(dd => new DefenceDateViewModel() { Id = dd.Id, Description = dd.ShortDescription, FromDate = dd.StartingDate }).ToListAsync();
            foreach (DefenceDateViewModel ddvm in DefenceDates)
            {
                ddvm.DefenceEntries = await _defenceDatesService.GetQuery().Where(d => d.Id == ddvm.Id).SelectMany(d => d.Defences.Select(de => de.ThesesUserEntry)).Select(tue => new DefenceEventUserEntryViewModel()
                {
                    StudentName = tue.Student.Name,
                    FacultyNumber = tue.Student.FacultyNumber,
                    SpecialtyName = tue.Student.Specialty.Name,
                    UserEntryId = tue.Id,
                    DefenceEventId = tue.ThesisDefenceEventId,
                    ThesesName = tue.Theses.Title,
                    Type = tue.Theses.Type,
                    Requerments = tue.Theses.Requerments.Select(r => new InnerRequermentViewwModel() { Id = r.Id, Description = r.Description, MaxPoints = r.MaxPointsCount })
                }).ToListAsync();
            }

            foreach (DefenceEventUserEntryViewModel defenceEventUserEntry in DefenceDates.SelectMany(d => d.DefenceEntries))
            {
                ThesisDefenceEvent defenceEvent = await _defenceEventsService.GetAllIncluding(p => p.ThesisMark, p => p.ThesisMark.MarkResults).FirstOrDefaultAsync(p => p.Id == defenceEventUserEntry.DefenceEventId);
                if (defenceEvent != null && defenceEvent.ThesisMark != null)
                {
                    defenceEventUserEntry.Mark = defenceEvent.ThesisMark.Mark;
                    defenceEventUserEntry.Points = defenceEvent.ThesisMark.MarkResults.Sum(r => r.MarkPoints ?? 0);
                }
            }
        }

        public async Task<IActionResult> OnPost()
        {
            ThesisDefenceEvent thesesDE = _defenceEventsService.GetQuery().Include(p => p.ThesesUserEntry.Theses.Requerments).FirstOrDefault(p => p.ThesesUserEntryId == Input.UserEntryId);

            if (Input.ActualMark > 2.99M)
            {
                ThesesUserEntry thesesUserEntry = await _userEntryDbService.GetById(Input.UserEntryId);
                thesesUserEntry.State = Enums.ThesisUserEntryState.CompletedWithMarkItem;
                await _userEntryDbService.Update(thesesUserEntry);
            }

            ThesisMark thesesMark = new ThesisMark()
            {
                Date = DateTime.Now,
                Mark = Input.ActualMark,
                MarkResults = new List<ThesisRequerment>()
            };

            foreach (RequermentInputPointsModel requermentInput in Input.RequermentsPoints)
            {
                ThesisRequerment requerment = thesesDE.ThesesUserEntry.Theses.Requerments.FirstOrDefault(tr => tr.Id == requermentInput.RequermentId).Clone();
                requerment.MarkPoints = requermentInput.ActualPoints;
                thesesMark.MarkResults.Add(requerment);
            }


            thesesDE.ThesisMark = thesesMark;

            await _marksService.Add(thesesMark);

            return Redirect("AddMarks");
        }
    }
}
