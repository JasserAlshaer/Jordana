using Jordana.DTOs;
using Jordana.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Jordana.Controllers
{
    public class AdminController : Controller
    {



        JordanaContext _mydatabase; //holder
        public AdminController(JordanaContext mydatabase)
        {
            _mydatabase = mydatabase; //activation for dependacy injection 
        }
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
            var data = _mydatabase.TouristsSites.ToList();
            return View(data);
        }

        public IActionResult ManageBooking()
        {
            var data = _mydatabase.Bookings.Include(x => x.Site).Include(r => r.BookingMembers).
                Select(s => new Booking_View_Modele
                {
                    BookingId=s.BookingId,
                    SiteName = s.Site.SiteName,
                    StartDate = ((DateTime)s.BookingDate).ToShortDateString(),
                    Location = s.Site.City,
                    InvitedMembers = s.BookingMembers.Count.ToString(),
                    TotalPrice = s.Price.ToString(),IsAccpted=s.IsAccpted
                }).ToList();
            return View(data);
        }

        public IActionResult ManageBookingStatus(int Id , bool value)
        {
            var item = _mydatabase.Bookings.FirstOrDefault(x => x.BookingId== Id);
            item.IsAccpted = value;
            _mydatabase.Update(item);
            _mydatabase.SaveChanges();
            return RedirectToAction("ManageBooking");
        }
        public IActionResult GetBookingDetails()
        {
            return View();
        }

        public IActionResult ManageUsers()
        {
            var items = _mydatabase.Users.Where(c=>c.UserType== "User").Select(x => new UserViewModel
            {
                UserName = x.Username,
                JoinDate = ((DateTime)x.CreationDate).ToShortDateString(),
                Email=x.Email,
                Phone= x.PhoneNumber,
                Booking=_mydatabase.Bookings.Where(b=>b.UserId==x.UserId).Count()
            }).ToList();
            return View(items);
        }

        public IActionResult ManageRating()
        {
            var reviews = _mydatabase.Reviews.Include(x => x.User).OrderBy(c => c.ReviewId).ToList();
            return View(reviews);

        }
        //public IActionResult CreateReview(string ReviewID, DateTime CreationDate, DateTime UpdateDate,string UserId,int Site_ID, string CreatedBy, string Comment,string Rating,DateTime Review_Date)
        //{
        //    Review review = new Review()
        //    {
        //        ReviewID = ReviewID,
        //        CreationDate = CreationDate,
        //        CreatedBy = CreatedBy,
        //        UpdateDate = UpdateDate,
        //        UserId = User_ID,
        //        SiteId= Site_ID,
        //        Comment =Comment,
        //        Rating = Rating,
        //        ReviewDate= Review_Date,
        //        IsAccepted = null
        //    };
        //    _mydatabase.Add(review);
        //    _mydatabase.SaveChanges();
        ////    return RedirectToAction("ManageRating");
        //}
        public IActionResult IsAccepted(int ReviewId,bool value)
        {
            var item = _mydatabase.Reviews.FirstOrDefault(x => x.ReviewId == ReviewId);
            item.IsAccepted = value;
            _mydatabase.Update(item);
            _mydatabase.SaveChanges();
            return RedirectToAction("ManageRating");
        }



        public IActionResult Logout()
        {
            return RedirectToAction("Index","Home");
        }
        public IActionResult SupportMessage()

        {

            var items = _mydatabase.SupportMessages.ToList();
            return View(items);
        }
        public IActionResult DeleteSupportMessage(int Id)
        {
            var item = _mydatabase.SupportMessages.FirstOrDefault(x => x.Id == Id);
            _mydatabase.Remove(item);
            _mydatabase.SaveChanges();
            return RedirectToAction("SupportMessage");


        }


    }
}
