using dotnetcore_holiday_info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace dotnetcore_holiday_info.Repository
{
    public interface IHolidayGeoInformationRepository
    {
        IReadOnlyList<HolidayGeoInformation> GetHolidays();
    }
}
