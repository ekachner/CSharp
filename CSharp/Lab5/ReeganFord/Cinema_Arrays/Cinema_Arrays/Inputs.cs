using System;
namespace Cinema_Arrays
{
    public class Inputs
    {
        public static int ReadNumber(string prompt, int min, int max)
        {
            int result;
            do
            {
                Console.Write(prompt);
                string numInput = Console.ReadLine();
                bool isNumber = int.TryParse(numInput, out result);

                if (!isNumber || result < min || result > max)
                {
                    Console.WriteLine("Please enter a number in range: {0} to {1}", min, max);
                }
                else break;
            } while (true);

            return result;
        }

        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().ToUpper();
            return input;
        }
    }
}
