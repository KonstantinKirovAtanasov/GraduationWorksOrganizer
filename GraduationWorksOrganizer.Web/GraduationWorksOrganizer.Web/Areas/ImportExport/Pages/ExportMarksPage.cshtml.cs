
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Web.Areas.ImportExport.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GraduationWorksOrganizer.Common.Enums;

namespace GraduationWorksOrganizer.Web.Areas.ImportExport
{
    public class ExportMarksPageModel : PageModel
    {
        private readonly CombinedQueryBaseService<ThesesUserEntry> _uenDbService;
        private readonly CombinedQueryBaseService<TeacherDefencesDates> _defenceDatesDbService;
        private readonly CombinedQueryBaseService<Specialty> _specialtiesDbService;
        private readonly StudentDatabaseService _studentsDbService;

        public ExportMarksPageModel(CombinedQueryBaseService<ThesesUserEntry> uenDbService,
                                    CombinedQueryBaseService<Specialty> specialtiesDbService,
                                    CombinedQueryBaseService<TeacherDefencesDates> defenceDatesDbService,
                                    StudentDatabaseService studentsDbService)
        {
            _uenDbService = uenDbService;
            _defenceDatesDbService = defenceDatesDbService;
            _specialtiesDbService = specialtiesDbService;
            _studentsDbService = studentsDbService;
        }

        [BindProperty]
        public ExportFilterViewModel Filter { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; }

        public IEnumerable<TeacherDefencesDates> DefenceDates { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public IEnumerable<ExportMarkViewModel> ExportResult { get; set; }

        public async Task OnGet()
        {
            await Initialize();
        }

        public async Task OnPost()
        {
            await Initialize();
            ExportResult = await GetExxportMarks();
        }

        //public async Task<IActionResult> OnPostGetFile([FromBody] ExportFileType exportFileType, ExportFilterViewModel filter)
        //{
        //    Filter = filter;
        //    ExportResult = await GetExxportMarks();

        //    switch (exportFileType)
        //    {
        //        case ExportFileType.JSON:
        //            return new JsonResult(ExportResult);
        //        case ExportFileType.SVC:
        //            return new JsonResult(GetSVCResultString());
        //        default:
        //            return new JsonResult(ExportResult);
        //    }
        //}

        public async Task Initialize()
        {
            Specialties = await _specialtiesDbService.GetAll();
            DefenceDates = await _defenceDatesDbService.GetAll();
            Students = await _studentsDbService.GetAll();
            if (Filter == null)
            {
                Filter = new ExportFilterViewModel();
                Filter.FromDate = DateTime.Now.AddMonths(-1);
                Filter.ToDate = DateTime.Now;
            }
        }

        private IQueryable<ThesesUserEntry> GetFiltratedQuery()
        {
            return _uenDbService.GetQuery().Where(p => p.State == Common.Enums.ThesisUserEntryState.CompletedWithMarkItem
                                                    && (string.IsNullOrEmpty(Filter.StudentId) || p.StudentId == Filter.StudentId)
                                                    && (Filter.SpecialtyId == 0 || p.Theses.Subject.SpecialtyId == Filter.SpecialtyId)
                                                    && (Filter.DefenceDateId == 0 || p.ThesisDefenceEvent.DefenceDateId == Filter.DefenceDateId)
                                                    && Filter.FromDate <= p.ThesisDefenceEvent.ThesisMark.CreationDate
                                                    && p.ThesisDefenceEvent.ThesisMark.CreationDate <= Filter.ToDate);
        }

        private async Task<IEnumerable<ExportMarkViewModel>> GetExxportMarks()
        {
            return await GetFiltratedQuery().Select(p => new ExportMarkViewModel()
            {
                MaxPoints = p.Theses.Requerments.Sum(r => r.MaxPointsCount),
                Points = p.ThesisDefenceEvent.ThesisMark.MarkResults.Sum(r => r.MarkPoints ?? 0),
                Mark = p.ThesisDefenceEvent.ThesisMark.Mark,
                StudentName = p.Student.Name,
                FacultyNumber = p.Student.FacultyNumber,
                Subject = p.Theses.Subject.Name,
                TeacherName = p.ThesisDefenceEvent.DefencesDate.Teacher.Name,
                ScienceDegree = p.ThesisDefenceEvent.DefencesDate.Teacher.ScienceDegree,
                Date = p.ThesisDefenceEvent.ThesisMark.CreationDate
            }).ToListAsync();
        }

        private string GetSVCResultString()
        {
            string svcFormat = "{0},{1},{2},{3},{4},{5},{6},{7}";
            StringBuilder svcBuilder = new StringBuilder();
            svcBuilder.AppendLine(string.Format(svcFormat,
                                                "Име на Студента",
                                                "Факултетен номер",
                                                "Предмет",
                                                "Преподавател",
                                                "Оценка",
                                                "Точки",
                                                "Дата"));
            foreach (ExportMarkViewModel mark in ExportResult)
            {
                svcBuilder.AppendLine(string.Format(svcFormat,
                                                    mark.StudentName,
                                                    mark.FacultyNumber,
                                                    mark.Subject,
                                                    mark.ScienceDegree + " " + mark.TeacherName,
                                                    mark.Mark,
                                                    mark.Points,
                                                    mark.Date.ToString()));
            }
            return svcBuilder.ToString();
        }

    }
}
