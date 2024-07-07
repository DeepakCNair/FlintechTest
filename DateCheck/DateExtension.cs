using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateCheck
{
    internal static class DateExtension
    {
        public static DateTime GetClosest(this DateTime dateTime, DateTime[] dates)
        {
            long min = long.MaxValue;

            DateTime closestDate = DateTime.Now;

            foreach (DateTime date in dates)
            {
                var calc = Math.Abs(date.Ticks - dateTime.Ticks);
                if (calc < min)
                {
                    min = calc;
                    closestDate = date;
                }
            }

            return closestDate;
        }
    }
}
