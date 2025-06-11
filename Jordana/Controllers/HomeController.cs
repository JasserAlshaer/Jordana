using System.Diagnostics;
using Google.Protobuf.WellKnownTypes;
using Jordana.DTOs;
using Jordana.Models;
using Microsoft.AspNetCore.Localization;
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
        public IActionResult Login(string email, string password)
        {
            var user = _mydatabase.Users.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
            if (user == null)
            {
                return View();
            }



            HttpContext.Session.SetInt32("UserId", user.UserId);
            if (user.UserType == "Admin")
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(string fullname, string email, string password, string repassword, string phonenumber)
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

        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                ViewData["Profile"] = "Customer";
            }
            else
            {
                ViewData["Profile"] = "Guest";
            }
            var reviews = _mydatabase.Reviews.Include(x => x.User).OrderBy(c => c.ReviewId).ToList();
            var categories = _mydatabase.TouristsSites.GroupBy(x => x.Region).Select(c => new CategoryDTO
            {
                CategoryId = c.FirstOrDefault().CategoryId,
                Name = c.Key
            }).ToList();
            var destination = _mydatabase.TouristsSites.OrderBy(c => c.SiteName).ToList();
            return View(Tuple.Create(destination, categories, reviews));
        }
        public IActionResult AboutUs()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                ViewData["Profile"] = "Customer";
            }
            else
            {
                ViewData["Profile"] = "Guest";
            }
            return View();
        }
        public IActionResult ContactUs()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                ViewData["Profile"] = "Customer";
            }
            else
            {
                ViewData["Profile"] = "Guest";
            }
            return View();
        }
        [HttpPost]
        public IActionResult ContactUs(string name, string email, string subject, string message)
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
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                ViewData["Profile"] = "Customer";
            }
            else
            {
                ViewData["Profile"] = "Guest";
            }
            return View();
        }
        public IActionResult Destination()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                ViewData["Profile"] = "Customer";
            }
            else
            {
                ViewData["Profile"] = "Guest";
            }
            var categories = _mydatabase.TouristsSites.GroupBy(x => x.Region).Select(c => new CategoryDTO
            {
                CategoryId = c.FirstOrDefault().CategoryId,
                Name = c.Key
            }).ToList();
            var destination = _mydatabase.TouristsSites.OrderBy(c => c.SiteName).ToList();
            return View(Tuple.Create(destination, categories));
        }
        public IActionResult Booking(int Id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                ViewData["Profile"] = "Customer";
            }
            else
            {
                ViewData["Profile"] = "Guest";
            }
            //var test = _mydatabase.Bookings.Where(x => x.BookingId == 1)

            //    .Include(x => x.User)
            //    .Include(m => m.BookingMembers)
            //    .Include(s => s.Site).ThenInclude(p => p.SiteMedia)
            //    .FirstOrDefault();

            var test = _mydatabase.TouristsSites.Where(x => x.SiteId == Id)
                .Include(x => x.SiteMedia)
                .FirstOrDefault();
            return View(test);
        }
        [HttpPost]
        public IActionResult Booking(int siteId, DateTime bookingDate, DateTime bookingEndDate, string transporation,
            string SpecialRequest)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            int price = 0;
            if (transporation == "car")
                price += 20;
            if (transporation == "bus")
                price += 50;
            Booking reservaition = new Booking()
            {
                BookingDate = bookingDate,
                BookingEndDate = bookingEndDate,
                BookingStatus = "UnComplete",
                SpecialRequest = SpecialRequest,
                CreatedBy = "Client",
                CreationDate = DateTime.Now,
                IsAccpted = null,
                SiteId = siteId,
                Price = price,
                Transportation = transporation,
                UserId = (int)userId

            };
            _mydatabase.Add(reservaition);
            _mydatabase.SaveChanges();
            return RedirectToAction("ManageBookingMembers", new { Id = reservaition.BookingId });
        }
        public IActionResult OurGuides()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                ViewData["Profile"] = "Customer";
            }
            else
            {
                ViewData["Profile"] = "Guest";
            }
            return View();
        }
        public IActionResult Testimonial()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                ViewData["Profile"] = "Customer";
            }
            else
            {
                ViewData["Profile"] = "Guest";
            }
            var reviews = _mydatabase.Reviews.Include(x => x.User).OrderBy(c => c.ReviewId).ToList();
            return View(reviews);
            //return RedirectToAction("Index");

        }
        public IActionResult Dashboard()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                ViewData["Profile"] = "Customer";
            }
            else
            {
                ViewData["Profile"] = "Guest";
            }
            return View();
        }
        [HttpPost]
        public IActionResult SearchDestination(string keyword)
        {
            var destination = _mydatabase.TouristsSites.Where(d => d.SiteName.Contains(keyword, StringComparison.OrdinalIgnoreCase)).OrderBy(c => c.SiteName).ToList();
            return View("Destination", destination);
        }
        public IActionResult ManageBookingMembers(int Id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                ViewData["Profile"] = "Customer";
            }
            else
            {
                ViewData["Profile"] = "Guest";
            }
            var members = _mydatabase.BookingMembers.Where(d => d.BookingId == Id).Include(x => x.Booking)
                .ThenInclude(y => y.Site)
                .ToList();
            ViewBag.Id = Id;
            return View(members);
        }
        [HttpPost]
        public IActionResult AddBookingMember(int bookingId, string name, string phone, int age, string gender,
            string referenceName, string referencePhone, string Relationship, string nationalId, bool isJordanian)
        {
            BookingMember bookingMember = new BookingMember()
            {
                BookingId = bookingId,
                Age = age,
                CreatedBy = "System",
                CreationDate = DateTime.Now,
                Gender = gender,
                Name = name,
                NationalId = isJordanian ? nationalId : "",
                PassportNumber = !isJordanian ? nationalId : "",
                PhoneNumber = phone,
                ReferenceName = referenceName,
                ReferencePhoneNumber = referencePhone,
                Relationship = Relationship
            };
            _mydatabase.BookingMembers.Add(bookingMember);
            _mydatabase.SaveChanges();
            if (bookingMember.MemId != 0)
            {
                var item = _mydatabase.Bookings.Where(x => x.BookingId == bookingId)
                    .Include(u => u.Site).FirstOrDefault();
                if (item != null)
                {
                    if (item.Site.EntryFee != "Free")
                        item.Price += item.Price + Convert.ToInt32(item.Site.EntryFee);
                    _mydatabase.Update(item);
                    _mydatabase.SaveChanges();
                }
            }
            return RedirectToAction("ManageBookingMembers", new { Id = bookingId });
        }
        public IActionResult MyReserviations()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId.HasValue)
            {
                ViewData["Profile"] = "Customer";
            }
            else
            {
                ViewData["Profile"] = "Guest";
            }
           
            var data = _mydatabase.Bookings
                .Where(z=>z.UserId == (int)userId) 
                .Include(x => x.Site).Include(r => r.BookingMembers).
                 Select(s => new Booking_View_Modele
                 {
                     BookingId = s.BookingId,
                     SiteName = s.Site.SiteName,
                     StartDate = ((DateTime)s.BookingDate).ToShortDateString(),
                     Location = s.Site.City,
                     InvitedMembers = s.BookingMembers.Count.ToString(),
                     TotalPrice = s.Price.ToString(),
                     IsAccpted = s.IsAccpted
                 }).ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult Checkout(int bookingId, string visa, string cvv,string cardHolder)
        {
            var item = _mydatabase.Bookings.FirstOrDefault(x => x.BookingId == bookingId);
            if (item != null)
            {
                if (item.Price != 0)
                {
                    var payment = _mydatabase.PaymentCards.Where(x => x.Visa == visa
                    && x.Balance > item.Price && x.Cvv2 == cvv).FirstOrDefault();
                    if (payment!=null)
                    {
                        payment.Balance -= item.Price;
                        _mydatabase.Update(payment);
                        _mydatabase.SaveChanges();

                        item.UpdateDate = DateTime.Now;
                        item.UpdatedBy = "Payment";
                        item.BookingStatus = "Paied and Confirmed";

                        _mydatabase.Update(item);
                        _mydatabase.SaveChanges();
                    }
                }
                    
                
            }
            return RedirectToAction("MyReserviations");
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}
