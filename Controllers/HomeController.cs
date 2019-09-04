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
        public JsonResult GetHolidays()
        {
            var cities = new List<Holiday>() {
                new Holiday("See the city sights of London", "Greenwich", "Cloud-Rain", "Yes", 299), 
                new Holiday("Romantic Break for Two In Paris", "CET", "Cloud-Lightning", "No!", 399),
                new Holiday("Beach break in the The Bahamas", "EDT", "Sun", "No", 1500),
                new Holiday("Octoberfest in Munich", "Europe/Berlin", "Cloud-Rain", "No!", 399),
                new Holiday("Austrailian Adventure", "Australia/Sydney", "Sun", "Yes", 2500),
                new Holiday("The northern lights in Iceland", "UTC", "Cloud-Sun", "Yes", 1300)  
            };

            var holidayGeoInfos = _holidayGeoInformationRepository.GetHolidays();

            foreach (var holiday in cities)
            {
                holiday.HolidayGeoInformation = holidayGeoInfos.FirstOrDefault(cgi => string.Equals(cgi.Name, holiday.Name, StringComparison.OrdinalIgnoreCase));
            }

            return Json(cities);
        } 
    }
}
