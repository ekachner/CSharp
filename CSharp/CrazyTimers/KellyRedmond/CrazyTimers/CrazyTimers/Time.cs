using System;
namespace CrazyTimers
{
    public class Time
    {
        static int Hours;
        static int Minutes;
        static int Seconds;
        static int Day;
        static int Month;
        static int Year;

        public Time(int hours = 0, int minutes = 0, int seconds = 0)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }


        public static int GetHours()
        {
            Hours = Methods.VerifyNumber("Enter the number of hours: ", 0, 23);
            return Hours;
        }

        public static int GetMinutes()
        {
            Minutes = Methods.VerifyNumber("Enter the number of minutes: ", 0, 59);
            return Minutes;
        }

        public static int GetSeconds()
        {
            Seconds = Methods.VerifyNumber("Enter the number of seconds: ", 0, 59);
            return Seconds;
        }

        public static int GetHour()
        {
            Hours = Methods.VerifyNumber("Enter the hour: ", 0, 23);
            return Hours;
        }

        public static int GetDay()
        {
            Day = Methods.VerifyNumber("Enter the day: ", 1, 31);
            return Day;
        }

        public static int GetMonth()
        {
            Month = Methods.VerifyNumber("Enter the month: ", 1, 12);
            return Month;
        }

        public static int GetYear()
        {
            Year = Methods.VerifyNumber("Enter the year: ", 2020, 2500);
            return Year;
        }

        public void CalculateSeconds()
        {
            Minutes = (Hours * 60) + Minutes;
            Seconds = (Minutes * 60) + Seconds;

            Console.WriteLine($"The total number of seconds is: {Seconds:N0}");
        }

        public void CalculateRegTime()
        {
            Seconds = Methods.VerifyNumber("Enter the number of seconds: ", 0, 86399);
            Hours = Seconds / 3600;
            Seconds -= (Hours * 3600);
            Minutes = Seconds / 60;
            Seconds -= (Minutes * 60);

            Console.WriteLine("This is equal to {0} hours, {1} minutes and {2} seconds", Hours, Minutes, Seconds);
        }

        public void GetDate()
        {
            GetHour();
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
            DateTime date2 = new DateTime(year: Year, month: Month, day: Day, hour: Hours, minute: 0, second: 0);
            while (date2 < DateTime.Now)
            {
                Console.WriteLine("You must enter a future date");
                GetDate();
                date2 = new DateTime(year: Year, month: Month, day: Day, hour: Hours, minute: 0, second: 0);
            }

            TimeSpan interval = date2 - date1;
            Console.WriteLine($"The total number of seconds is: {interval.TotalSeconds:N0}");

        }
    }
}
