﻿using Jordana.DTOs;
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
            var data = new DashboardDTO
            {
                Booking = _mydatabase.Bookings.Count() + _mydatabase.BookingMembers.Count(),
                Revenue = _mydatabase.Bookings.Sum(x => x.Price),
                Orders = _mydatabase.Bookings.Count(),
                Users = _mydatabase.Users.Count()
            };
            var data2 = _mydatabase.Bookings.Include(x => x.Site).Include(r => r.BookingMembers).
               Select(s => new Booking_View_Modele
               {
                   BookingId = s.BookingId,
                   SiteName = s.Site.SiteName,
                   StartDate = ((DateTime)s.BookingDate).ToShortDateString(),
                   Location = s.Site.City,
                   InvitedMembers = s.BookingMembers.Count.ToString(),
                   TotalPrice = s.Price.ToString(),
                   IsAccpted = s.IsAccpted

               }).ToList().OrderByDescending(x => x.StartDate).Take(5).ToList();
            var bookingsByCity = _mydatabase.Bookings
              .Include(b => b.Site)
              .GroupBy(b => b.Site.City)
              .Select(group => new ChartDTO
              {
                  City = group.Key,
                  Count = group.Count()
              })
              .OrderByDescending(x => x.Count)
              .ToList();
            ViewBag.ChartLabels = bookingsByCity.Select(x => x.City).ToList();
            ViewBag.ChartData = bookingsByCity.Select(x => x.Count).ToList();

            return View(Tuple.Create(data, data2, bookingsByCity));
        }

        public IActionResult Profile()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null)
            {
                var profile = _mydatabase.Users.FirstOrDefault(x => x.UserId == userId);
                return View(profile);
            }
            return NotFound();

        }

        [HttpPost]
        public IActionResult UpdatePasswordAdmin(int UserId , string Pass , string nPass)
        {
            if (UserId != null)
            {
                var profile = _mydatabase.Users.FirstOrDefault(x => x.UserId == UserId);
                if(profile != null)
                {
                    if (Pass.Equals(nPass))
                    {
                        profile.Password = nPass;
                        _mydatabase.Update(profile);
                        _mydatabase.SaveChanges();
                    }
                }
                return RedirectToAction("Profile");
            }
            return RedirectToAction("Index","Home");
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
        public IActionResult DisableSitd(int SiteId, int s)
        {
            var Site = _mydatabase.TouristsSites.Where(c => c.SiteId == SiteId).FirstOrDefault();
            if (Site != null && s == 1)
            {
                Site.IsActive = false;
            }
            else

            {
                Site.IsActive = true;
            }
            _mydatabase.Update(Site);
            _mydatabase.SaveChanges();

            return RedirectToAction("ManageDestinations");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || _mydatabase.TouristsSites == null)
            {
                return NotFound();
            }

            var touristsSite = _mydatabase.TouristsSites.Find(id);
            if (touristsSite == null)
            {
                return NotFound();
            }
            return View(touristsSite);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(int SiteId, string SiteName, string SiteDescription, string City, string Region, string SiteLocation, string Lat, string Long, string EntryFee, string OpeningHours)
        {
            if (SiteId == 0)
            {
                return NotFound();
            }
            var item = await _mydatabase.TouristsSites.Where(x => x.SiteId == SiteId).FirstOrDefaultAsync();
            if (item != null)
            {
                item.SiteName = SiteName;
                item.SiteDescription = SiteDescription;
                item.City = City;
                item.Region = Region;
                item.SiteLocation = SiteLocation;
                item.Lat = Convert.ToDouble(Lat);
                item.Long = Convert.ToDouble(Long);
                item.EntryFee = EntryFee;
                item.OpeningHours = OpeningHours;

                _mydatabase.TouristsSites.Update(item);
                _mydatabase.SaveChanges();
            }

            return RedirectToAction("ManageDestinations");

        }
        private bool TouristsSiteExists(int id)
        {
            return (_mydatabase.TouristsSites?.Any(e => e.SiteId == id)).GetValueOrDefault();
        }
        public IActionResult ManageBookingStatus(int Id, bool value)
        {
            var item = _mydatabase.Bookings.FirstOrDefault(x => x.BookingId == Id);
            item.IsAccpted = value;
            _mydatabase.Update(item);
            _mydatabase.SaveChanges();
            return RedirectToAction("ManageBooking");
        }
        public IActionResult GetBookingDetails(int Id)
        {
            var data = _mydatabase.Bookings.Where(x => x.BookingId == Id)
                .Include(u => u.User)
                .Include(x => x.Site).Include(r => r.BookingMembers)
                .FirstOrDefault();

            return View(data);
        }

        public IActionResult ManageUsers()
        {
            var items = _mydatabase.Users.Where(c => c.UserType == "User").Select(x => new UserViewModel
            {
                UserName = x.Username,
                JoinDate = ((DateTime)x.CreationDate).ToShortDateString(),
                Email = x.Email,
                Phone = x.PhoneNumber,
                Booking = _mydatabase.Bookings.Where(b => b.UserId == x.UserId).Count()
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
        public IActionResult IsAccepted(int ReviewId, bool value)
        {
            var item = _mydatabase.Reviews.FirstOrDefault(x => x.ReviewId == ReviewId);
            item.IsAccepted = value;
            _mydatabase.Update(item);
            _mydatabase.SaveChanges();
            return RedirectToAction("ManageRating");
        }



        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
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
