using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetcore_city_info.Models;
 
namespace dotnetcore_city_info.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public JsonResult GetCities()
        {
            var cities = new List<City>() {
                new City("London", "Greenwich"), 
                new City("Paris", "CET"),
                new City("Moscow", "Europe/Moscow"),
                new City("Munich", "Europe/Berlin"),
                new City("Barcelona", "Europe/Madrid"),
                new City("Honolulu", "Pacific/Honolulu"),
                new City("Honolulu", "Pacific/Honolulu"),
                new City("Sydney", "Australia/Sydney"),
                new City("Iceland", "UTC")  
            }; 
            
            return Json(cities);
        } 
    }
}
