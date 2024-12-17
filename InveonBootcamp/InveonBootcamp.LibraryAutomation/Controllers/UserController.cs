using BusinessLayer.Services.Abstract;
using CoreLayer.Dtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace InveonBootcamp.LibraryAutomation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _roleService;

        public UserController(IUserService userService, IUserRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userModel)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userService.CreateUserAsync(userModel);

            if (user.IsSuccess)
            {
                return RedirectToAction("Login", "User");
            }

            return View();
        }

        public async Task<IActionResult> GetUser()
        {
            var userName = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(userName))
            {
                RedirectToAction("Error", "Error", new { message = "Kullanıcı adı boş olamaz" });
            }

            var user = await _userService.GetUserByNameAsync(userName);

            if (!user.IsSuccess)
            {
                RedirectToAction("Error", "Error", new { message = user.ErrorMessage });
            }

            return View(user.User);
        }

        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUserAsync();

            var userWithRolesDto = new List<UserWithRolesDto>();

            if (userWithRolesDto == null)
            {
                return RedirectToAction("Error", "Error", new { message = users.ErrorMessage });
            }

            foreach (var user in users.User)
            {
                var roles = await _roleService.GetUserRolesAsync(user.UserName);

                userWithRolesDto.Add(new UserWithRolesDto
                {
                    User = user,
                    Roles = roles
                });
            }

            return View(userWithRolesDto);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginDto userLoginModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userService.LoginUserAsync(userLoginModel);

            if (user.IsSuccess)
            {
                HttpContext.Session.SetString("UserName", userLoginModel.UserName);

                var roles = await _roleService.GetUserRolesAsync(userLoginModel.UserName);

                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Book");
                }
            }

            return RedirectToAction("Error", "Error", new { message = user.ErrorMessage });
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUser(UserDto userUpdateModel)
        {
            var user = await _userService.UpdateUserAsync(userUpdateModel);

            if (user.IsSuccess)
            {
                return RedirectToAction("Index", "Book");
            }

            return RedirectToAction("Error", "Error", new { message = user.ErrorMessage });

        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userService.DeleteByIdAsync(userId);

            if (user.IsSuccess)
            {
                return RedirectToAction("GetAllUser", "User");
            }

            return RedirectToAction("Error", "Error", new { message = user.ErrorMessage });
        }
    }
}
