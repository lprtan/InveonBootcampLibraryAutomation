using InveonBootcamp.LibraryAutomation.Models;
using Microsoft.AspNetCore.Mvc;

namespace InveonBootcamp.LibraryAutomation.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Error/Error")]
        public IActionResult Error(string message)
        {
            var errorViewModel = new ErrorViewModel
            {
                ErrorMessage = message
            };

            return View(errorViewModel);
        }
    }
}
