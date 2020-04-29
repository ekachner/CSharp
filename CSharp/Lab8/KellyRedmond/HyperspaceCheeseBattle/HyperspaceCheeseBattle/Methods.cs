using System;

namespace HyperspaceCheeseBattle
{
    public class Methods
    {
        public static int VerifyNumber(string prompt, int min, int max, string printValue = "number")
        {
            Console.Write(prompt);
            string userInput = Console.ReadLine();
            bool isNumber = int.TryParse(userInput, out int numberOut);

            while (!isNumber || numberOut < min || numberOut > max)
            {
                Console.Write($"Entry is not valid. Please enter a {printValue} between {min} and {max}: ");
                isNumber = int.TryParse(Console.ReadLine(), out numberOut);
            }

            return numberOut;
        }

        public static string StringChoice(string prompt, string value1, string value2)
        {
            string userInput;

            while (true)
            {
                Console.Write(prompt);
                userInput = Console.ReadLine().ToUpper().Trim();
                if (userInput == value1 || userInput == value2)
                {
                    break;
                }
                Console.WriteLine($"Please enter either {value1} or {value2}");
            }

            return userInput;
        }
    }
}