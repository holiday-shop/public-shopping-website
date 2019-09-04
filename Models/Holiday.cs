using System;

namespace dotnetcore_holiday_info.Models
{
    public class Holiday
    {
        public string Name { get; }
        public string Time { get; }

        public string PodName { get; }

        public string Weather { get; }
 
        public string FamilyFriendly { get; }

        public HolidayGeoInformation HolidayGeoInformation { get; set; }

        public Holiday(string name, string tz, string weatherIcon, string familyFriendly) {
            this.Name = name;
            try
            {
                this.Time = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, tz).ToString("HH:mm:ss");
            } catch (Exception)
            {
                this.Time = "+????";
            }

            this.Weather = ""; // Don't set the weather on this branch.

            if (Environment.GetEnvironmentVariable("SHOW_FAMILY") == "YES") {
                this.FamilyFriendly = familyFriendly;
            } else {
                this.FamilyFriendly = "";
            }

            this.PodName = System.Net.Dns.GetHostName();
        }

    }
}
