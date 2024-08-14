using System.Diagnostics;
using KnowledgeHubPortal.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.WebApp.Controllers
{
    public class HomeController : Controller
    {
      
        //domain/
        public IActionResult Index()
        {
            return View();
        }

        //domain/home/privacy
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Hello()
        {
            return View();
        }

    }
}
