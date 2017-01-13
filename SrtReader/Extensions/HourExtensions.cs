using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SrtReader.Exceptions;

namespace SrtReader.Extensions
{
    public static class HourExtensions
    {
        /// <summary>
        /// Accepts a string "hour" previously splitted with GetDa or GetA
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="res"></param>
        /// <returns>A boolean that corresponds to a successful conversion</returns>
        private static bool TryConvertHour(this string hour, out DateTime? res)
        {
            // 00:00:41,458 --> 00:00:42,958
            if(hour.Split('-').Length > 0)
            {
                res = null;
                return false;
                //throw new FormatHourNotCorrectException("Format not handlable, you first have to retrieve the starting or ending hour.");
            }
            // 00:00:41,458 
            if (hour.Split(':').Length != 3)
            {
                res = null;
                return false;
                //throw new FormatHourNotCorrectException();
            }

            var hours = hour.Split(':');

            var h = Int32.Parse(hours[0]);
            var m = Int32.Parse(hours[1]);
            var s = Int32.Parse(hours[2].Split(',')[0]);
            var ms = Int32.Parse(hours[2].Split(',')[1]);

            res = new DateTime(0, 0, 0, h, m, s, ms);
            
            return true;
        }
    }
}
