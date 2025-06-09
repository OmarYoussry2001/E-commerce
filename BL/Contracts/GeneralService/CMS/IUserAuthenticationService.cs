using Bl.DTO.User;
using Domains.Identity;
using Microsoft.AspNetCore.Identity;
 
using Shared.GeneralModels.ResultModels;
using System.Security.Claims;

namespace BL.Contracts.GeneralService.CMS
{
    public interface IUserAuthenticationService
    {
        Task<BaseResult> RegisterUserAsync(RegisterDto user);
        Task<BaseResult> LoginUserAsync(LoginDto model);
        Task<ApplicationUser> GetAuthenticatedUserAsync(ClaimsPrincipal principal);
        Task<bool> IsUserAuthorizedAsync(ApplicationUser user, string policy);
        Task<AuthenticatedUserResult> GetAuthenticatedUserAsync(string email, string password);
        Task<BaseResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
        Task<SignInResult> PasswordSignInAsync(string email, string password, bool isPersistent, bool lockoutOnFailure);
        Task<BaseResult> ResetPasswordAsync(PasswordResetDto resetDto);
        Task SignOutAsync();



    }
}
