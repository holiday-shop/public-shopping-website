using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_city_info.Models
{
    public class CityGeoInformation
    {
        public int Id { get; }
        public string Name { get; }
        public string Country { get; }
		public string PhotoUrl { get; }

        public CityGeoInformation(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
    }
}
