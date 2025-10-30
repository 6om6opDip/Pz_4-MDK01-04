using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateOperations
{
    internal static class DateCalculator
    {
        private static Dictionary<int, string> _daysOfWeek = new Dictionary<int, string>
        {
            {0, "Воскресенье"}, {1, "Понедельник"}, {2, "Вторник"}, {3, "Среда"},
            {4, "Четверг"}, {5, "Пятница"}, {6, "Суббота"}
        };

        public static string GetDayOfWeek(string dateString)
        {
            if (!DateValidator.IsValidDate(dateString)) return "Invalid Date";

            string[] parts = dateString.Split('/');
            var date = new DateTime(int.Parse(parts[2]), int.Parse(parts[1]), int.Parse(parts[0]));
            return _daysOfWeek[(int)date.DayOfWeek];
        }
    }
}