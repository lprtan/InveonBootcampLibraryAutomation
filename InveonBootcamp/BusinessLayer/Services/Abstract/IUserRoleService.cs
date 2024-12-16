using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstract
{
    public interface IUserRoleService
    {
        Task<IdentityResult> AddRoleAsync(string userName, string roleName);
        Task<IdentityResult> RemoveRoleUserAsync(string userId, string roleName);
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<IdentityResult> DeleteRoleAsync(string roleName);
        Task<IdentityResult> UpdateUserRoleAsync(string userId, string oldRoleName, string newRoleName);
        Task<List<string>> GetUserRolesAsync(string userName);
    }
}
