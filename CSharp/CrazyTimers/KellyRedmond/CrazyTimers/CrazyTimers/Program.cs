using System;

namespace CrazyTimers
{
    class Program
    {
        static void Main(string[] args)
        {
            string calculateAgain = "Y";
            
            while (calculateAgain == "Y")
            {
                Welcome();
                calculateAgain = Methods.StringChoice("\nWould you like to calculate a different time? ( Y / N ): ", "Y", "N");
                Console.Clear();
            }
        }

        static void Welcome()
        {
            Console.WriteLine("Welcome to the Time Calculators");
            CalculatorChoice();
        }

        static void CalculatorChoice()
        {
            Console.WriteLine("There are three time calculators to choose from:\n\t1. Countdown Timer (hours, minutes, seconds into seconds)\n\t2. Reverse Countdown Timer (seconds into hours, minutes, seconds)\n\t3. Seconds to Calculator (seconds from now until chosen future hour)");
            int calcChoice = Methods.VerifyNumber("Which Calculator would you like to use? 1, 2, or 3: ", 1, 3);
            Console.Clear();
            switch(calcChoice)
            {
                case 1:
                    CountdownTimer();
                    break;

                case 2:
                    ReverseCountdown();
                    break;

                case 3:
                    SecondsToDate();
                    break;

                default:
                    Console.WriteLine("The timer has hit a snag, please restart.");
                    break;
            }
        }

        static void CountdownTimer()
        {
            Console.WriteLine("Countdown Timer Calculator by Kelly Redmond\nVersion 1.0");
            Timer userTimer = new Timer();
            userTimer.GetHours();
            userTimer.GetMinutes();
            userTimer.GetSeconds();
            userTimer.CalculateSeconds();
        }

        static void ReverseCountdown()
        {
            Console.WriteLine("Reverse Countdown Timer Calculator by Kelly Redmond\nVersion 1.0");
            Timer userTimer = new Timer();
            userTimer.CalculateRegTime();
        }

        static void SecondsToDate()
        {
            Console.WriteLine("Seconds to Calculator by Kelly Redmond\nVersion 1.0");
            DayTimer userTimer = new DayTimer();
            userTimer.SecondsTill();

        }
    }
}
