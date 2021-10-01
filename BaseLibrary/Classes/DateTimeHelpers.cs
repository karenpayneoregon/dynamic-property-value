using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Globalization.DateTimeFormatInfo;

namespace BaseLibrary.Classes
{
    public class DateTimeHelpers
    {
        /// <summary>
        /// Returns a string list of month names for the current culture
        /// </summary>
        /// <returns>
        /// List of month names for current culture
        /// </returns>
        public static List<string> MonthNames() => Enumerable.Range(1, 12).Select((index) => CurrentInfo.GetMonthName(index)).ToList();

	}
}
