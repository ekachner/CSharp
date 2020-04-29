using System;
namespace CrazyTimers
{
    public class DayTimer : Timer
    {
        int Minutes;
        int Hours;
        int Day;
        int Month;
        int Year;

        public override int GetHours()
        {
            Hours = Methods.VerifyNumber("Enter the hour: ", 0, 23);
            return Hours;
        }

        public int GetDay()
        {
            Day = Methods.VerifyNumber("Enter the day: ", 1, 31);
            return Day;
        }

        public int GetMonth()
        {
            Month = Methods.VerifyNumber("Enter the month: ", 1, 12);
            return Month;
        }

        public int GetYear()
        {
            Year = Methods.VerifyNumber("Enter the year: ", 2020, 2500);
            return Year;
        }

        public void GetDate()
        {
            Minutes = GetMinutes();
            GetHours();
            GetDay();
            GetMonth();
            GetYear();
            while (Day > DateTime.DaysInMonth(Year, Month))
            {
                Console.WriteLine($"Please select day between 1 and {DateTime.DaysInMonth(Year, Month)}.");
                GetDay();
            }
        }

        public void SecondsTill()
        {
            GetDate();
            DateTime date1 = DateTime.Now;
            DateTime date2 = new DateTime(year: Year, month: Month, day: Day, hour: Hours, minute: Minutes, second: 0);
            while (date2 < DateTime.Now)
            {
                Console.WriteLine("You must enter a future date");
                GetDate();
                date2 = new DateTime(year: Year, month: Month, day: Day, hour: Hours, minute: Minutes, second: 0);
            }

            TimeSpan interval = date2 - date1;
            Console.WriteLine($"The total number of seconds is: {interval.TotalSeconds:N0}");
        }
    }
}
