using System;

namespace CrazyTimers
{
    class Program
    {
        

        static void Main(string[] args)
        {
            SecondsTillEvent();
            SecondsToHours();
            HoursToSeconds();
        }

        

        static void SecondsTillEvent()
        {
            string eventName = ReadString("What's the name of your event: ");
            int year = ReadInteger("\nEnter the year of the event: ", 2020, 2120);
            int month = ReadInteger("\nEnter the month the event will take place: ", 0, 12);
            int day;
            do
            {
                day = ReadInteger("\nEnter the day of the event: ", 0, 31);
                if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31)
                {                    
                    Console.WriteLine("\nThis month only contains up to 30 days");
                }
                else if (year % 4 == 0 && month == 2 && day == 29)
                {
                    break;
                }
                else if(month == 2 && day > 28)
                {
                    Console.WriteLine($"\n!!!February only contains 28 days; unless it's a leap year");
                    if(year % 4 == 0)
                    {
                        Console.WriteLine($"\tsuch as {year} is, so it contains 29");
                    }
                    else
                    {
                        Console.WriteLine($"\twhich {year} is not");
                    }
                }
            } while (((month == 4 || month == 6 || month == 9 || month == 11) && (day == 31)) || (month == 2 && day > 28));
            int hour = ReadInteger("\nEnter the hour of the event, in military time (0-23) : ", 0, 23);

            DateTime eventDate = new System.DateTime(year, month, day, hour, 0, 0);
            DateTime currentDate = DateTime.Now;
            TimeSpan timeLeft = eventDate.Subtract(currentDate);            
            Console.WriteLine($"\nThere are {Math.Ceiling(timeLeft.TotalSeconds)} seconds till {eventName}");
        }



        static void SecondsToHours()
        {
            int seconds;
            int minutes;
            int hours;


            int result = -1;
            do
            {
                try
                {
                    string intString;

                    do
                    {
                        Console.Write("\nPlease enter the total amount of seconds you wish to convert into hours, minutes and seconds: ");
                        intString = Console.ReadLine();
                    } while (intString == "");
                    
                    result = int.Parse(intString);
                    if (result < 0)
                    {
                        Console.WriteLine($"\nPlease list a positive value. ");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nError: " + (e.Message));
                }
            } while (result < 0);
            Console.WriteLine("\nValue Accepted!");            

            seconds = result % 60;
            minutes = (result / 60) % 60;
            hours = (result / 60) / 60;      

            Console.WriteLine($"\nThere are {hours} hours, {minutes} minutes and {seconds} seconds in {result} seconds");
        }



        static void HoursToSeconds()
        {            
            int minutes;
            int seconds;

            int inputHours = ReadInteger("\nEnter the hours: ", 0, 23);
            int inputMinutes = ReadInteger("\nEnter the minutes: ", 0, 59);
            int inputSeconds = ReadInteger("\nEnter the seconds: ", 0, 59);

            minutes = (inputHours * 60) + inputMinutes;            
            seconds = (minutes * 60) + inputSeconds;           
            Console.WriteLine($"\nThere are {seconds} seconds in {inputHours} hours, {inputMinutes} minutes, and {inputSeconds} seconds");           
        }


        
        static int ReadInteger(string prompt, int min, int max)
        {
            int result = min - 1;
            do
            {
                try
                {
                    string intString;

                    do
                    {
                        Console.Write(prompt);
                        intString = Console.ReadLine();
                    } while (intString == "");
                    
                    result = int.Parse(intString);
                    if (result < min || result > max)
                    {
                        Console.WriteLine($"\nEnter a positive value between {min} and {max}. ");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nError: " + (e.Message) + $"\nPlease enter a valid number between {min} and {max}");
                }
            } while ((result < min) || (result > max));
            return result;
        }


        static string ReadString(string prompt)
        {
            string result;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
            } while (result == "");
            return result;
        }
    }
}
