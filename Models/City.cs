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

        public City(string name, string tz, string weatherIcon, string population) {
            this.Name = name; 
            this.Time = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, tz).ToString();
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