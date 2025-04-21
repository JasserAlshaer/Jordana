using Microsoft.AspNetCore.Mvc;

namespace Jordana.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Booking()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }
        public IActionResult History()
        {
            return View();
        }
        public IActionResult Rate()
        {
            return View();
        }
    }
}
