using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.Pages
{
    public class ThesesCorrespondenceModel : PageModel
    {
        #region Declarations

        private readonly CombinedQueryBaseService<ThesisUserEntryFileContent> _filesDbService;

        #endregion

        #region Constructor

        public ThesesCorrespondenceModel(CombinedQueryBaseService<ThesisUserEntryFileContent> filesDbService)
        {
            _filesDbService = filesDbService;
        }

        #endregion

        #region Properties

        public IEnumerable<FileViewModel> Files { get; set; }

        #endregion

        #region Methods

        public void OnGet(int userEntryId)
        {
            Files = _filesDbService.GetQuery()
                                   .Where(f => f.UserEntryId == userEntryId)
                                   .Select(f => new FileViewModel()
                                   {
                                       Name = f.FileName,
                                       Size = f.Content.Length / 1024,
                                       Id = f.Id
                                   });
        }

        #endregion

    }
}
