using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GraduationWorksOrganizer.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeachersController : ControllerBase
    {
        /// <summary>
        /// Сървис за работа с учители
        /// </summary>
        private TeachersDatabaseService _teachersDbService;
        private IQueryProvider<Subject> _subjectQueryProvider;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="teachersDbService"></param>
        public TeachersController(TeachersDatabaseService teachersDbService,
                                  IQueryProvider<Subject> subjectQueryProvider)
        {
            _teachersDbService = teachersDbService;
            _subjectQueryProvider = subjectQueryProvider;
        }

        [HttpGet]
        public IActionResult OnGet([FromHeader] int subjectId)
        {
            int departmentId = _subjectQueryProvider.GetAllIncluding(s => s.Specialty).Where(subj => subj.Id == subjectId).Select(subj => subj.Specialty.DepartmentId).First();
            var a = _teachersDbService.GetTeachers().Where(t => t.DepartmentId == departmentId).Select(t => new
            {
                ScienceDegree = t.ScienceDegree,
                Name = t.Name,
                Id = t.Id,
            });
            return Ok(a);
        }
    }
}
