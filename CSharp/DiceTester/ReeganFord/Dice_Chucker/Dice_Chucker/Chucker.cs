
using System;

namespace Dice_Chucker
{
    class Chucker
    {
        static void Main()
        {
            bool anotherRoll = true;
            do
            {
                FairDice.Roll();
                Console.WriteLine("Roll again? (Press Enter) ");
                Inputs.PressEnter(anotherRoll);

            } while (anotherRoll == true);

            Console.Clear();
            Console.WriteLine("Thanks for playing!");
        }
    }
}
