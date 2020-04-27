using System;

namespace CrazyTimers
{
    class Program
    {
        

        static void Main(string[] args)
        {
            
            //HoursToSeconds();
            SecondsToHours();

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
                    string intString = ReadString("\nPlease enter the total amount of seconds you wish to convert into hours, minutes and seconds.");
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
            Console.WriteLine("Value Accepted!");            

            seconds = result % 60;
            minutes = (result / 60) % 60;
            hours = (result / 60) / 60;      

            Console.WriteLine($"\nThere are {hours} hours, {minutes} minutes and {seconds} seconds in {result} seconds");
        }

        static void HoursToSeconds()
        {            
            int minutes;
            int seconds;

            int inputHours = ReadInteger("\nPlease list the hours: ", 0, 23);
            int inputMinutes = ReadInteger("Please list the minutes: ", 0, 59);
            int inputSeconds = ReadInteger("Please list the seconds: ", 0, 59);

            minutes = inputHours * 60;
            minutes += inputMinutes;
            seconds = minutes * 60;
            seconds += inputSeconds;
            Console.WriteLine($"\nThere are {seconds} seconds in {inputHours} hours, {inputMinutes} minutes, and {inputSeconds} seconds");           
        }


        static int ReadInteger(string prompt, int min, int max)
        {
            int result = min - 1;
            do
            {
                try
                {
                    string intString = ReadString(prompt);
                    result = int.Parse(intString);
                    if (result < min || result > max)
                    {
                        Console.WriteLine($"\nPlease list a positive value between {min} and {max}. ");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nError: " + (e.Message) + $" Please enter a valid number between {min} and {max}");
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
