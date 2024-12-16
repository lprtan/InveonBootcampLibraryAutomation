using Microsoft.AspNetCore.Mvc;

namespace InveonBootcamp.LibraryAutomation.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
