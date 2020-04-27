using System;

namespace Hyperspace_Cheese_Battle
{
    public class Inputs
    {
        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().Trim();
            string output = FirstLetterCap(input);
            return output;
        }
        public static string FirstLetterCap(string inputString)
        {
            string newString = inputString.Trim();
            char[] c = newString.ToCharArray();
            c[0] = char.ToUpper(c[0]);
            string outputString = new string(c);
            return outputString;
        }

        public static int ReadNumber(string prompt, int min, int max)
        {
            int number;
            do
            {
                Console.Write(prompt);
                string numInput = Console.ReadLine();
                bool isNumber = int.TryParse(numInput, out number);

                if (!isNumber || number < min || number > max)
                {
                    Console.WriteLine("Please enter a number in range: {0} to {1} ", min, max);
                }
                else break;

            } while (true);

            return number;
        }
    }
}