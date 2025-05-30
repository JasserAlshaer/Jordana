﻿using System.Diagnostics;
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
            var reviews = _mydatabase.Reviews.Include(x=>x.User).OrderBy(c => c.ReviewId).ToList();
            return View(reviews);
            //return RedirectToAction("Index");

        }
        public IActionResult Dashboard()
        {
            return View();
        }

    }
}
