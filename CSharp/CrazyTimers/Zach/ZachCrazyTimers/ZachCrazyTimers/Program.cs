using System;

namespace ZachCrazyTimers
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 for countdown or 2 for reverse countdown or 3 for time until event.");
            string input = Console.ReadLine();
            if (input == "1")
            {
                SecondsToTime();
            }
            else if (input == "2")
            {
                TimeToSeconds();
            }
            else if (input == "3")
            {
                TimeUntilEvent();
            }
 

        }

        static void SecondsToTime()
        {
            int hours = TimeLimit("Enter the number of hours: ", 23, 0);

            int minutes = TimeLimit("Enter the number of minutes: ", 59, 0);

            int seconds = TimeLimit("Enter the number of seconds: ", 59, 0);



            TimeSpan ts = TimeSpan.Parse(hours + ":" + minutes + ":" + seconds);
            double totalSeconds = ts.TotalSeconds;

            Console.WriteLine("The total number of seconds is: " + totalSeconds);
        }

        static void TimeToSeconds()
        {
            int seconds = TimeLimit("Enter the number of seconds: ", 86399, 0);


            TimeSpan ts = TimeSpan.FromSeconds(seconds);


            Console.WriteLine("This is equal to " + ts.Hours + " hours " + ts.Minutes + " minutes " + ts.Seconds + " seconds.");
        }


        static void TimeUntilEvent()
        {
            Console.WriteLine("Enter the name of the event: ");
            string eventName = Console.ReadLine();

            int year = TimeLimit("Enter the year of the event: ", 2120, 2020);
            int month = TimeLimit("Enter the month of the envent: ", 12, 1);
            int day;
            do
            {
                day = TimeLimit("Enter the day of the event: ", 31, 1);
                if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31)
                {
                    Console.WriteLine("This month only contains 30 days.  Please input new day.");
                }
                else if (year % 4 == 0 && month == 2 && day == 29)
                {
                    break;
                }
                else if (month == 2 && day > 28)
                {
                    Console.WriteLine("February only has 28 days unless it is a leap year.");
                }
            } while (((month == 4 || month == 6 || month == 9 || month == 11) && (day == 31)) || (month == 2 && day > 28));
            int hour = TimeLimit("Enter the hour of the event in military time: ", 23, 0);

            DateTime eventDate = new DateTime(year, month, day, hour, 0, 0);
            DateTime currentDate = DateTime.Now;
            TimeSpan ts = eventDate.Subtract(currentDate);
            Console.WriteLine("There are " + ts.TotalSeconds + " seconds until " + eventName);


        }


        static int TimeLimit(string prompt, int max, int min)
        {
           
            int timeValue = 0;
            Console.WriteLine(prompt);
            
            bool canReadInput = false; 

            while (canReadInput == false)
            {
                var input = Console.ReadLine();
                canReadInput = int.TryParse(input, out timeValue);
                if (canReadInput)
                {
                    if (timeValue >= min && timeValue <= max)
                        return timeValue;
                    else
                    {
                        Console.WriteLine("Invalid input. Must be a number between " + min + " and " + max);
                        canReadInput = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Must be a number between " + min + " and " + max);

                }
            } return timeValue;
            

           

        }





       
            
        
    }
}
