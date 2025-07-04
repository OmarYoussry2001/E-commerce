﻿using Domains.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Contracts.GeneralService.CMS
{
    public interface IRoleManagementService
    {
        Task<IList<ApplicationUser>> GetUsersInRoleAsync(string role);
        Task<bool> DeleteUserAsync(Guid id);
        public Task<IEnumerable<IdentityRole>> GetAllRolesAsync();
    }
}
