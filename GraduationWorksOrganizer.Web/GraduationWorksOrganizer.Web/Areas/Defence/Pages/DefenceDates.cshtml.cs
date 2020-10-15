using AutoMapper;
using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Web.Areas.Defence.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GraduationWorksOrganizer.Web.Areas.Defence.Pages
{
    public class DefenceDatesModel : PageModel
    {
        private readonly CombinedQueryBaseService<TeacherDefencesDates> _defenceDatesService;
        private readonly UserManager<ApplicationIdentityBase> _userManager;
        private readonly CombinedQueryBaseService<Theses> _thesesDatesService;
        private readonly CombinedQueryBaseService<ThesesUserEntry> _userEntriesDbService;
        private readonly IMapper _mapper;

        public DefenceDatesModel(CombinedQueryBaseService<TeacherDefencesDates> defenceDatesService,
                                 CombinedQueryBaseService<Theses> thesesDatesService,
                                 CombinedQueryBaseService<ThesesUserEntry> userEntriesDbService,
                                 UserManager<ApplicationIdentityBase> userManager)
        {
            _defenceDatesService = defenceDatesService;
            _userManager = userManager;
            _thesesDatesService = thesesDatesService;
            _userEntriesDbService = userEntriesDbService;
            _mapper = new Mapper(new DefenceDatesViewModel().GetMapperConfiguration());
        }

        public IEnumerable<DefenceDatesViewModel> DefenceDates { get; set; }

        public IEnumerable<TeacherClosestDefenceDatesViewModel> TeachersDefenceDates { get; set; }

        public void OnGet()
        {
            Expression<Func<TeacherDefencesDates, bool>> wherePredicate = null;
            if (User.IsInRole(Constants.RoleNames.StudentRole))
            {
                DateTime currentDateTime = DateTime.Now;
                wherePredicate = (t) => t.EndDate >= currentDateTime;
                InitializeTeacherDefenceDates();
            }
            else
            {
                string teacherId = _userManager.GetUserId(User);
                wherePredicate = (t) => t.TeacherId == teacherId;
            }

            DefenceDates = _defenceDatesService.GetQuery().Where(wherePredicate).Select(dd =>
            new DefenceDatesViewModel
            {
                EndDate = dd.EndDate,
                StartingDate = dd.StartingDate,
                HallNumber = dd.HallNumber,
                Id = dd.Id,
                MaxThesisCount = dd.MaxThesisCount,
                TeacherScienceDegree = dd.Teacher.ScienceDegree,
                TeacherName = dd.Teacher.Name,
                ThesesCount = dd.Defences.Count,
                ShortDescription = dd.ShortDescription
            });

        }

        public JsonResult OnGetDateInfo(int defenceDateId)
        {
            IQueryable<Theses> theses = _defenceDatesService.GetQuery().Where(dd => dd.Id == defenceDateId).SelectMany(dd => dd.Defences).Select(de => de.ThesesUserEntry.Theses);
            IEnumerable<InnerThesesViewModel> thesesVms = theses.Select(t => new InnerThesesViewModel() { ThesesTitle = t.Title, ThesesType = t.Type, SubjectName = t.Subject.Name });
            return new JsonResult(thesesVms);
        }

        private void InitializeTeacherDefenceDates()
        {
            string studentId = _userManager.GetUserId(User);
            IQueryable<ThesisApprovementRequest> apprRequests = _userEntriesDbService.GetQuery().Where(ue => ue.StudentId == studentId
                                                                                                          && ue.State != Enums.ThesisUserEntryState.CompletedWithMarkItem
                                                                                                          && ue.State != Enums.ThesisUserEntryState.Initialized)
                                                                                                .SelectMany(p => p.ThesesRequests);
            IQueryable<ThesesUserEntry> usrInitializedEntries = _userEntriesDbService.GetQuery().Where(ue => ue.StudentId == studentId && ue.State == Enums.ThesisUserEntryState.Initialized);
            TeachersDefenceDates = apprRequests.Select(ur => new TeacherClosestDefenceDatesViewModel()
            {
                TeacherId = ur.ThemeObserverId,
                TeacherName = ur.ThemeObserver.Name
            }).Union(usrInitializedEntries.Select(ue => new TeacherClosestDefenceDatesViewModel()
            {
                TeacherId = ue.Theses.CreatorId,
                TeacherName = ue.Theses.Creator.Name
            }));

            TeachersDefenceDates = TeachersDefenceDates.ToList();
            DateTime currentDate = DateTime.Now.Date;
            foreach (TeacherClosestDefenceDatesViewModel tdd in TeachersDefenceDates)
            {
                tdd.DefenceDates = _defenceDatesService.GetQuery().Where(dd => dd.TeacherId == tdd.TeacherId && dd.StartingDate >= currentDate)
                                                                  .Take(3)
                                                                  .Select(dd => new InnerDefenceDate() { Description = dd.ShortDescription, Date = dd.StartingDate })
                                                                  .ToList();
            }
        }
    }
}
