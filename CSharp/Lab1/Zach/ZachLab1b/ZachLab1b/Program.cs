using System;

namespace ZachLab1b
{
    class Program
    {
        static void Main(string[] args)
        {
            int weightPounds = 1;
            string weightMessage = "Invalid weight. Unqualified to fight.";

            Console.WriteLine("Enter your weight to see your class:");
            weightPounds = Convert.ToInt32(Console.ReadLine());
            if (weightPounds > 300 || weightPounds < 90)
            {
                Console.WriteLine(weightMessage);
                return;
            }
            if (weightPounds >= 191)
            {
                Console.WriteLine("You are a Heavyweight. Good Luck!");
            }
            else if (weightPounds <= 190 && weightPounds >= 176)
            {
                Console.WriteLine("You are a Cruiserweight. Good Luck!");
            }
            else if (weightPounds <= 175 && weightPounds >= 169)
            {
                Console.WriteLine("You are a Light Heavyweight. Good Luck!");
            }
            else if (weightPounds <= 168 && weightPounds >= 161)
            {
                Console.WriteLine("You are a Super Middleweight. Good Luck!");
            }
            else if (weightPounds <= 160 && weightPounds >= 155)
            {
                Console.WriteLine("You are a Middleweight. Good Luck!");
            }
            else if (weightPounds <= 154 && weightPounds >= 148)
            {
                Console.WriteLine("You are a Junior Middleweight. Good Luck!");
            }
            else if (weightPounds <= 147 && weightPounds >= 141)
            {
                Console.WriteLine("You are a Welterweight. Good Luck!");
            }
            else if (weightPounds <= 140 && weightPounds >= 136)
            {
                Console.WriteLine("You are a Junior Welterweight. Good Luck!");
            }
            else if (weightPounds <= 135 && weightPounds >= 131)
            {
                Console.WriteLine("You are a Lightweight. Good Luck!");
            }
            else if (weightPounds <= 130 && weightPounds >= 127)
            {
                Console.WriteLine("You are a Junior Lightweight. Good Luck!");
            }
            else if (weightPounds <= 126 && weightPounds >= 123)
            {
                Console.WriteLine("You are a Featherweight. Good Luck!");
            }
            else if (weightPounds <= 122 && weightPounds >= 119)
            {
                Console.WriteLine("You are a Junior Featherweight. Good Luck!");
            }
            else if (weightPounds <= 118 && weightPounds >= 116)
            {
                Console.WriteLine("You are a Bantamweight. Good Luck!");
            }
            else if (weightPounds <= 115 && weightPounds >= 113)
            {
                Console.WriteLine("You are a Junior Bantamweight. Good Luck!");
            }
            else if (weightPounds <= 112 && weightPounds >= 109)
            {
                Console.WriteLine("You are a Flyweight. Good Luck!");
            }
            else if (weightPounds <= 108 && weightPounds >= 106)
            {
                Console.WriteLine("You are a Junior Flyweight. Good Luck!");
            }
            else if (weightPounds <= 105 && weightPounds >= 90)
            {
                Console.WriteLine("You are a Strawweight. Good Luck!");
            }
        }
    }
}
