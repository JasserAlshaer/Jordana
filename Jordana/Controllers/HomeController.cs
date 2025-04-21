using System.Diagnostics;
using Jordana.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jordana.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {



            return View();
        }
    }
}
