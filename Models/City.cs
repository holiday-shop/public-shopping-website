using System;

namespace dotnetcore_city_info.Models
{
    public class City
    {
        public string Name { get; }
        public string Time { get; }

        public string PodName { get; }

        public string Weather { get; }
 
        public string Population { get; }

        public CityGeoInformation CityGeoInformation { get; set; }

        public City(string name, string tz, string weatherIcon, string population) {
            this.Name = name;
            try
            {
                this.Time = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, tz).ToString();
            } catch (Exception)
            {
                this.Time = "+????";
            }

            this.Weather = weatherIcon;

            if (Environment.GetEnvironmentVariable("SHOW_POPULATION") == "YES") {
                this.Population = population;
            } else {
                this.Population = "";
            }

            this.PodName = System.Net.Dns.GetHostName();
        }

    }
}