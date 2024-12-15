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

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userModel)
        {
            var result = await _userService.CreateUserAsync(userModel);

            if (result.IsSuccess)
            {
                return RedirectToAction("Login", "User");
            }

            return View(result.User);
        }

        public async Task<IActionResult> GetUser()
        {
            var userName = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(userName))
            {
                return BadRequest("Kullanıcı adı boş olamaz.");
            }

            var user = await _userService.GetUserByNameAsync(userName);

            return View(user.User);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserDto userLoginModel)
        {
            var user = await _userService.LoginUserAsync(userLoginModel);

            if (user.IsSuccess)
            {
                HttpContext.Session.SetString("UserName", userLoginModel.UserName);
                return RedirectToAction("Index", "Book");
            }

            return View(user.User);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUser(UserDto userUpdateModel)
        {
            var user = await _userService.UpdateUserAsync(userUpdateModel);

            if (user.IsSuccess)
            {
                return RedirectToAction("Index", "Book");
            }

            return View(userUpdateModel);

        }
    }
}
