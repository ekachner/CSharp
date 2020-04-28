using System;

namespace CrazyTimers
{
    public class TimeConversions
    {
        public static int HoursToSeconds(int hours)
        {
            int minutes = hours * 60;
            int seconds = MinutesToSeconds(minutes);
            return seconds;
        }

        public static int MinutesToSeconds(int minutes)
        {
            int seconds = minutes * 60;
            return seconds;
        }

        public static int AddAllSeconds(int Hseconds, int Mseconds, int Sseconds)
        {
            int totalSeconds = Hseconds + Mseconds + Sseconds;
            return totalSeconds;
        }

        public static void SecondsToTimeString(int seconds)
        {
            int days = seconds / (24 * 3600);

            seconds %= 24 * 3600;
            int hours = seconds / 3600;

            seconds %= 3600;
            int minutes = seconds / 60;

            seconds %= 60;

            Console.WriteLine($"This is equal to {days} days, {hours} hours, {minutes} minutes, and {seconds} seconds.");
        }
    }
}
