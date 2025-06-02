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
            //var test = _mydatabase.Bookings.Where(x => x.BookingId == 1)
                
            //    .Include(x => x.User)
            //    .Include(m => m.BookingMembers)
            //    .Include(s => s.Site).ThenInclude(p => p.SiteMedia)
            //    .FirstOrDefault();

            var test = _mydatabase.TouristsSites.Where(x=>x.SiteId ==22)
                .Include(x => x.SiteMedia)
                .FirstOrDefault();
            return View(test);
        }
        [HttpPost]
        public IActionResult Booking(int userid)
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
