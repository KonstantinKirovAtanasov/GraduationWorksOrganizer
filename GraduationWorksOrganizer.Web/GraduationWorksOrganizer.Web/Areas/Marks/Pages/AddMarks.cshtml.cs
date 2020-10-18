using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Web.Areas.Marks.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationWorksOrganizer.Web.Areas.Marks.Pages
{
    [Authorize(Roles = Constants.RoleNames.TeacherRole)]
    public class AddMarksModel : PageModel
    {
        private readonly CombinedQueryBaseService<TeacherDefencesDates> _defenceDatesService;
        private readonly UserManager<ApplicationIdentityBase> _userManager;

        public AddMarksModel(CombinedQueryBaseService<TeacherDefencesDates> defenceDatesService,
                             UserManager<ApplicationIdentityBase> userManager)
        {
            _defenceDatesService = defenceDatesService;
            _userManager = userManager;
        }

        public IEnumerable<DefenceDateViewModel> DefenceDates { get; set; }

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
                    Requerments = tue.Theses.Requerments.Select(r => new InnerRequermentViewwModel() { Id = r.Id, Description = r.Description, MaxPoints = r.MaxPointsCount })
                }).ToList();
            }
        }
    }
}
