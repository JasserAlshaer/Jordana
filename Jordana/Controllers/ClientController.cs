using Jordana.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jordana.Controllers
{
    public class ClientController : Controller
    {
        JordanaContext _mydatabase; //holder
        public ClientController(JordanaContext mydatabase)
        {
            _mydatabase = mydatabase; //activation for dependacy injection 
        }
        public IActionResult Booking()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }
        public IActionResult History()
        {
            return View();
        }
        public IActionResult Rate()
        {
            return View();
        }
    }
}
