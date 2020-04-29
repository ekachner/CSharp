using System;
namespace CrazyTimers
{
    public class Timer
    {
        int Hours;
        int Minutes;
        int Seconds;

        public Timer(int hours = 0, int minutes = 0, int seconds = 0)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }


        public virtual int GetHours()
        {
            Hours = Methods.VerifyNumber("Enter the number of hours: ", 0, 23);
            return Hours;
        }

        public int GetMinutes()
        {
            Minutes = Methods.VerifyNumber("Enter the number of minutes: ", 0, 59);
            return Minutes;
        }

        public int GetSeconds()
        {
            Seconds = Methods.VerifyNumber("Enter the number of seconds: ", 0, 59);
            return Seconds;
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
    }
}
