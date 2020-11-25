using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Web.Areas.Reports.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GraduationWorksOrganizer.Web.Areas.Reports.Pages
{
    public class MarksStatisticsModel : PageModel
    {
        private readonly CombinedQueryBaseService<Specialty> _specialtiesDbService;
        private readonly CombinedQueryBaseService<ThesisDefenceEvent> _thdDbService;
        private readonly CombinedQueryBaseService<Subject> _subjectsDbService;

        public MarksStatisticsModel(CombinedQueryBaseService<Specialty> specialtiesDbService,
                                    CombinedQueryBaseService<Subject> subjectsDbService,
                                    CombinedQueryBaseService<ThesisDefenceEvent> thdDbService)
        {
            _specialtiesDbService = specialtiesDbService;
            _subjectsDbService = subjectsDbService;
            _thdDbService = thdDbService;
        }

        public IEnumerable<Specialty> Specialties { get; set; }

        public async Task OnGet()
        {
            Specialties = await _specialtiesDbService.GetAll();
        }

        private async Task<ChartMarksDataViewModel> InitializeChartData(int specialtyId)
        {
            ChartMarksDataViewModel chartData = null;
            Specialty specialty = await _specialtiesDbService.GetById(specialtyId);
            chartData = new ChartMarksDataViewModel() { ChartId = specialty.Id, SubTitle = specialty.Name };
            chartData.Categories = await _subjectsDbService.GetQuery().Where(p => p.SpecialtyId == specialtyId).Select(p => new CategoryViewModel() { CategoryName = p.Name, CategoryId = p.Id, }).ToListAsync();
            chartData.Series = InitializeSeries();
            await FillSeriesData(chartData);
            return chartData;
        }

        public IEnumerable<Series> InitializeSeries()
        {
            return new List<Series>()
            {
                new Series() { SeriesName = "Отличен (6)", DownBorder = 5.50M, UpBorder = 6.00M, SeriesValues = new List<int>()},
                new Series() { SeriesName = "Мн. Добър (5)", DownBorder = 4.50M, UpBorder = 5.49M, SeriesValues = new List<int>()},
                new Series() { SeriesName = "Добър (4)", DownBorder = 3.50M, UpBorder = 4.49M , SeriesValues = new List<int>()},
                new Series() { SeriesName = "Среден (3)" , DownBorder = 3.00M, UpBorder = 3.49M , SeriesValues = new List<int>()}
            };
        }

        public async Task FillSeriesData(ChartMarksDataViewModel chartItem)
        {
            foreach (Series series in chartItem.Series)
            {
                foreach (CategoryViewModel category in chartItem.Categories)
                {
                    int count = await _thdDbService.GetQuery().Where(p => p.ThesesUserEntry.Theses.SubjectId == category.CategoryId
                                                                       && p.ThesisMark.Mark >= series.DownBorder
                                                                       && p.ThesisMark.Mark <= series.UpBorder)
                                                              .CountAsync();
                    series.SeriesValues.Add(count);
                }
            }
        }

        public async Task<IActionResult> OnGetConcreteAsync(int chartId)
        {
            ChartMarksDataViewModel chartData = await InitializeChartData(chartId);
            return new JsonResult(new { id = chartData.ChartId, chartData });
        }
    }
}
