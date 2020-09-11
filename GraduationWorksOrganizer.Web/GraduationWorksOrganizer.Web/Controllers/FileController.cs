using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Services.MapEntitiesServices;
using GraduationWorksOrganizer.Web.Controllers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
        private readonly UserManager<ApplicationIdentityBase> _userManager;

        private readonly UserEntryFilesViewModelService<UserEntryFileNameViewModel> _filesVmService;

        private readonly CombinedQueryBaseService<ThesesUserEntry> _userEntryDbService;

        private readonly CombinedQueryBaseService<ThesisUserEntryFileContent> _fileContentDbService;

        #region Initialization

        /// <summary>
        /// Констролер 
        /// </summary>
        /// <param name="userManager"></param>
        public FileController(UserManager<ApplicationIdentityBase> userManager,
                              CombinedQueryBaseService<ThesesUserEntry> userEntryDbService,
                              CombinedQueryBaseService<ThesisUserEntryFileContent> fileContentDbService,
                              UserEntryFilesViewModelService<UserEntryFileNameViewModel> filesVmService)
        {
            _userManager = userManager;
            _filesVmService = filesVmService;
            _userEntryDbService = userEntryDbService;
            _fileContentDbService = fileContentDbService;
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

        [HttpDelete]
        public async Task<IActionResult> OnDelete([FromHeader] int fileContentId)
        {
            ThesisUserEntryFileContent thesisEntry = await _fileContentDbService.GetById(fileContentId);
            if (!await ValidateUserEntry(thesisEntry.UserEntryId))
                return BadRequest();

            await _fileContentDbService.Delete(thesisEntry);
            return Ok();
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadFile([FromHeader] int fileContentId)
        {
            ThesisUserEntryFileContent thesisEntry = await _fileContentDbService.GetById(fileContentId);
            if (User.IsInRole(Constants.RoleNames.StudentRole) && !await ValidateUserEntry(thesisEntry.UserEntryId))
                return BadRequest();

            Response.Headers.Add("fileName", thesisEntry.FileName);
            Response.Headers.Add("responseType", "arraybuffer");
            Stream stream = new MemoryStream(thesisEntry.Content);
            return new FileStreamResult(stream, "application/octet-stream");
        }

        /// <summary>
        /// Метод който валидира дали ентрито е на текущия потребител
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ValidateUserEntry(int thesisUserEntryId)
        {
            ThesesUserEntry userEntry = await _userEntryDbService.GetById(thesisUserEntryId);
            string UserId = _userManager.GetUserId(User);
            return userEntry.StudentId == UserId;
        }
        #endregion
    }
}
