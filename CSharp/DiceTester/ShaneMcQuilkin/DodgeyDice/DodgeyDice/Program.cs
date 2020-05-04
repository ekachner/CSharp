using System;
using DiceLibrary;

namespace DodgeyDice
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++) ;

            DiceClass dice = new DiceClass();
            Console.WriteLine(dice.Roll());
        }
        

    }
}
