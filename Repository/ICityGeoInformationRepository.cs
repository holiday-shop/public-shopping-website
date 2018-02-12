using dotnetcore_city_info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace dotnetcore_city_info.Repository
{
    public interface ICityGeoInformationRepository
    {
        IReadOnlyList<CityGeoInformation> GetCities();
    }
}
