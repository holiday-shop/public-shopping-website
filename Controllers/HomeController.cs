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
                new City("London", "Greenwich", "Cloud-Rain"), 
                new City("Paris", "CET", "Cloud-Lightning"),
                new City("Moscow", "Europe/Moscow", "Cloud-Sun"),
                new City("Munich", "Europe/Berlin", "Cloud-Rain"),
                new City("Barcelona", "Europe/Madrid", "Sun"),
                new City("Honolulu", "Pacific/Honolulu", "Sun"),
                new City("Sydney", "Australia/Sydney", "Sun"),
                new City("Iceland", "UTC", "Cloud-Sun")  
            }; 
            
            return Json(cities);
        } 
    }
}
