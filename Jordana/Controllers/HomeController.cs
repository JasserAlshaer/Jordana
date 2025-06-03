using System.Diagnostics;
using Jordana.DTOs;
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
        [HttpPost]
        public IActionResult Login( string email, string password)
        {
            var user = _mydatabase.Users.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
            if (user == null)
            {
                return View();
            }



            HttpContext.Session.SetInt32("UserId", user.UserId);
            if (user.UserType == "Admin")
            {
                return RedirectToAction("Dashboard","Admin");
            }
           
            return RedirectToAction("Index");
        }
       
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(string fullname,string email,string password,string repassword,string phonenumber)
        {

            User customer = new User()
            {
                Username = fullname,
                Email = email,
                Password = password,
                PhoneNumber = phonenumber,
                ProfileImage = "",
                CreationDate = DateTime.Now,
                CreatedBy = "system",
                UserType = "User"
            };
           _mydatabase.Users.Add(customer);
            _mydatabase.SaveChanges();
            return RedirectToAction("Login");
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
            var categories = _mydatabase.TouristsSites.GroupBy(x => x.Region).Select(c => new CategoryDTO
            {
                Name = c.Key
            }).ToList();
            var destination = _mydatabase.TouristsSites.OrderBy(c => c.SiteName).ToList();
            return View(Tuple.Create(destination,categories));
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
        public IActionResult ManageBookingMembers()
        {
            var members=_mydatabase.BookingMembers.Where(d=>d.BookingId==1).Include(x=>x.Booking)
                .ThenInclude(y=>y.Site)
                .ToList();
            return View(members);
        }


    }
}
