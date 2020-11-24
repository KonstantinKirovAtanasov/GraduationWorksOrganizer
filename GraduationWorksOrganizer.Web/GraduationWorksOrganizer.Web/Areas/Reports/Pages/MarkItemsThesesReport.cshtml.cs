using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Web.Areas.Reports.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GraduationWorksOrganizer.Web.Areas.Reports.Pages
{
    public class MarkItemsThesesReportModel : PageModel
    {

        private readonly CombinedQueryBaseService<ThesesUserEntry> _userEntryDbService;
        private readonly TeachersDatabaseService _teacherDbService;
        private readonly UserManager<ApplicationIdentityBase> _userManager;

        public MarkItemsThesesReportModel(CombinedQueryBaseService<ThesesUserEntry> userEntryDbService,
                                          TeachersDatabaseService teacherDbService,
                                          UserManager<ApplicationIdentityBase> userManager)
        {
            _userEntryDbService = userEntryDbService;
            _teacherDbService = teacherDbService;
            _userManager = userManager;
        }


        [BindProperty]
        public ReportFilterViewModel Filter { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }

        public IEnumerable<string> ThesesTypes { get; set; }

        public IEnumerable<ThesesCompleteWithMarkItemViewModel> ThesesMarks { get; set; }


        public async Task OnGetAsync()
        {
            await Init();
            DateTime currentDate = DateTime.Now.Date;
            Filter = new ReportFilterViewModel() { FromDate = new DateTime(currentDate.Year, currentDate.Month, 1), ToDate = new DateTime(currentDate.Year, currentDate.Month, 30), SubjectId = 0, ThesesType = "Всички" };
        }

        public async Task OnPostAsync()
        {
            await Init();
            string userId = _userManager.GetUserId(User);
            ThesesMarks = await _userEntryDbService.GetQuery()
                                                   .Where(p => (Filter.SubjectId == 0 || p.Theses.SubjectId == Filter.SubjectId)
                                                            && (Filter.ThesesType == "Всички" || Filter.ThesesType == p.Theses.Type)
                                                            && Filter.FromDate <= p.ThesisDefenceEvent.ThesisMark.CreationDate
                                                            && Filter.ToDate >= p.ThesisDefenceEvent.ThesisMark.CreationDate
                                                            && (p.Theses.CreatorId == userId || p.ThesisDefenceEvent.DefencesDate.TeacherId == userId)
                                                            && p.ThesisDefenceEvent != null && p.ThesisDefenceEvent.ThesisMark != null)
                                                   .Select(p => new ThesesCompleteWithMarkItemViewModel()
                                                   {
                                                       StudentFacultyNumber = p.Student.FacultyNumber,
                                                       StudentName = p.Student.Name,
                                                       SubjectName = p.Theses.Subject.Name,
                                                       ThesesTitle = p.Theses.Title,
                                                       ThesesType = p.Theses.Type,
                                                       ThesesUserEntryId = p.Id,
                                                       MarkResult = p.ThesisDefenceEvent.ThesisMark.Mark,
                                                   })
                                                   .ToListAsync();
        }

        private async Task Init()
        {
            Teacher teacher = await _teacherDbService.GetTeacher(_userManager.GetUserId(User));
            Subjects = await _teacherDbService.GetTeacherSubjects(teacher);
            Subjects = Subjects.Append(new Subject() { Id = 0, Name = "Всички" });
            ThesesTypes = _userEntryDbService.GetQuery().Where(t => t.Theses.Creator.Id == teacher.Id || t.ThesisDefenceEvent.DefencesDate.TeacherId == teacher.Id).Select(t => t.Theses.Type).Distinct();
            ThesesTypes = ThesesTypes.Append("Всички");
        }
    }
}
