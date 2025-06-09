
using Bl.DTO.User;
using BL.Constants;
using BL.Contracts.GeneralService.CMS;
using BL.Contracts.Services;
using BL.Services;
using Domains.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using System.Threading.Tasks;
using UI.Controllers.Base;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WatchSystem.Controllers
{

    //[Authorize]

    public class AccountController : BaseController
    {
        private readonly IUserAuthenticationService _userAuthenticationService;
        private readonly IRoleManagementService _roleManagementService;

        public AccountController(IUserAuthenticationService userAuthenticationService,  IRoleManagementService roleManagementService, Serilog.ILogger logger) : base(logger)
        {
            _userAuthenticationService = userAuthenticationService;
            _roleManagementService = roleManagementService;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            var userRegister = new RegisterDto()
            {
                Roles = await _roleManagementService.GetAllRolesAsync(),
          
            };


            return View("Register", userRegister);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterDto registerDTO)
        {
            //ModelState.Remove(nameof(registerDTO.Roles));
            try
            {
                if (!ModelState.IsValid)
                    return View("Register", registerDTO);

                var result = await _userAuthenticationService.RegisterUserAsync(registerDTO);

                if (result.Success)
                    return Redirect("/Home/index");

                if (result.Errors != null && result.Errors.Any())
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                return View("Register", registerDTO);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }


        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            //ViewData["ReturnUrl"] = ReturnUrl;
            return View("Login", new LoginDto { ReturnUrl = ReturnUrl ?? "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginDto loginDTO)
        {
            //ModelState.Remove(nameof(loginDTO.ReturnUrl));

            if (!ModelState.IsValid)
                return View("Login", loginDTO);

            try
            {

                var result = await _userAuthenticationService.LoginUserAsync(loginDTO);
                if (result.Success)
                {

                    if (string.IsNullOrEmpty(loginDTO.ReturnUrl))

                        return Redirect("/Home/index");
                    else

                        return Redirect(loginDTO.ReturnUrl);
                }

                ModelState.AddModelError("Email", result.Message.ToString());

                return View("Login");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }


        public IActionResult Logout()
        {
            _userAuthenticationService.SignOutAsync();

            return View("Login");

        }
        public IActionResult AccessDenied()
        {

            return View("AccessDenied");
        }



    }
}
