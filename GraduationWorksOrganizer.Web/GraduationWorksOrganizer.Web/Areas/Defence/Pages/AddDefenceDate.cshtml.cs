using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GraduationWorksOrganizer.Web.Areas.Defence.Pages
{
    public class AddDefenceDateModel : PageModel
    {
        private readonly CombinedQueryBaseService<TeacherDefencesDates> _defenceDatesDbService;
        private readonly UserManager<ApplicationIdentityBase> _userManager;

        public AddDefenceDateModel(CombinedQueryBaseService<TeacherDefencesDates> defenceDatesDbService,
                                   UserManager<ApplicationIdentityBase> userManager)
        {
            _defenceDatesDbService = defenceDatesDbService;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "������ �� ����� �� ���� � ������������")]
            public string HallNumber { get; set; }

            [Required(ErrorMessage = "������ �� ���� �� ���� � ������������")]
            public DateTime FromDate { get; set; }

            [Required(ErrorMessage = "������ �� ������ �� �������� �������� ������ � ������������")]
            public TimeSpan FromTime { get; set; }

            [Required(ErrorMessage = "������ �� ���� �� �������� � ������������")]
            public TimeSpan ToTime { get; set; }

            [Required(ErrorMessage = "������ �� ���������� ���� �������� ������ � ������������")]
            [Range(2, 10, ErrorMessage = "����� �������� ������ ������ �� � ����� 2 � 10")]
            public int MaxThesesCount { get; set; }
        }


        public void OnGet()
        {
            SetInputDefaultValues();
        }

        public async Task<IActionResult> OnPost()
        {
            if (Input.ToTime <= Input.FromTime)
                ModelState.AddModelError(string.Empty, "�������� ��� �� ���� �� ���� ���� �������");
            //return Page();
            DateTime fromDate = Input.FromDate.Date.Add(Input.FromTime);
            DateTime toDate = Input.FromDate.Date.Add(Input.ToTime);
            if (await _defenceDatesDbService.GetQuery().AnyAsync(d => d.HallNumber == Input.HallNumber && d.EndDate > fromDate && d.StartingDate < toDate))
                ModelState.AddModelError(string.Empty, "������ � ����� �� �������� ������ ��� ���� �� ����");

            if (ModelState.ErrorCount != 0)
                return Page();

            TeacherDefencesDates dd = new TeacherDefencesDates()
            {
                EndDate = toDate,
                StartingDate = fromDate,
                HallNumber = Input.HallNumber,
                MaxThesisCount = Input.MaxThesesCount,
                TeacherId = _userManager.GetUserId(User)
            };

            await _defenceDatesDbService.Add(dd);

            return new RedirectResult("DefenceDates");
        }

        private void SetInputDefaultValues()
        {
            Input = new InputModel();
            Input.FromDate = DateTime.Now.Date;
            Input.FromTime = new TimeSpan(10, 0, 0);
            Input.ToTime = new TimeSpan(15, 0, 0);
        }
    }
}
