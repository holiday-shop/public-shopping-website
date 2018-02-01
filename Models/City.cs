using System;

namespace dotnetcore_city_info.Models
{
    public class City
    {
        public string Name { get; }
        public string Time { get; }

        public string PodName { get; }


        public City(string name, string tz) {
            this.Name = name; 
            this.Time = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, tz).ToString();

            this.PodName = System.Net.Dns.GetHostName();
        }

    }
}