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

            if (roleExists)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Rol bulunamadı." });
            }

            var role = new IdentityRole(roleName);
            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Rol oluşturulamadı." });
            }

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

            if (!result.Succeeded)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Rol silinemedi." });
            }

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

            if (!result.Succeeded)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı rolü silinemedi." });
            }

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
                return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı rolü silnirken hata oluştu" });
            }

            var addResult = await _userManager.AddToRoleAsync(user, newRoleName);

            if (!addResult.Succeeded)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı rolü güncellenirken hata oluştu" });
            }

            return addResult;
        }
    }
}
