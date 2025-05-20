using System.Diagnostics;
using Jordana.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jordana.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult Index () 
        { 
            return View(); 
        }
        public IActionResult AboutUs()
        { 
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Services()
        { 
            return View();
        }
        public IActionResult Destination()
        {
            return View();
        }
        public IActionResult Booking()
        {
            return View();
        }
        public IActionResult OurGuides()
        {
            return View();
        }
        public IActionResult Testimonial()
        {
           // var query = _mydatabase.Reviews.ToList();
            return View();
        }
    }
}
