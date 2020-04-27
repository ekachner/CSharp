using System;
namespace Hyperspace_Cheese_Battle
{
    public class Dice
    {
        public static int DiceThrow()
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, 7);
            return dice;
        }

        public static int Roll()
        {
            bool pressedEnter = false;
            int rollNum = 0;

            Console.Write("Press enter.");

            do
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    rollNum = DiceThrow();
                    Console.WriteLine($"You rolled a {rollNum}!");
                    pressedEnter = true;
                }
                else
                {
                    Console.WriteLine("Wrong key. Please try again.");
                }
            } while (pressedEnter == false);

            return rollNum;
        }
    }
}
