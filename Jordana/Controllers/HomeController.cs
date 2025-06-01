using System.Diagnostics;
using Jordana.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jordana.Controllers
{

    public class HomeController : Controller
    {
        JordanaContext _mydatabase;
        public HomeController(JordanaContext myjo)
        {
            _mydatabase = myjo; //activation for dependency injection 
        }
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
            var reviews = _mydatabase.Reviews.Include(x => x.User).OrderBy(c => c.ReviewId).ToList();
            return View(reviews);
           
        }
        public IActionResult AboutUs()
        { 
            return View();
        }
        public IActionResult ContactUs()
        {

            return View();
        }
        [HttpPost]
        public IActionResult ContactUs(string name, string email, string subject,string message)
        {
            SupportMessage msg = new SupportMessage()
            {
                Name = name,
                Email = email,
                Subject = subject,
                Message = message
            };
            _mydatabase.Add(msg);
            _mydatabase.SaveChanges();
            return RedirectToAction("Index");



        }
        public IActionResult Services()
        { 
            return View();
        }
        public IActionResult Destination()
        {
            var destination = _mydatabase.TouristsSites.OrderBy(c => c.SiteName).ToList();
            return View(destination);
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
            var reviews = _mydatabase.Reviews.Include(x=>x.User).OrderBy(c => c.ReviewId).ToList();
            return View(reviews);
            //return RedirectToAction("Index");

        }
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchDestination(string keyword)
        {
            var destination = _mydatabase.TouristsSites.Where(d=>d.SiteName.Contains(keyword,StringComparison.OrdinalIgnoreCase)).OrderBy(c => c.SiteName).ToList();
            return View("Destination", destination);
        }

    }
}
