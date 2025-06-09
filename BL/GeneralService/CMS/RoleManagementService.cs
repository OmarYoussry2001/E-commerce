using BL.Contracts.GeneralService.CMS;
using BL.Contracts.IMapper;
using Domains.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.GeneralService.CMS
{
    public class RoleManagementService : IRoleManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IBaseMapper _mapper;

        public RoleManagementService(UserManager<ApplicationUser> userManager,
                                     RoleManager<IdentityRole> roleManager,
                                     IBaseMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IList<ApplicationUser>> GetUsersInRoleAsync(string role)
        {
            return (await _userManager.GetUsersInRoleAsync(role)).Where(u => u.CurrentState == 1).ToList();
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var applicationUser = await _userManager.FindByIdAsync(id.ToString());
            return (await _userManager.DeleteAsync(applicationUser)).Succeeded;
        }

        public async Task<IEnumerable<IdentityRole>> GetAllRolesAsync()
        {
            return await Task.FromResult(_roleManager.Roles.ToList());
        }
    }
}
