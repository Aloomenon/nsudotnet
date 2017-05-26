using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kovalev.Nsudotnet.Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a date");
            DateTime dateValue;

            if (DateTime.TryParse(Console.ReadLine(), out dateValue))
            {
                Calendar cal = new Calendar(dateValue);
                cal.GetCalendar();
            }
            else
            {
                Console.WriteLine("Something goes wrong");
                Console.ReadKey();
                return;
            }

            Console.ReadKey();
        }
    }

    class Calendar
    {
        private DateTime _date;
        public Calendar(DateTime date)
        {
            _date = date;
        }

        public void GetCalendar()
        {
            DateTime date = new DateTime(_date.Year, _date.Month, 1);
            int workDaysCounter = 0;
            int count = (int)date.DayOfWeek;
            if (count == 0)
                count = 7;
            GetHeader();
            for (int i = 0; i < count - 1; i++)
            {
                Console.Write("\t");
            }
            while (date.Month == _date.Month)
            {
                Console.ForegroundColor = GetForegroundColor(date);
                Console.BackgroundColor = GetBackgroundColor(date);
               
                Console.Write("{0}\t", date.Day);
                if (date.DayOfWeek != DayOfWeek.Sunday)
                    workDaysCounter++;
                else
                {
                    Console.WriteLine();
                }
                
                date = date.AddDays(1);
            }
        }

        private ConsoleColor GetBackgroundColor(DateTime date)
        {
            if (date == DateTime.Now.Date)
            {
                return ConsoleColor.Blue;
            }

            if (date == _date.Date)
            {
                return ConsoleColor.Gray;
            }
            return ConsoleColor.Black;
        }

        private ConsoleColor GetForegroundColor(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return ConsoleColor.Red;
            }
            return ConsoleColor.White;
        }

        private void GetHeader()
        {
            int dayOfWeek = 1;
            var headerDate = _date.AddDays(1 - (int)_date.DayOfWeek);
            Console.WriteLine("{0:MMMM}",_date);
            for (int i = 0; i < 7; i++)
            {
                Console.Write("{0:ddd}\t",headerDate);
                headerDate = headerDate.AddDays(1);
            }
            Console.WriteLine();
        }
    }
}
