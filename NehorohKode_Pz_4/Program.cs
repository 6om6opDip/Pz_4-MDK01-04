using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;

namespace DateOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================");

            // Первая часть: проверка даты и вывод дня недели
            ProcessSingleDate();

            // Вторая часть: операции с двумя датами
            ProcessDateOperations();

            Console.WriteLine("\n============================");
        }

        private static void ProcessSingleDate()
        {
            Console.Write("\nВведите дату (ДД/MM/ГГГГ): ");
            string input = Console.ReadLine();

            if (DateValidator.IsValidDate(input))
            {
                string convertedDate = DateConverter.ConvertDateFormat(input);
                string dayOfWeek = DateCalculator.GetDayOfWeek(input);

                Console.WriteLine($"US формат: {convertedDate}");
                Console.WriteLine($"День недели: {dayOfWeek}");
            }
            else
            {
                Console.WriteLine("Invalid date");
            }
        }

        private static void ProcessDateOperations()
        {
            Console.Write("\nВведите дату для добавки дней в формате (DD MM YYYY): ");
            var parts1 = Console.ReadLine().Split(' ');

            if (parts1.Length == 3 &&
                int.TryParse(parts1[0], out int day1) &&
                int.TryParse(parts1[1], out int month1) &&
                int.TryParse(parts1[2], out int year1) &&
                DateValidator.IsValidDate($"{day1}/{month1}/{year1}"))
            {
                Date date1 = new Date(day1, month1, year1);

                ProcessAddDaysOperation(date1);
                ProcessSecondDateOperation(date1);
            }
            else
            {
                Console.WriteLine("Error: Invalid first date!");
            }
        }

        private static void ProcessAddDaysOperation(Date date1)
        {
            Console.Write($"Сколько дней добавить к ней?  ");
            if (int.TryParse(Console.ReadLine(), out int daysToAdd))
            {
                Date newDate = date1.AddDays(daysToAdd);
                Console.Write("Новая дата: ");
                newDate.Display();
            }
            else
            {
                Console.WriteLine("Error: Invalid number of days!");
            }
        }

        private static void ProcessSecondDateOperation(Date date1)
        {
            Console.Write("Введите вторую дату для подсчета количества дней между 1ой и второй датой в формате (ДД MM ГГГГ): ");
            var parts2 = Console.ReadLine().Split(' ');

            if (parts2.Length == 3 &&
                int.TryParse(parts2[0], out int day2) &&
                int.TryParse(parts2[1], out int month2) &&
                int.TryParse(parts2[2], out int year2) &&
                DateValidator.IsValidDate($"{day2}/{month2}/{year2}"))
            {
                Date date2 = new Date(day2, month2, year2);

                int daysDifference = date1.DaysDifference(date2);
                Console.WriteLine($"Дней между датами: {daysDifference} дн.");

                bool isLeapYear = date1.IsLeapYear();
                if (isLeapYear == true)
                {
                    Console.WriteLine($"Год високосный");
                }
                else
                {
                    Console.WriteLine($"Год НЕ високосный");
                }
            }
            else
            {
                Console.WriteLine("Error: Invalid second date!");
            }
        }
    }
}