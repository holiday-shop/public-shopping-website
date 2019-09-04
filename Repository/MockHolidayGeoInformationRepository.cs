using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_holiday_info.Models;

namespace dotnetcore_holiday_info.Repository
{
    public class MockHolidayGeoInformationRepository : IHolidayGeoInformationRepository
    {
        public MockHolidayGeoInformationRepository(string connectionString)
        {
            Console.WriteLine($"Connection string to mock: {connectionString}");
        }

        public IReadOnlyList<HolidayGeoInformation> GetHolidays()
        {
            /*
             * new Holiday("London", "Greenwich", "Cloud-Rain", "8.788 million"), 
                new Holiday("Paris", "CET", "Cloud-Lightning", "2.244 million"),
                new Holiday("Moscow", "Europe/Moscow", "Cloud-Sun", "11.92 million"),
                new Holiday("Munich", "Europe/Berlin", "Cloud-Rain", "1.43 million"),
                new Holiday("Barcelona", "Europe/Madrid", "Sun", "3.166 million"),
                new Holiday("Honolulu", "Pacific/Honolulu", "Sun", "274,658 thousand"),
                new Holiday("Sydney", "Australia/Sydney", "Sun", "4.029 million" ),
                new Holiday("Reykjavik", "UTC", "Cloud-Sun", "334,252 thousand")  
             */

            return new List<HolidayGeoInformation>() {
                new HolidayGeoInformation(1, "London", "UK"),
                new HolidayGeoInformation(2, "Paris", "France"),
                new HolidayGeoInformation(3, "Moscow", "Russia"),
                new HolidayGeoInformation(4, "Sydney", "Australia")
            }.AsReadOnly();
        }
    }
}
