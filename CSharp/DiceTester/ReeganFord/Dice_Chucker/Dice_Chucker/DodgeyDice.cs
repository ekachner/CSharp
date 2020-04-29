using System;
using DiceLibrary;
using System.Linq;

namespace Dice_Chucker
{
    public class DodgeyDice
    {
        public static void DodgeyAverage(int numOfRolls)
        {
            int[] rolls = new int[numOfRolls];

            for (int i = 0; i < numOfRolls; i++)
            {
                DiceClass dice = new DiceClass();
                int roll = dice.IntSpots();
                rolls[i] = roll;
            }
            int sum = rolls.Sum();
            int average = sum / numOfRolls;

            Console.WriteLine(average);
        }

        public static void TestPlayerName()
        {
            DiceClass dice = new DiceClass();
            dice.SetPlayer("Fred");
            Console.WriteLine(dice.IntSpots());
        }
    }
}
