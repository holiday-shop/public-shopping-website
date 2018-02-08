using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetcore_city_info.Models;
using dotnetcore_city_info.Repository;
 
namespace dotnetcore_city_info.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICityGeoInformationRepository _cityGeoInformationRepository;

        public HomeController(ICityGeoInformationRepository cityGeoInformationRepository)
        {
            _cityGeoInformationRepository = cityGeoInformationRepository;
        }

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
                new City("London", "Greenwich", "Cloud-Rain", "8.788 million"), 
                new City("Paris", "CET", "Cloud-Lightning", "2.244 million"),
                new City("Moscow", "Europe/Moscow", "Cloud-Sun", "11.92 million"),
                new City("Munich", "Europe/Berlin", "Cloud-Rain", "1.43 million"),
                new City("Barcelona", "Europe/Madrid", "Sun", "3.166 million"),
                new City("Honolulu", "Pacific/Honolulu", "Sun", "274,658 thousand"),
                new City("Sydney", "Australia/Sydney", "Sun", "4.029 million" ),
                new City("Iceland", "UTC", "Cloud-Sun", "334,252 thousand")  
            };

            var cityGeoInfos = _cityGeoInformationRepository.GetCities();

            foreach (var city in cities)
            {
                city.CityGeoInformation = cityGeoInfos.FirstOrDefault(cgi => string.Equals(cgi.Name, city.Name, StringComparison.OrdinalIgnoreCase));
            }

            return Json(cities);
        } 
    }
}
