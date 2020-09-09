using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Services.Services;
using GraduationWorksOrganizer.Web.Controllers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;
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
        /// Усер мениджър сървис
        /// </summary>
        private UserManager<ApplicationIdentityBase> _userManager;

        private readonly UserEntryFilesViewModelService<UserEntryFileNameViewModel> _filesVmService;

        #region Initialization

        /// <summary>
        /// Констролер 
        /// </summary>
        /// <param name="userManager"></param>
        public FileController(UserManager<ApplicationIdentityBase> userManager,
                               UserEntryFilesViewModelService<UserEntryFileNameViewModel> filesVmService)
        {
            _userManager = userManager;
            _filesVmService = filesVmService;
        }

        #endregion

        #region MyRegion

        [HttpGet("{thesisUserEntryId}")]
        public async Task<IActionResult> OnGet(int thesisUserEntryId)
        {
            IEnumerable<UserEntryFileNameViewModel> fileViewModels = await _filesVmService.GetThesisUserEntries(thesisUserEntryId);
            return Ok(fileViewModels);
        }

        [HttpPut]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            await Task.CompletedTask;
            string fileName = file.FileName.Split("\\").Last();
            return Ok(new UserEntryFileNameViewModel() { Id = 999, FileName = fileName });
        }
        #endregion
    }
}
