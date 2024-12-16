using BusinessLayer.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InveonBootcamp.LibraryAutomation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _accountService.LogOut();
            return RedirectToAction("Login", "User");
        }
    }
}
