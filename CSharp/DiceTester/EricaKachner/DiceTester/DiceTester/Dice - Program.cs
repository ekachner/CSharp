using System;
using DiceLibrary;

namespace DiceTester
{
    class Chucker
    {
        static DiceClass dice = new DiceClass();
        static int numberOfRolls = 1000;


        static void Main(string[] args)
        {
            DodgyDiceTester();
            FairDiceTester();
            FairDiceThrow();
        }

        
       
        static void DodgyDiceTester()
        {
            string testAnother;
            do
            {
                one = 0;
                two = 0;
                three = 0;
                four = 0;
                five = 0;
                six = 0;

                string name = ReadString("\nEnter name of player: ");
                Console.WriteLine($"\n{name}'s Test");
                dice.SetPlayer($"{name}");

                int roll = 0;
                double total = 0;
                for (int i = 0; i < numberOfRolls; i++)
                {
                    int rollNumber = dice.IntSpots();
                    Console.WriteLine($"{i + 1}. {rollNumber}");
                    TallyValues(rollNumber);
                    total += rollNumber;
                    roll++;
                }
                Console.WriteLine($"Testing {numberOfRolls} rolls from player {name}:");
                Console.WriteLine($"{one} Ones   {two} Twos   {three} Threes   {four} Fours   {five} Fives   {six} Sixes");
                Console.WriteLine($"average of rolls: {total / numberOfRolls: 0.0}");

                testAnother = ChooseBetween("\nWould you like to test with another player? (Y / N):", "Y", "N");
            }
            while (testAnother == "Y");
        }

        //OBSERVATION CONCLUSION:
        // *** When I run the DodgyDiceTester with any player whose name is NOT "Fred" then the dice never displays the value "six"
        //      but does display the value "one" twice as often if you compare it with the other values. 
        // *** When I run the DDTester with Fred as the player there are zero values of "one" but double the amount of rolls for
        //      the value "six".


        
        static void FairDiceTester()
        {
            one = 0;
            two = 0;
            three = 0;
            four = 0;
            five = 0;
            six = 0;

            Random random = new Random();
            Console.WriteLine($"\nFair Dice Test of {numberOfRolls} rolls");
            
            int roll = 0;
            double total = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                int rollNumber = random.Next(1, 7);
                Console.WriteLine($"{i + 1}. {rollNumber}");
                TallyValues(rollNumber);
                total += rollNumber;
                roll++;
            }
            Console.WriteLine($"Testing {numberOfRolls} rolls from \"Fair Dice\":");
            Console.WriteLine($"{one} Ones   {two} Twos   {three} Threes   {four} Fours   {five} Fives   {six} Sixes");
            Console.WriteLine($"average of rolls: {total / numberOfRolls: 0.0}");
        }



        static void FairDiceThrow()
        {
            Random random = new Random();
            Console.WriteLine("\nWelcome to a Fair Dice. \nIf at any time you would like to quit enter \"Q\" \n\"ENTER\" to roll\n");
            Console.ReadLine();

            do
            {
                int roll = random.Next(1, 7);
                Console.WriteLine($"Your dice roll = {roll}");                
            }
            while (Console.ReadLine().ToUpper().Trim() != "Q");

            Console.WriteLine("\nHave a nice day!");
        }



        static int one;
        static int two;
        static int three;
        static int four;
        static int five;
        static int six;

        static void TallyValues(int roll)
        {            
            if (roll == 1)
            {
                one++;
            }
            else if (roll == 2)
            {
                two++;
            }
            else if (roll == 3)
            {
                three++;
            }
            else if (roll == 4)
            {
                four++;
            }
            else if (roll == 5)
            {
                five++;
            }
            else
            {
                six++;
            }
        }



        static string ChooseBetween(string prompt, string option1, string option2)
        {
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine().ToUpper().Trim();
                if (input == option1 || input == option2)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine($"Error: Please select {option1} or {option2}");
                }
            } while (true);
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
