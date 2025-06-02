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
            return View();
        }

        public IActionResult ManageRating()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Index","Home");
        }


    }
}
