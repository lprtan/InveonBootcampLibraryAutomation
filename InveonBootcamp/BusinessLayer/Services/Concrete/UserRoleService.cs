using BusinessLayer.Services.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Concrete
{
    public class UserRoleService : IUserRoleService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleService(UserManager<UserApp> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IdentityResult> AddRoleAsync(string userName, string roleName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı." });
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result;
        }

        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            //if (roleExists)
            //{
            //    return BadRequestResult("");
            //}

            var role = new IdentityRole(roleName);
            var result = await _roleManager.CreateAsync(role);
            return result;
        }

        public async Task<IdentityResult> DeleteRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Rol bulunamadı." });
            }

            var result = await _roleManager.DeleteAsync(role);
            return result;
        }

        public async Task<List<string>> GetUserRolesAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                
                return roles.ToList();
            }

            return new List<string>();
        }

        public async Task<IdentityResult> RemoveRoleUserAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı." });
            }

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            return result;
        }

        public async Task<IdentityResult> UpdateUserRoleAsync(string userId, string oldRoleName, string newRoleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı." });
            }

            var removeResult = await _userManager.RemoveFromRoleAsync(user, oldRoleName);
            if (!removeResult.Succeeded)
            {
                return removeResult; 
            }

            var addResult = await _userManager.AddToRoleAsync(user, newRoleName);
            return addResult;
        }
    }
}
