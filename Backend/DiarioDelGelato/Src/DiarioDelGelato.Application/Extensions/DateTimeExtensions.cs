using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Extensions
{
    //Database will store an INTEGER for datetime as Unix Time, the number of seconds since 1970-01-01 00:00:00 UTC.
    public static class DateTimeExtensions 
    {
        // gets a UNIX timestamp and returns a DateTime
        public static DateTime FromUnixTimestampUtc(this DateTime dateTime, long unixTimestamp) => DateTimeOffset.FromUnixTimeSeconds(unixTimestamp).UtcDateTime;

        // get current UTC time and returns an UNIX timestamp
        public static long ToUnixTimestampUtcNow(this DateTime dateTime) => DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        // create an unix timestamp representing the time only (not attached to specific date)
        public static long TimeToUnixTimestampUtc(this DateTime datetime, int hour24, int minute)
        {
            DateTime time = new DateTime(1970, 1, 1, hour24, minute, 0, DateTimeKind.Utc);
            DateTimeOffset timeOffset = new DateTimeOffset(time);
            return timeOffset.ToUnixTimeSeconds(); // Represents hour:minute UTC on the Unix epoch date
        }

    }
}
