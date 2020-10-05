using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        public class InputModel
        {
            public int DateDefenceEventId { get; set; }

            public string Description { get; set; }

            public int UserEntryId { get; set; }
        }

        #region Properties

        [BindProperty]
        public InputModel Input { get; set; }

        public IEnumerable<FileViewModel> Files { get; set; }

        public int UserEntryId { get; set; }

        #endregion

        #region Methods

        public void OnGet(int userEntryId)
        {
            SelectFiles(userEntryId);
            UserEntryId = userEntryId;
        }

        public void OnPostProceed()
        {
            SelectFiles(Input.UserEntryId);
            UserEntryId = Input.UserEntryId;
        }

        public void OnPostCancel()
        {
            SelectFiles(Input.UserEntryId);
            UserEntryId = Input.UserEntryId;
        }

        private void SelectFiles(int userEntryId)
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
