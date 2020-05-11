using System;
using DiceLibrary;

namespace DodgeyDice
{
    class Program
    {
        static void Main(string[] args)
        {
            DiceClass dice = new DiceClass();
            dice.SetPlayer("Fred");

            int rollValueTotal = 0;
            for (int i = 0; i < 1000; i++)
            {
                int rollValue = dice.IntSpots();
                Console.WriteLine(rollValue);
                rollValueTotal += rollValue;
            }
            int average = rollValueTotal / 1000;
            Console.WriteLine($"{average: 0.0}");
            FairDice(); 
        }
        static void FairDice()
        {
            Random dice = new Random();

            int rollValueTotal = 0;
            for(int i = 0; i < 20; i++)
            {
                int rollValue = dice.Next();
                Console.WriteLine(rollValue);
                rollValueTotal += rollValue;
            }
            int average = rollValueTotal / 20;
            Console.WriteLine($"{average: 0.0}");
        }

       
    }
      
}
