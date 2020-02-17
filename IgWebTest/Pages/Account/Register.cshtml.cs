using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IgWebTest.EFContext;
using IgWebTest.Pages.Account.InputModel;
using IgWebTest.UnitOfWork;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace IgWebTest
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IgniteTestDatabaseContext _context;
        private IUnitOfWork _unitOfWork;

        public RegisterModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<RegisterModel> logger, IEmailSender emailSender, RoleManager<IdentityRole> roleManager, IgniteTestDatabaseContext context, IUnitOfWork unitOfWork)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public RegisterInputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            ExternalLogins = new List<AuthenticationScheme>();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var fullName = string.Format("{0} {1} {2}", Input.FirstName, Input.LastName);
                var user = new IgWebTest.Models.IgniteUser
                {
                    UserName = Input.UserName,
                    NormalizedUserName = Input.UserName,
                    IgniteEmail = Input.Email,
                    NormalizedIgniteEmail = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = fullName,
                    FirstNameLastName = Input.FirstName,
                    PasswordHash = Input.Password,
                    IsInternalUser = true,
                    HiredDate = DateTime.Now,
                    IgniteUserCreatedDate = DateTime.Now,

                };

                if (!Input.IsAdmin)
                {
                    user.IgniteEmailConfirmed = true;
                }

                var role = new Models.IgniteRole();
                //role.NormalizedName

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(Utility.UserRoles.UserRole.AdminUser))
                    {
                        await _unitOfWork.IgniteRoleRepository.CreateRoleAsync(
                            new Models.IgniteRole(Utility.UserRoles.UserRole.AdminUser));
                    }

                    if (!await _roleManager.RoleExistsAsync(Utility.UserRoles.UserRole.HR))
                    {
                        await _unitOfWork.IgniteRoleRepository.CreateRoleAsync(
                            new Models.IgniteRole(Utility.UserRoles.UserRole.HR));
                    }

                    if (!await _roleManager.RoleExistsAsync(Utility.UserRoles.UserRole.ManagerUser))
                    {
                        await _unitOfWork.IgniteRoleRepository.CreateRoleAsync(
                            new Models.IgniteRole(Utility.UserRoles.UserRole.ManagerUser));
                    }

                    if (!await _roleManager.RoleExistsAsync(Utility.UserRoles.UserRole.RegEmp))
                    {
                        await _unitOfWork.IgniteRoleRepository.CreateRoleAsync(
                            new Models.IgniteRole(Utility.UserRoles.UserRole.RegEmp));
                    }
                }
            }
        }
    }
}