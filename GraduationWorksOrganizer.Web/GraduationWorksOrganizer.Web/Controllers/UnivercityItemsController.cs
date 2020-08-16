using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Core.Database.Models;
using GraduationWorksOrganizer.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
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
        private readonly IAsyncRepository _repository;

        #endregion // Declarations

        #region Initialization

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository"></param>
        public UnivercityItemsController(IAsyncRepository repository)
        {
            _repository = repository;
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
            return await GetByExpression<Department>(d => d.FacultyId == facultyId);
        }

        /// <summary>
        /// Метод който връща всички катедри по дад. ID на факултет
        /// </summary>
        [HttpGet]
        [Route("Specialties/{departmentId}")]
        public async Task<IActionResult> GetSpetialties(int departmentId)
        {
            return await GetByExpression<Specialty>(s => s.DepartmentId == departmentId);
        }

        /// <summary>
        /// Метод който връща всички катедри по дад. ID на факултет
        /// </summary>
        [HttpGet]
        [Route("Groups/{specialtyId}")]
        public async Task<IActionResult> GetGroups(int specialtyId)
        {
            return await GetByExpression<Group>(g => g.SpecialtyId == specialtyId);
        }

        #endregion // Methods

        #region Helpers

        /// <summary>
        /// Метод който връща резултат по филтър и тип
        /// </summary>
        /// <typeparam name="TModelType"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        private async Task<IActionResult> GetByExpression<TModelType>(Expression<Func<TModelType, bool>> expression)
            where TModelType : class, IDatabaseEntity
        {
            var departments = await _repository.GetAll(expression);
            if (departments != null)
            {
                return Ok(departments);
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion //Helpers
    }
}
