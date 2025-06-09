using Bl.DTO.User;
using BL.Contracts.GeneralService.UserManagement;
using BL.Contracts.IMapper;
using DAL.Contracts.Repositories;
using DAL.Exceptions;
using DAL.Repositories;
using Domains.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resources;
using Serilog;
 
using Shared.GeneralModels.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.GeneralService.UserManagement
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly IRepository<VwUserProfile> _userProfileService;
        private readonly IBaseMapper _mapper;
        private readonly ILogger _logger;

        public ApplicationUserService(UserManager<ApplicationUser> userManager,
            IBaseMapper mapper,

            ILogger logger)
        {
            _userManager = userManager;
            _mapper = mapper;

            _logger = logger;
        }

        public async Task<ApplicationUserDto> FindByIdAsync(string userId)
        {
            var entity = await _userManager.FindByIdAsync(userId);

            return _mapper.MapModel<ApplicationUser, ApplicationUserDto>(entity);
        }

        public async Task<ApplicationUser> FindByPhoneAsync(string phoneNumber)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<RegisterDto> FindDtoByIdAsync(string userId)
        {
            var entity = await _userManager.FindByIdAsync(userId);

            return _mapper.MapModel<ApplicationUser, RegisterDto>(entity);
        }

        public async Task<bool> IsEmailConfirmedAsync(ApplicationUser user)
        {
            return await _userManager.IsEmailConfirmedAsync(user);
        }

        /// <summary>
        /// Retrieves the user profile based on userId.
        /// </summary>
        //public async Task<UserProfileDto> GetUserProfileAsync(string userId)
        //{
        //    // Validate input (fail fast)
        //    if (string.IsNullOrWhiteSpace(userId))
        //        throw new ArgumentException(UserResources.UserNotFound, nameof(userId));

        //    // Get userProfile data 
        //    var userProfile = _userProfileService.GetAll().FirstOrDefault(u=>u.Id==userId )
        //        ?? throw new ArgumentNullException(UserResources.UserNotFound);

        //    // Map to DTO
        //    return _mapper.MapModel<VwUserProfile, UserProfileDto>(userProfile)
        //        ??throw new NotFoundException($"User {ValidationResources.EntityNotFound}", _logger);
        //}

        /// <summary>
        /// Updates the user profile with new data.
        /// </summary>
        //public async Task<BaseResult> UpdateUserProfileAsync(string userId, UserProfileDto userProfileDto)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null || user.CurrentState == 0)
        //    {
        //        return new BaseResult { Success = false, Message = "User not found." };
        //    }

        //    // Update user properties
        //    user.FirstName = userProfileDto.FirstName;
        //    user.LastName = userProfileDto.LastName;
        //    user.Email = userProfileDto.Email;
        //    user.Address = userProfileDto.Address;
        //    user.NationalId = userProfileDto.NationalId;
        //    user.PhoneNumber = userProfileDto.PhoneNumber;

        //    var result = await _userManager.UpdateAsync(user);
        //    if (result.Succeeded)
        //    {
        //        return new BaseResult { Success = true };
        //    }
        //    // Collect errors from IdentityResult
        //    var errors = result.Errors.Select(e => e.Description).ToList();
        //    return new BaseResult { Success = false, Message = string.Join(", ", errors) };
        //}
    }
}
