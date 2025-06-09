using Bl.DTO.User;
using BL.Constants;
using BL.Contracts.GeneralService;
using BL.Contracts.GeneralService.CMS;
using BL.Contracts.IMapper;
using Domains.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resources;

using Shared.GeneralModels.ResultModels;
using System.Security.Claims;

namespace BL.GeneralService.CMS
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IBaseMapper _mapper;
        public UserAuthenticationService(UserManager<ApplicationUser> userManager,
             SignInManager<ApplicationUser> signInManager, IBaseMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public async Task<BaseResult> RegisterUserAsync(RegisterDto registerDto)
        {
            //var user = _mapper.MapModel<RegisterDto, ApplicationUser>(registerDto);


            var user = new ApplicationUser()
            {
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PasswordHash = registerDto.Password,
                UserName = registerDto.Email,


            };
            IdentityResult identityResult = await _userManager.CreateAsync(user, registerDto.Password); // Hash Password

            if (identityResult.Succeeded)
            {
                // Create  Role
                if (!string.IsNullOrEmpty(registerDto.Role))
                {
                    await _userManager.AddToRoleAsync(user, registerDto.Role);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, SD.Roles.Customer);
                }
                // Create Cookie
                await _signInManager.SignInAsync(user, isPersistent: false);

            }
            return new BaseResult()
            {
                Success = identityResult.Succeeded,
                Errors = identityResult.Errors?.Select(e => e.Description)
            };

        }
        public async Task<BaseResult> LoginUserAsync(LoginDto model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return new BaseResult { Success = true, Message = "Login successful." };
                }
            }

            //return new BaseResult { Success = false, Errors = ["Invalid email or password."] };
            return new BaseResult { Success = false, Message = "Invalid email or password." };
        }
        public async Task<bool> IsUserAuthorizedAsync(ApplicationUser user, string policy)
        {
            return await _userManager.IsInRoleAsync(user, policy); // Simplified example, replace with actual authorization logic
        }

        public async Task<ApplicationUser> GetAuthenticatedUserAsync(ClaimsPrincipal principal)
        {
            return await _userManager.GetUserAsync(principal);
        }

        public async Task<AuthenticatedUserResult> GetAuthenticatedUserAsync(string email, string password)
        {
            var result = new AuthenticatedUserResult();

            // Find the user by their email
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                result.Success = false;
                result.Message = "User not found.";
                return result; // No user found with that email number
            }

            // Check if the password is correct
            var passwordSignInResult = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (passwordSignInResult.Succeeded)
            {
                result.Success = true;
                result.User = user; // Authentication successful, return the user
                return result;
            }

            // Authentication failed
            result.Success = false;
            result.Message = "Invalid password.";
            return result;
        }

        public async Task<BaseResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            var response = new BaseResult();

            // Await the asynchronous user retrieval
            var user = await _userManager.FindByIdAsync(userId);

            // If user is not found, return an error in the response
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
                return response;
            }

            // Attempt to change the password
            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            // Return success or failure in the response based on the result
            if (result.Succeeded)
            {
                response.Success = true;
                response.Message = "Password changed successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = string.Join(", ", result.Errors.Select(e => e.Description));
            }

            return response;
        }
        public async Task<SignInResult> PasswordSignInAsync(string email, string password, bool isPersistent, bool lockoutOnFailure)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent, lockoutOnFailure);

            return result;
        }
        public async Task<BaseResult> ResetPasswordAsync(PasswordResetDto resetDto)
        {
            var response = new BaseResult();

            // Find the user by their email number
            var user = await _userManager.FindByEmailAsync(resetDto.Email);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
                return response;
            }

            // Generate a password reset token for the user
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            // Here you would send this token to the user (via SMS or email) in a real application.

            // Reset the password using the token (this should be done after the user has verified the token)
            var result = await _userManager.ResetPasswordAsync(user, token, resetDto.NewPassword);
            if (result.Succeeded)
            {
                response.Success = true;
                response.Message = "Password reset successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = string.Join(", ", result.Errors.Select(e => e.Description));
            }

            return response;
        }
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
