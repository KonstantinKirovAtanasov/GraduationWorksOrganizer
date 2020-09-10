using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Web.Controllers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly UserManager<ApplicationIdentityBase> _userManager;

        private readonly UserEntryFilesViewModelService<UserEntryFileNameViewModel> _filesVmService;

        private readonly CombinedQueryBaseService<ThesesUserEntry> _userEntryDbService;

        #region Initialization

        /// <summary>
        /// Констролер 
        /// </summary>
        /// <param name="userManager"></param>
        public FileController(UserManager<ApplicationIdentityBase> userManager,
                              CombinedQueryBaseService<ThesesUserEntry> userEntryDbService,
                              UserEntryFilesViewModelService<UserEntryFileNameViewModel> filesVmService)
        {
            _userManager = userManager;
            _filesVmService = filesVmService;
            _userEntryDbService = userEntryDbService;
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
        public async Task<IActionResult> Upload([FromHeader(Name = "ThesisUserEntryId")] int thesisUserEntryId, IFormFile file)
        {
            if (!await ValidateUserEntry(thesisUserEntryId))
                return BadRequest();

            byte[] fileContent = null;
            using (MemoryStream ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                fileContent = ms.ToArray();
            }

            AddUserEntryFileViewModel addVm = new AddUserEntryFileViewModel();
            addVm.UserEntryId = thesisUserEntryId;
            addVm.Content = fileContent;
            addVm.FileName = file.FileName;

            return Ok(await _filesVmService.AddUserEntryFile(addVm));
        }


        /// <summary>
        /// Метод който валидира дали ентрито е на текущия потребител
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ValidateUserEntry(int ThesisUserEntryId)
        {
            ThesesUserEntry userEntry = await _userEntryDbService.GetById(ThesisUserEntryId);
            string UserId = _userManager.GetUserId(User);
            return userEntry.StudentId == UserId;
        }
        #endregion
    }
}
