using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Controllers
{
    /// <summary>
    /// Контролер за асинхронни заявки при регистрация ()
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UnivercityItemsController : ControllerBase
    {
        #region Declarations

        /// <summary>
        /// Репоситори
        /// </summary>
        private readonly IAsyncRepository<Department> _deparmentsRepository;
        private readonly IAsyncRepository<Specialty> _specialtiesRepository;
        private readonly IAsyncRepository<Group> _groupsRepository;

        #endregion // Declarations

        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository"></param>
        public UnivercityItemsController(IAsyncRepository<Department> deparmentsRepository,
                                         IAsyncRepository<Specialty> specialtiesRepository,
                                         IAsyncRepository<Group> groupsRepository)
        {
            _deparmentsRepository = deparmentsRepository;
            _specialtiesRepository = specialtiesRepository;
            _groupsRepository = groupsRepository;
        }

        #endregion // Initialization

        #region Methods

        /// <summary>
        /// Метод който връща всички катедри по дад. ID на факултет
        /// </summary>
        [HttpGet]
        [Route("Departments/{facultyId}")]
        public async Task<IActionResult> GetDepartments(int facultyId)
        {
            IEnumerable<Department> result = await _deparmentsRepository.GetAll(d => d.FacultyId == facultyId);
            return Ok(result);
        }

        /// <summary>
        /// Метод който връща всички катедри по дад. ID на факултет
        /// </summary>
        [HttpGet]
        [Route("Specialties/{departmentId}")]
        public async Task<IActionResult> GetSpetialties(int departmentId)
        {
            IEnumerable<Specialty> result = await _specialtiesRepository.GetAll(s => s.DepartmentId == departmentId);
            return Ok(result);
        }

        /// <summary>
        /// Метод който връща всички катедри по дад. ID на факултет
        /// </summary>
        [HttpGet]
        [Route("Groups/{specialtyId}")]
        public async Task<IActionResult> GetGroups(int specialtyId)
        {
            IEnumerable<Group> result = await _groupsRepository.GetAll(g => g.SpecialtyId == specialtyId);
            return Ok(result);
        }

        #endregion // Methods
    }
}
