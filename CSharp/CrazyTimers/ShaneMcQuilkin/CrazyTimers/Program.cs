using System;

namespace CrazyTimers
{
    class Program
    {
        static void Main(string[] args)
        {
            CountDownTimer();
            ReversCountDownTimer();
            TimeToEvent();
        }
        public static void CountDownTimer()
        {
            //Console.WriteLine("Enter the Number of hours: ");
            //int hours = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter the number of Minutes: ");
            //int minutes = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter the number of seconds: ");
            int hours = GetValue("Enter the Number of hours: ", 23, 0);
            int minutes = GetValue("Enter the number of Minutes: ", 59, 0);
            int seconds = GetValue("Enter the number of seconds: ", 59, 0);
            int minutesToSeconds = minutes * 60;
            int hoursToSeconds = hours * 3600;
            // The below lines give the output.
            int totalSeconds = seconds + minutesToSeconds + hoursToSeconds;
            Console.WriteLine("The total number of seconds: " + totalSeconds);
            
            //time converting to seconds. hours, minutes into seconds as well.
            // output our seconds after conversion.
        }
        public static void ReversCountDownTimer()
        {
            int hours = GetValue("Enter the number of hours: ", 23, 0);
            int minutes = GetValue("Einter the number of minutes: ", 59, 0);
            int seconds = GetValue("Enter the number of seconds; ", 59, 0);
            int minutesToSeconds = minutes % 60;
            int hoursToSeconds = hours % 3600;
            int totalhours = seconds + minutesToSeconds + hoursToSeconds;
            Console.WriteLine("The total number of hours: " + totalhours);

        }
        public static void TimeToEvent()
        {
            Console.WriteLine("Enter the day of event: " );
            string day = Console.ReadLine();
            Console.WriteLine("The month it will take place: ");
            string month = Console.ReadLine();
            Console.WriteLine("Enter the year of the event: ");
            string year = Console.ReadLine();
            DateTime Event;
            DateTime today = DateTime.Now;
            Console.WriteLine("Event name: " + day +"/"+ month +"/"+ year);
            Event = Convert.ToDateTime(day + "/" + month + "/" + year).Date;
            TimeSpan difference = today.Subtract(Event);
            Console.WriteLine("Now" + difference);
            
            
        }
        
        //public static int MinutesToSeconds(string timePrompt, int max, int min)
        //{
        //    int result = min - 1;
        //    bool CountDownTimer = false;
        //    while (CountDownTimer == false)
        //    {
        //        Console.WriteLine(timePrompt);
        //        int input = int.Parse(Console.ReadLine());
        //        if(max >= 59)
        //        {
        //            Console.WriteLine("The value is invalid. The value must be between 0 and 59.");
        //        }
        //        else if (min <= 0)
        //        {
        //            Console.WriteLine("the value is invalid. The value must be between 0 and 59");
        //        }
        //        CountDownTimer = true;
        //        return result;
                
        //    }
        //} Try not to hard code when able.
        public static int GetValue(string timePrompt, int max, int min)
        {
            int result = 0;
            bool countDownTimer = false;
            while (countDownTimer == false)
            {
                Console.WriteLine(timePrompt);
                countDownTimer = int.TryParse(Console.ReadLine(),out result);
                if(countDownTimer == true)
                {
                    if(result > max || result < min)
                    {
                        countDownTimer = false;
                        Console.WriteLine($"The value must be between {min} and {max}.");
                    }
                  
                }
                else
                {
                    Console.WriteLine($"The value must be between {min} and {max}.");
                }
            }
            return result;
           
        }
           

    }
}
