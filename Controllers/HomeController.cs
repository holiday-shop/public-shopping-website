using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetcore_holiday_info.Models;
using dotnetcore_holiday_info.Repository;
 
namespace dotnetcore_holiday_info.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHolidayGeoInformationRepository _holidayGeoInformationRepository;

        public HomeController(IHolidayGeoInformationRepository holidayGeoInformationRepository)
        {
            _holidayGeoInformationRepository = holidayGeoInformationRepository;
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
            var cities = new List<Holiday>() {
                new Holiday("London", "Greenwich", "Cloud-Rain", "8.788 million"), 
                new Holiday("Paris", "CET", "Cloud-Lightning", "2.244 million"),
                new Holiday("Moscow", "Europe/Moscow", "Cloud-Sun", "11.92 million"),
                new Holiday("Munich", "Europe/Berlin", "Cloud-Rain", "1.43 million"),
                new Holiday("Barcelona", "Europe/Madrid", "Sun", "3.166 million"),
                new Holiday("Honolulu", "Pacific/Honolulu", "Sun", "274,658 thousand"),
                new Holiday("Sydney", "Australia/Sydney", "Sun", "4.029 million" ),
                new Holiday("Reykjavik", "UTC", "Cloud-Sun", "334,252 thousand")  
            };

            var holidayGeoInfos = _holidayGeoInformationRepository.GetCities();

            foreach (var holiday in cities)
            {
                holiday.HolidayGeoInformation = holidayGeoInfos.FirstOrDefault(cgi => string.Equals(cgi.Name, holiday.Name, StringComparison.OrdinalIgnoreCase));
            }

            return Json(cities);
        } 
    }
}
