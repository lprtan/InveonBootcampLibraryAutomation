using BusinessLayer.Services.Abstract;
using CoreLayer.Dtos;
using InveonBootcamp.LibraryAutomation.Models;
using Microsoft.AspNetCore.Mvc;

namespace InveonBootcamp.LibraryAutomation.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateRoleToUser(string userName)
        {

            return View((object)userName);
        }


        [HttpPost]
        public async Task<IActionResult> CreateRoleToUser(string userName, string roleName)
        {
            var result = await _userRoleService.AddRoleAsync(userName, roleName);

            if (result.Succeeded)
            {
                return RedirectToAction("GetAllUser", "User");
            }

            return View(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var result = await _userRoleService.CreateRoleAsync(roleName);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Book");
                //return RedirectToAction("ListRoles");
            }

            return View(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRoleFromUser(string userId, string roleName)
        {
            var result = await _userRoleService.RemoveRoleUserAsync(userId, roleName);

            if (result.Succeeded)
            {
                return RedirectToAction("GetAllUser", "User");
            }

            return View(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var result = await _userRoleService.DeleteRoleAsync(roleName);

            if (result.Succeeded)
            {
                return RedirectToAction("ListRoles");
            }

            return View("Error", new { message = "Rol silinemedi." });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserRole(string userId, string oldRoleName, string newRoleName)
        {
            var result = await _userRoleService.UpdateUserRoleAsync(userId, oldRoleName, newRoleName);

            if (result.Succeeded)
            {
                return RedirectToAction("GetAllUser", "User");
            }

            return View(result.Errors);
        }

        public async Task<IActionResult> UpdateUserRoleIndex(string userId, string oldRoleName)
        {
            var userUpdateRole = new UserUpdateRolDto
            {
                UserId = userId,
                OldRoleName = oldRoleName
            };

            return View(userUpdateRole);
        }

    }
}
