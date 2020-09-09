using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Services.Services;
using GraduationWorksOrganizer.Web.Controllers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        /// Усер мениджър сървис
        /// </summary>
        private UserManager<ApplicationIdentityBase> _userManager;

        #region Initialization

        public FileController(UserManager<ApplicationIdentityBase> userManager)
        {
            _userManager = userManager;
        }

        #endregion

        #region MyRegion

        [HttpGet]
        [Route("{thesisUserEntryId}")]
        public IActionResult OnGet(int thesisUserEntryId)
        {
            List<FileNameViewModel> testvms = new List<FileNameViewModel>();
            testvms.Add(new FileNameViewModel() { Id = 1, FileName = "Документ.pdf" });
            testvms.Add(new FileNameViewModel() { Id = 1, FileName = "Документ2.pdf" });
            testvms.Add(new FileNameViewModel() { Id = 1, FileName = "Документ3.pdf" });
            testvms.Add(new FileNameViewModel() { Id = 1, FileName = "Документ4.pdf" });
            return Ok(testvms);
        }

        #endregion
    }
}
