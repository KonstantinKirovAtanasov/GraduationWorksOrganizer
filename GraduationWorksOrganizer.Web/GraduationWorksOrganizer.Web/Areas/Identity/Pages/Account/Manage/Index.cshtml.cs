using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using GraduationWorksOrganizer.Database.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationIdentityBase> _userManager;
        private readonly SignInManager<ApplicationIdentityBase> _signInManager;
        private readonly ApplicationUserDatabaseService _appUserDbService;
        private readonly IQueryProvider<FileContent> _fileQueryProvider;
        private readonly IAsyncRepository<Group> _groupsAsyncRepository;
        private readonly IAsyncRepository<Specialty> _specialtiesAsyncRepository;
        private readonly IAsyncRepository<Department> _departmetnAsyncRepository;
        private readonly string defaultImagePath;

        #region Initialization

        public IndexModel(IWebHostEnvironment webHostEnvironment,
                          IQueryProvider<FileContent> fileQueryProvider,
                          IAsyncRepository<Group> groupsAsyncRepository,
                          IAsyncRepository<Specialty> specialtiesAsyncRepository,
                          IAsyncRepository<Department> departmetnAsyncRepository,
                          UserManager<ApplicationIdentityBase> userManager,
                          SignInManager<ApplicationIdentityBase> signInManager,
                          ApplicationUserDatabaseService appUserDbService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appUserDbService = appUserDbService;
            _fileQueryProvider = fileQueryProvider;
            _groupsAsyncRepository = groupsAsyncRepository;
            _specialtiesAsyncRepository = specialtiesAsyncRepository;
            _departmetnAsyncRepository = departmetnAsyncRepository;
            defaultImagePath = webHostEnvironment.WebRootPath
                             + Path.DirectorySeparatorChar.ToString()
                             + "images"
                             + Path.DirectorySeparatorChar.ToString()
                             + "DefaultProfilePicture.png";
        }

        #endregion

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public ApplicationIdentityBase UserIdentity { get; set; }

        public string ImageBase64 { get; set; }

        public string DepartmentName { get; set; }

        #region Student

        public string FacultyNumber { get; set; }
        public string SpecialtyName { get; set; }
        public string GroupName { get; set; }
        public int GroupYear { get; set; }

        #endregion

        #region Teacher

        public string ScienceDegree { get; set; }
        public string Cabinet { get; set; }
        public string PhoneNumber { get; set; }
        #endregion

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public IFormFile ImageFile { get; set; }

        }

        private async Task LoadAsync(ApplicationIdentityBase user)
        {
            UserIdentity = await _userManager.GetUserAsync(User);
            await LoadImageAsBase64Url(UserIdentity);
            if (UserIdentity is Teacher)
            {
                Teacher tchUser = UserIdentity as Teacher;
                Department department = await _departmetnAsyncRepository.GetById(tchUser.DepartmentId);

                ScienceDegree = tchUser.ScienceDegree;
                Cabinet = tchUser.Cabinet;
                PhoneNumber = tchUser.PhoneNumber;
                DepartmentName = department.Name;
            }
            else if (UserIdentity is Student)
            {
                Student stUser = UserIdentity as Student;
                Group group = await _groupsAsyncRepository.GetById(stUser.GroupId);
                Specialty specialty = await _specialtiesAsyncRepository.GetById(stUser.SpecialtyId);
                Department department = await _departmetnAsyncRepository.GetById(specialty.DepartmentId);
                GroupName = group.Name;
                GroupYear = group.FromYear;
                SpecialtyName = specialty.Name;
                DepartmentName = department.Name;
                FacultyNumber = stUser.FacultyNumber;
            }

        }

        private async Task LoadImageAsBase64Url(ApplicationIdentityBase UserIdentity)
        {
            FileContent image = await _fileQueryProvider.GetQuery().FirstOrDefaultAsync(fc => fc.Id == UserIdentity.ImageId);
            if (image != null)
            {
                ImageBase64 = Convert.ToBase64String(image.Content);
            }
            else
            {
                byte[] defaultImage;
                using (FileStream fs = new FileStream(defaultImagePath, FileMode.Open))
                {
                    defaultImage = new byte[fs.Length];
                    await fs.ReadAsync(defaultImage, 0, (int)fs.Length);
                }
                ImageBase64 = Convert.ToBase64String(defaultImage);
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            UserIdentity = await _userManager.GetUserAsync(User);
            if (UserIdentity == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(UserIdentity);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            if (Input.ImageFile != null)
            {
                byte[] imageResult;
                using (MemoryStream ms = new MemoryStream())
                {
                    await Input.ImageFile.CopyToAsync(ms);
                    imageResult = ms.ToArray();
                }
                await _appUserDbService.ChangeUserPhoto(user, imageResult);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
