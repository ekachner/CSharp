
using System;
using DiceLibrary;

namespace ZachDiceTester
{
    class Chucker
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose 1 to pick Fred's Dice game or 2 to pick the Fair Dice game.");
            string input = Console.ReadLine();
            if (input == "1")
                DodgyDice();
            else if (input == "2")
                FairDice();
            
        }
        /* When running Dodgy Dice the number 6 is never rolled when using your own name. The average is about 2.75.
         * When using Fred's name, the number 6 is rolled a lot and 1 never shows up. His average is around 4.5. */
        static void DodgyDice()
        {
            int roll;
            double total = 0;

            DiceClass dice = new DiceClass();
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();

            dice.SetPlayer(name);

            for (int i = 0; i < 100; i++)
            {
                roll = dice.IntSpots();
                Console.WriteLine(i + 1 + ". " + roll);
                total += roll;
            }
            Console.WriteLine("The average is: " + total / 100);
        }

        static void FairDice()
        {
            int roll;
            double total = 0;

            Random dice = new Random();

            for (int i = 0; i < 100; i++)
            {
                roll = dice.Next(1, 7);
                total += roll;
            }
            Console.WriteLine("The average is: " + total / 100);


        }
    }
}
