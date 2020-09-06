using GraduationWorksOrganizer.Common;
using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using GraduationWorksOrganizer.Database.Models.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterTeacherModel : PageModel
    {
        #region Declarations

        private readonly SignInManager<ApplicationIdentityBase> _signInManager;
        private readonly UserManager<ApplicationIdentityBase> _userManager;
        private readonly IAsyncRepository<Faculty> _facultiesdbService;
        private readonly IAsyncRepository<Department> _deparmentsdbService;
        private readonly ILogger<RegisterStudentModel> _logger;

        #endregion

        #region Constructor
        public RegisterTeacherModel(IAsyncRepository<Faculty> facultiesdbService,
                                    IAsyncRepository<Department> deparmentsdbService,
                                    UserManager<ApplicationIdentityBase> userManager,
                                    SignInManager<ApplicationIdentityBase> signInManager,
                                    ILogger<RegisterStudentModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _facultiesdbService = facultiesdbService;
            _deparmentsdbService = deparmentsdbService;
        }

        #endregion

        #region InputModels

        public class TeacherRegisterInputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }


            [Required]
            public string Names { get; set; }
            [Required]
            public string Cabinet { get; set; }
            [Required]
            public string PhoneNumber { get; set; }
            [Required]
            public string ScienceDegree { get; set; }

            public int FacultyId { get; set; }
            [Required]
            public int DepartmentId { get; set; }
        }

        #endregion

        #region Properties

        [BindProperty]
        public TeacherRegisterInputModel Input { get; set; }

        public IEnumerable<Faculty> Faculties { get; set; }
        public IEnumerable<Department> Departments { get; set; }

        #endregion

        public async Task OnGetAsync()
        {
            Faculties = await _facultiesdbService.GetAll();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                ApplicationIdentityBase user = GenerateTeacher();
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Constants.RoleNames.TeacherRole);
                    //await SendConfirmationEmail(user);
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect("~/");
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            Faculties = await _facultiesdbService.GetAll();
            Departments = await _deparmentsdbService.GetAll(d => d.FacultyId == Input.FacultyId);
            return Page();
        }

        /// <summary>
        /// Метод за изпращане на имейл за потвърждение
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task SendConfirmationEmail(ApplicationIdentityBase user)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = user.Id, code = code },
                protocol: Request.Scheme);

            // TO DO:  await _emailSender.SendComfirmationMessageAsync(Input.Email, callbackUrl);
        }

        /// <summary>
        /// Метод който връща учител от текущия Инпут модел
        /// </summary>
        /// <returns></returns>
        private Teacher GenerateTeacher()
        {
            return new Teacher()
            {
                UserName = Input.Email,
                Email = Input.Email,
                DepartmentId = Input.DepartmentId,
                Name = Input.Names,
                Cabinet = Input.Cabinet,
                ScienceDegree = Input.ScienceDegree,
                PhoneNumber = Input.PhoneNumber,
            };
        }
    }
}
