using System;

namespace CricketScores
{
    public class StringHelper
    {
        public static string FirstLetterCap(string inputString)
        {
            string newString = inputString.Trim();
            char[] c = newString.ToCharArray();
            c[0] = char.ToUpper(c[0]);
            string outputString = new string(c);
            return outputString;
        }

        public static int ValidNumber(string inputString)
        {
            int number;
            bool isNumber = int.TryParse(inputString, out number);
            while (number < 0 || number > 500 || !isNumber)
            {
                Console.WriteLine("Invalid score. Please try again.");
                Console.Write("Please enter player's score: ");
                inputString = Console.ReadLine().Trim();
                isNumber = int.TryParse(inputString, out number);
            }

            return number;
        }
    }
}
