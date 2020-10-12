using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Web.Areas.Commissions.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace GraduationWorksOrganizer.Web.Areas.Commissions.Pages
{
    public class CommissionsListModel : PageModel
    {
        private readonly TeacherViewModelService<PreviewTeacherViewModel> _teacherVmService;

        public CommissionsListModel(TeacherViewModelService<PreviewTeacherViewModel> teacherVmService)
        {
            _teacherVmService = teacherVmService;
        }

        public IEnumerable<PreviewTeacherViewModel> Teachers { get; set; }
        public IEnumerable<string> DepartmentNames { get; set; }

        public void OnGet()
        {
            Teachers = _teacherVmService.GetViewModels();
            List<string> departmentNames = new List<string>();
            departmentNames.Add("Всички");
            departmentNames.AddRange(Teachers.Select(t => t.DepartmentName).Distinct());
            DepartmentNames = departmentNames;
        }
    }
}
