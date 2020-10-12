using AutoMapper;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services.BaseServices;
using GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.Pages
{
    public class ThesesCorrespondenceModel : PageModel
    {
        #region Declarations

        private readonly CombinedQueryBaseService<ThesisUserEntryFileContent> _filesDbService;
        private readonly CombinedQueryBaseService<ThesesUserEntry> _thesisUserEntryDbService;
        private readonly CombinedQueryBaseService<ThesisDefenceEvent> _thesesDefenceEventDbService;
        private readonly CombinedQueryBaseService<ThesisApprovementRequest> _thesisApprovementDbService;
        private readonly CombinedQueryBaseService<TeacherDefencesDates> _defenceDatesService;
        private readonly UserManager<ApplicationIdentityBase> _userManager;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public ThesesCorrespondenceModel(CombinedQueryBaseService<ThesisUserEntryFileContent> filesDbService,
                                         CombinedQueryBaseService<ThesesUserEntry> thesisUserEntryDbService,
                                         CombinedQueryBaseService<ThesisDefenceEvent> thesesDefenceEventDbService,
                                         CombinedQueryBaseService<ThesisApprovementRequest> thesisApprovementDbService,
                                         CombinedQueryBaseService<TeacherDefencesDates> defenceDatesService,
                                         UserManager<ApplicationIdentityBase> userManager)
        {
            _filesDbService = filesDbService;
            _thesisUserEntryDbService = thesisUserEntryDbService;
            _thesesDefenceEventDbService = thesesDefenceEventDbService;
            _thesisApprovementDbService = thesisApprovementDbService;
            _defenceDatesService = defenceDatesService;
            _userManager = userManager;
            _mapper = new Mapper(new DefenceDateViewModel().GetMapperConfiguration());
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
        public IEnumerable<ThesisApprovementRequest> ApprovementRequests { get; set; }
        public IEnumerable<DefenceDateViewModel> DefenceDates { get; set; }
        public DefenceDateViewModel SelectedDefenceDate { get; set; }

        public int UserEntryId { get; set; }

        public async Task OnGet(int userEntryId)
        {

        #endregion

        #region Methods
            UserEntryId = userEntryId;
            SelectFiles(userEntryId);
            await InitApprovementRequests(userEntryId);

            string userId = _userManager.GetUserId(User);

            ThesisDefenceEvent de = _thesesDefenceEventDbService.GetQuery().FirstOrDefault(de => de.ThesesUserEntryId == userEntryId);
            if (de != null)
            {
                TeacherDefencesDates defencesDate = _defenceDatesService.GetQuery().First(dd => dd.Id == de.DefenceDateId);
                SelectedDefenceDate = _mapper.Map<DefenceDateViewModel>(defencesDate);
            }
            else
            {
                DefenceDates = _defenceDatesService.GetQuery().Where(d => d.TeacherId == userId).Select(dd => _mapper.Map<DefenceDateViewModel>(dd));
            }
        }

        public async Task<IActionResult> OnPostProceed()
        {
            SelectFiles(Input.UserEntryId);
            await InitApprovementRequests(Input.UserEntryId);
            UserEntryId = Input.UserEntryId;

            if (Input.DateDefenceEventId == 0)
            {
                ModelState.AddModelError(string.Empty, "За да предвижите избрания проект за защита трябва да изберете Дата на защита от падащото меню");
                return Page();
            }

            ThesesUserEntry userEntry = await GetUserEntry();
            userEntry.State = Common.Enums.ThesisUserEntryState.Approve;
            await _thesisUserEntryDbService.Update(userEntry);
            ThesisDefenceEvent defenceEvent = new ThesisDefenceEvent()
            {
                ThesesUserEntry = userEntry,
                DefenceDateId = Input.DateDefenceEventId,
            };
            await _thesesDefenceEventDbService.Add(defenceEvent);
            return Redirect("/GraduationWork/MyThesesTeacher");
        }

        public async Task<IActionResult> OnPostCancel()
        {
            SelectFiles(Input.UserEntryId);
            await InitApprovementRequests(Input.UserEntryId);
            UserEntryId = Input.UserEntryId;

            if (string.IsNullOrEmpty(Input.Description))
            {
                ModelState.AddModelError(string.Empty, "За да откажете защитата на избрания проект трябва да въведете Описание");
                return Page();
            }

            ThesesUserEntry userEntry = await GetUserEntry();
            userEntry.State = Common.Enums.ThesisUserEntryState.Initialized;
            await _thesisUserEntryDbService.Update(userEntry);
            ThesisApprovementRequest req = await _thesisApprovementDbService.GetById(ApprovementRequests.Last().Id);
            req.ResponseDescription = Input.Description;
            await _thesisApprovementDbService.Update(req);
            return Redirect("/GraduationWork/MyThesesTeacher");
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

        private async Task InitApprovementRequests(int userEntryId)
        {
            ApprovementRequests = await _thesisApprovementDbService.GetAll(p => p.ThesesUserEntryId == userEntryId);
        }

        private async Task<ThesesUserEntry> GetUserEntry()
        {
            return await _thesisUserEntryDbService.GetAllIncluding(ue => ue.ThesesRequests).FirstOrDefaultAsync(ue => ue.Id == Input.UserEntryId);
        }

        #endregion

    }
}
