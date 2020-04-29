using System;
using System.Linq;
namespace Dice_Chucker
{
    public class FairDice
    {
        public static string PlayerName { get; set; }

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

        public static void FindAverage(int numOfRolls)
        {
            int[] rolls = new int[numOfRolls];

            for (int i = 0; i < numOfRolls; i++)
            {
                rolls[i] = DiceThrow();
            }
            int sum = rolls.Sum();
            int average = sum / numOfRolls;

          
            Console.WriteLine($"Average: {average}");
        }

        public static void TwentyRolls()
        {
            for(int i = 0; i < 20; i++)
            {
                Console.WriteLine(DiceThrow());
            }
        }
    }
}
