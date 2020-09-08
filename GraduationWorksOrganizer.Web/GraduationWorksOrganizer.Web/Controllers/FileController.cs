using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        private UserEntryFilesService _userEntryFilesService;

        /// <summary>
        /// Усер мениджър сървис
        /// </summary>
        private UserManager<ApplicationIdentityBase> _userManager;

        #region Initialization

        public FileController(UserEntryFilesService userEntryFilesService,
                              UserManager<ApplicationIdentityBase> userManager)
        {
            _userEntryFilesService = userEntryFilesService;
            _userManager = userManager;
        }

        #endregion

        #region MyRegion

        //[HttpGet]
        //public async Task<IActionResult> OnGet(int thesisUserEntryId)
        //{
        //    await 
        //}

        #endregion
    }
}
