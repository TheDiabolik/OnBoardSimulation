using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoard
{
    public static partial class DateTimeExtensions
    {
        public static UInt64 GetAllMiliSeconds(this DateTime dt)
        {
            UInt64 result = Convert.ToUInt64((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond));

            return result;
        }

        public static UInt64 GetAllMiliSeconds()
        {
            UInt64 result = Convert.ToUInt64((DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond));

            return result;
        }
        public static DateTime SetAllMiliSeconds(this DateTime dt, UInt64 ticks)
        {
            dt = new DateTime((long)ticks * 10000);

            return dt;
        }

        public static DateTime SetAllMiliSeconds(UInt64 ticks)
        {
            DateTime dt = new DateTime((long)ticks * 10000);

            return dt;
        }
    }
}
