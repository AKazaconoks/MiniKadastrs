using Microsoft.AspNetCore.Mvc;
using WebApp.Abstractions.Interfaces;
using MvcApiApplication.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Statistical()
        {
            return View();
        }
    }
}