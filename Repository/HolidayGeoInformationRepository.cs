using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcore_holiday_info.Models;
using dotnetcore_holiday_info.Extensions;

namespace dotnetcore_holiday_info.Repository
{
    public class HolidayGeoInformationRepository : DatabaseRepository, IHolidayGeoInformationRepository
    {
        public HolidayGeoInformationRepository(string connectionString) : base(connectionString)
        {
        }

        public IReadOnlyList<HolidayGeoInformation> GetCities()
        {
            var sqlQuery = @"
                select
                    id,
                    name,
                    country
                from holiday_metadata
                order by name";

            return Read(sqlQuery, null, System.Data.CommandType.Text, reader =>
            {
                var holidayGeoInfos = new List<HolidayGeoInformation>();

                while (reader.Read())
                {
                    var id = reader.GetValue<int>("id");
                    var name = reader.GetValue<string>("name");
                    var country = reader.GetValue<string>("country");

                    holidayGeoInfos.Add(new HolidayGeoInformation(id, name, country));
                }

                return holidayGeoInfos.AsReadOnly();
            });
        }
    }
}
