using System;
namespace CrazyTimers
{
    public class Prompts
    {
        public static void InitialQuery()
        {
            bool anotherQuery = true;
            do
            {
                int InitialQuery = Inputs.ReadNumber("Choose one of the following options: \n\n" +
                    "1. Input hours, minutes, and seconds --> receive total seconds \n\n" +
                    "2. Input seconds --> receive days, hours, minutes, and seconds \n\n" +
                    "3. Total seconds until event date  ", 1, 3);
                switch (InitialQuery)
                {
                    case 1:
                        TimeToSeconds();
                        break;
                    case 2:
                        SecondsToTime();
                        break;
                    case 3:
                        SecondsUntilEvent();
                        break;
                    default:
                        break;
                }

                int another = Inputs.ReadNumber("Would you like to pose another query? [0 = No, 1 = Yes]: ", 0, 1);
                if (another == 0)
                {
                    anotherQuery = false;
                }
                else
                {
                    Console.Clear();
                }
            } while (anotherQuery == true);

            Console.Clear();
            Console.WriteLine("Finished!");
        }
        public static void TimeToSeconds()
        {
            int hours = Inputs.ReadNumber("Enter the number of HOURS: ", 0, 23);
            int minutes = Inputs.ReadNumber("Enter the number of MINUTES: ", 0, 59);
            int seconds = Inputs.ReadNumber("Enter the number of SECONDS: ", 0, 59);

            int HSeconds = TimeConversions.HoursToSeconds(hours);
            int MSeconds = TimeConversions.MinutesToSeconds(minutes);
            int SSeconds = seconds;

            int totalSeconds = TimeConversions.AddAllSeconds(HSeconds, MSeconds, SSeconds);

            Console.WriteLine($"Total seconds: {totalSeconds}");
        }

        public static void SecondsToTime()
        {
            int seconds = Inputs.ReadNumber("Enter total number of seconds: ", 0, 999999999);
            TimeConversions.SecondsToTimeString(seconds);
        }

        public static void SecondsUntilEvent()
        {
            string eventName = Inputs.ReadString("What is the name of this event?: ");
            int year = Inputs.ReadNumber("Enter the event year: ", 2020, 9999);
            int month = Inputs.ReadNumber("Enter the event month: ", 0, 12);
            int day = Inputs.ReadNumber("Enter the event day: ", 0, 31);
            int hour = Inputs.ReadNumber("Enter the hour: ", 0, 12);
            int minute = Inputs.ReadNumber("Enter the minute: ", 0, 59);

            DateTime now = DateTime.Now;
            DateTime eventDate = new DateTime(year, month, day, hour, minute, 0);
            TimeSpan diff = eventDate - now;
            double seconds = Math.Floor(diff.TotalSeconds);

            Console.WriteLine($"Seconds until {eventName}: {seconds}");
        }
    }
}
