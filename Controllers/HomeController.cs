using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessClientSystem.Models;
using Microsoft.AspNetCore.Http;

namespace BusinessClientSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

 public IActionResult About()
        {
            // check whether user has a valid session or not. if not we wanna restrict the user from about page
               //  var user = HttpContext.Session.GetString("user");
                // if(user == null)
                // {
                // return Redirect("/auth/login");
                // }
                // else
                // {
                // ViewData["Message"] = "Your application description page.";
                // return View();
                // }
            return View();
        }

        

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
