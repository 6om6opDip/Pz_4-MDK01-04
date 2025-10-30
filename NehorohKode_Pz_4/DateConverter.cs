using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateOperations
{
    internal static class DateConverter
    {
        public static string ConvertDateFormat(string date)
        {
            string[] parts = date.Split('/');
            return parts.Length == 3 ? $"{parts[1]}/{parts[0]}/{parts[2]}" : date;
        }
    }
}