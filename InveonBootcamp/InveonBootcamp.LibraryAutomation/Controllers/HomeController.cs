using System.Diagnostics;
using InveonBootcamp.LibraryAutomation.Models;
using Microsoft.AspNetCore.Mvc;

namespace InveonBootcamp.LibraryAutomation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error()
        {
            var errorMessage = HttpContext.Items["ErrorMessage"]?.ToString() ?? "Bilinmeyen bir hata oluþtu.";
            var requestId = HttpContext.Items["RequestId"]?.ToString();

            var errorViewModel = new ErrorViewModel
            {
                RequestId = requestId,
                ErrorMessage = errorMessage
            };

            return View(errorViewModel);
        }
    }
}
