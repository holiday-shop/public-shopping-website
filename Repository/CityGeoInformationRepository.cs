using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_city_info.Models;
using dotnetcore_city_info.Extensions;

namespace dotnetcore_city_info.Repository
{
    public class CityGeoInformationRepository : DatabaseRepository, ICityGeoInformationRepository
    {
        public CityGeoInformationRepository(string connectionString) : base(connectionString)
        {
        }

        public IReadOnlyList<CityGeoInformation> GetCities()
        {
            var sqlQuery = @"
                select
                    id,
                    name,
                    country
                from city_metadata
                order by name";

            return Read(sqlQuery, null, System.Data.CommandType.Text, reader =>
            {
                var cityGeoInfos = new List<CityGeoInformation>();

                while (reader.Read())
                {
                    var id = reader.GetValue<int>("id");
                    var name = reader.GetValue<string>("name");
                    var country = reader.GetValue<string>("country");

                    cityGeoInfos.Add(new CityGeoInformation(id, name, country));
                }

                return cityGeoInfos.AsReadOnly();
            });
        }
    }
}
