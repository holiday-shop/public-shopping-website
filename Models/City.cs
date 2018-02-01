using System;

namespace dotnetcore_city_info.Models
{
    public class City
    {
        public string Name { get; }
        public string Time { get; }

        public City(string name, string time) {
            this.Name = name;
            this.Time = time;
        }
    }
}