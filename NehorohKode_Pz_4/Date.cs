using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateOperations
{
    internal class Date
    {
        private DateTime _date;

        public Date(int day, int month, int year)
        {
            _date = new DateTime(year, month, day);
        }

        public int DaysDifference(Date other)
        {
            TimeSpan difference = _date - other._date;
            return Math.Abs((int)difference.TotalDays);
        }

        public Date AddDays(int days)
        {
            DateTime newDate = _date.AddDays(days);
            return new Date(newDate.Day, newDate.Month, newDate.Year);
        }

        public bool IsLeapYear()
        {
            return DateTime.IsLeapYear(_date.Year);
        }

        public void Display()
        {
            Console.WriteLine($"{_date:dd/MM/yyyy}");
        }
    }
}