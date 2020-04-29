using System;
namespace Dice_Chucker
{
    public class Inputs
    {
        public static void PressEnter(bool another)
        {
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    another = true;
                    break;
                case ConsoleKey.Escape:
                    another = false;
                    break;
                default:
                    Console.WriteLine("Wrong key. Please try again.");
                    break;
            }
        }
    }
}
