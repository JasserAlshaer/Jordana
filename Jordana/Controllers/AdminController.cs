using Microsoft.AspNetCore.Mvc;

namespace Jordana.Controllers
{
    public class AdminController : Controller 
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult ManageDestinations()
        {
            return View();
        }

        public IActionResult ManageBooking()
        {
            return View();
        }

        public IActionResult ManageUsers()
        {
            return View();
        }

        public IActionResult ManageRating()
        {
            return View();
        }
    }
}
