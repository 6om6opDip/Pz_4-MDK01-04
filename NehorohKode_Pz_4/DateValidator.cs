using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateOperations
{
    internal static class DateValidator
    {
        public static bool IsValidDate(string dateString)
        {
            if (string.IsNullOrWhiteSpace(dateString)) return false;

            string[] parts = dateString.Split('/');
            if (parts.Length != 3) return false;

            if (!int.TryParse(parts[0], out int day) ||
                !int.TryParse(parts[1], out int month) ||
                !int.TryParse(parts[2], out int year)) return false;

            if (year < 1 || year > 9999) return false;
            if (month < 1 || month > 12) return false;

            int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int maxDays = daysInMonth[month - 1];

            if (month == 2 && ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)))
                maxDays = 29;

            return day >= 1 && day <= maxDays;
        }
    }
}