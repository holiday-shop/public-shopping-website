using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_city_info.Models;

namespace dotnetcore_city_info.Repository
{
    public class MockCityGeoInformationRepository : ICityGeoInformationRepository
    {
        public MockCityGeoInformationRepository(string connectionString)
        {
            Console.WriteLine($"Connection string to mock: {connectionString}");
        }

        public IReadOnlyList<CityGeoInformation> GetCities()
        {
            /*
             * new City("London", "Greenwich", "Cloud-Rain", "8.788 million"), 
                new City("Paris", "CET", "Cloud-Lightning", "2.244 million"),
                new City("Moscow", "Europe/Moscow", "Cloud-Sun", "11.92 million"),
                new City("Munich", "Europe/Berlin", "Cloud-Rain", "1.43 million"),
                new City("Barcelona", "Europe/Madrid", "Sun", "3.166 million"),
                new City("Honolulu", "Pacific/Honolulu", "Sun", "274,658 thousand"),
                new City("Sydney", "Australia/Sydney", "Sun", "4.029 million" ),
                new City("Iceland", "UTC", "Cloud-Sun", "334,252 thousand")  
             */

            return new List<CityGeoInformation>() {
                new CityGeoInformation(1, "London", "UK"),
                new CityGeoInformation(2, "Paris", "France"),
                new CityGeoInformation(3, "Moscow", "Russia"),
                new CityGeoInformation(4, "Sydney", "Australia")
            }.AsReadOnly();
        }
    }
}
