using Jordana.DTOs;
using Jordana.Models;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        public IActionResult ManageBooking()
        {
            return View();
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
            return View();
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
