using System;
using DiceLibrary;

namespace DiceTester
{
    class Chucker
    {
        static int numberOfRolls = 50;

        static void Main(string[] args)
        {
            DodgyDice();
            FredDodgyDice();
            FairDice();
        }


        //When anyone else uses Fred's his dodgy dice, he rigs the die values to reflect only the values 1-5.
        //He has replaced every spot count of 6 to reflect the value 1 which appears twice as often as other values.
        static void DodgyDice()
        {
            DiceClass dice = new DiceClass();
            string name = ReadString("\nEnter your name: ");
            Console.WriteLine($"\n{name}'s Dodgy Dice");

            dice.SetPlayer($"{name}");
            int roll;
            double total = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                roll = dice.IntSpots();
                Console.WriteLine($"{i + 1}. {roll}");
                total += roll;
            }
            Console.WriteLine($"average: {total / numberOfRolls: 0.0}");
        }


        //When Fred uses his dodgy dice, he rigs the die values to reflect only the values 2-6.
        //Rigged every spot count of 1 to relect value 6 so it appears twice as often as the other values.
        static void FredDodgyDice()
        {
            DiceClass dice = new DiceClass();            
            Console.WriteLine("\nFred's Rigged Dice");

            dice.SetPlayer("Fred");
            int roll;
            double total = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                roll = dice.IntSpots();
                Console.WriteLine($"{i + 1}. {roll}");
                total += roll;
            }
            Console.WriteLine($"average: {total / numberOfRolls: 0.0}");
        }



        static void FairDice()
        {            
            Random random = new Random();
            Console.WriteLine("\nFair Dice");
            
            int roll;
            double total = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                roll = random.Next(1, 7);                
                total += roll;
            }
            Console.WriteLine($"average: {total / numberOfRolls : 0.0}");
        }



        static string ReadString(string prompt)
        {
            string result;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
            } while (result == "");
            return result;
        }
    }
}
