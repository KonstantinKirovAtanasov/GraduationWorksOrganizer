﻿using GraduationWorksOrganizer.Core.Additional;
using GraduationWorksOrganizer.Core.Database;
using GraduationWorksOrganizer.Database.Models;
using Microsoft.AspNetCore.Authentication;
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
    public class RegisterStudentModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAsyncRepository _dbService;
        private readonly ILogger<RegisterStudentModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterStudentModel(
            IAsyncRepository dbService,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterStudentModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _dbService = dbService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        /// Факултети
        /// </summary>
        public IEnumerable<Faculty> Faculties { get; set; }

        /// <summary>
        /// Катедри
        /// </summary>
        public IEnumerable<Department> Departments { get; set; }

        /// <summary>
        /// Специуалности
        /// </summary>
        public IEnumerable<Specialty> Specialties { get; set; }

        /// <summary>
        /// Групи
        /// </summary>
        public IEnumerable<Group> Groups { get; set; }

        public class InputModel
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

            public int SpecialtyId { get; set; }
            public int DepartmentId { get; set; }
            public int FacultyId { get; set; }
            [Required]
            public int GroupId { get; set; }
            [Required]
            public string Names { get; set; }
            [Required]
            public string PersonalNumber { get; set; }
            [Required]
            public string FacultyNumber { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            Faculties = await _dbService.GetAll<Faculty>();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new Student()
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    GroupId = Input.GroupId,
                    SpecialtyId = Input.SpecialtyId,
                    StudentName = Input.Names,
                    PersonalNumber = Input.PersonalNumber,
                    FacultyNumber = Input.FacultyNumber
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    // TO DO:  await _emailSender.SendComfirmationMessageAsync(Input.Email, callbackUrl);

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            await InitializeRequisites();
            return Page();
        }

        /// <summary>
        /// Метод който инициализира реквизитите за PageModel-a
        /// </summary>
        /// <returns></returns>
        private async Task InitializeRequisites()
        {
            Departments = await _dbService.GetAll<Department>(d => d.FacultyId == Input.FacultyId);
            Specialties = await _dbService.GetAll<Specialty>(s => s.DepartmentId == Input.DepartmentId);
            Groups = await _dbService.GetAll<Group>(g => g.SpecialtyId == Input.SpecialtyId);
            Faculties = await _dbService.GetAll<Faculty>();
        }
    }
}
