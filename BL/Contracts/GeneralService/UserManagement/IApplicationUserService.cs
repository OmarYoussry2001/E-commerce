using Bl.DTO.User;
using Domains.Identity;

 
using Shared.GeneralModels.ResultModels;

namespace BL.Contracts.GeneralService.UserManagement
{
    public interface IApplicationUserService
    {
        Task<ApplicationUserDto> FindByIdAsync(string userId);
        Task<RegisterDto> FindDtoByIdAsync(string userId);
        Task<ApplicationUser> FindByPhoneAsync(string phoneNumber);
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<bool> IsEmailConfirmedAsync(ApplicationUser user);

        //Task<UserProfileDto> GetUserProfileAsync(string userId);
        //Task<BaseResult> UpdateUserProfileAsync(string userId, UserProfileDto userProfileDto);
    }
}
