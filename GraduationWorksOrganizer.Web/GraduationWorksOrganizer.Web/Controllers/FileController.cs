using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Web.Controllers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Controllers
{
    /// <summary>
    /// Контролер за работа с файлове
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {
        /// <summary>
        /// Сървис за работа с Файлове
        /// </summary>
        private UserEntryFilesViewModelService<UserEntryFileNameViewModel> _userEntryFilesService;

        /// <summary>
        /// Усер мениджър сървис
        /// </summary>
        private UserManager<ApplicationIdentityBase> _userManager;

        #region Initialization

        public FileController(UserEntryFilesViewModelService<UserEntryFileNameViewModel> userEntryFilesService,
                              UserManager<ApplicationIdentityBase> userManager)
        {
            _userEntryFilesService = userEntryFilesService;
            _userManager = userManager;
        }

        #endregion

        #region MyRegion

        [HttpGet]
        [Route("{thesisUserEntryId}")]
        public async Task<IActionResult> OnGet(int thesisUserEntryId)
        {
            IEnumerable<UserEntryFileNameViewModel> files = await _userEntryFilesService.GetThesisUserEntries(thesisUserEntryId);
            return Ok(files);
        }

        #endregion
    }
}
