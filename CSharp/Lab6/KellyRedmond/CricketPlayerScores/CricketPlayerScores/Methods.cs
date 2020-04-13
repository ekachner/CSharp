using System;

namespace CricketPlayerScores
{
    public class Methods
    {
        public static int IsNumber(string prompt, int min, int max, string number = "number")
        {
            Console.Write(prompt);
            string numberString = Console.ReadLine();
            bool verifyNumber = int.TryParse(numberString, out int numberOut);

            while (!verifyNumber || numberOut < min || numberOut > max)
            {
                Console.Write($"Entry not valid. Please enter a {number} between {min} and {max}: ");
                verifyNumber = int.TryParse(Console.ReadLine(), out numberOut);
            }

            return numberOut;
        }

        public static string StringInput(string prompt, string value1, string value2)
        {
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().ToUpper().Trim();
                if (input == value1 || input == value2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Please choose either {value1} or {value2}");
                }
            } while (true);

            return input;
        }
    }
}
