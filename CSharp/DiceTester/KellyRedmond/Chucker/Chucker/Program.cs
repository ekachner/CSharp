using System;
using DiceLibrary;

namespace Chucker
{
    class Program
    {
        static void Main(string[] args)
        {
            FairDice dice1 = new FairDice();
            DiceClass dice2 = new DiceClass();
            DiceClass dice3 = new DiceClass();
            dice3.SetPlayer("Fred");
            string rollAgain = "Y";
            while(rollAgain == "Y")
            {
                Console.WriteLine("Normal Dice:");
                DiceTest(dice2);
                Console.WriteLine("Fred's Dice:");
                DiceTest(dice3);
                Console.WriteLine("Fair Dice");
                DiceTestFair(dice1);

                Console.WriteLine("\nNormal Dice");
                DiceClassTestSpots(dice2);
                Console.WriteLine("Fred's Dice:");
                DiceClassTestSpots(dice3);
                Console.WriteLine("Fair Dice");
                FairDiceTestSpots(dice1);
                rollAgain = Methods.StringChoice("Roll Again? ( Y / N ): ", "Y", "N");

            }
        }

        static void RollDice(DiceClass dice)
        {
            for (int i = 20; i > 0; i--)
            {
                Console.WriteLine($"{20 - i + 1}. {dice.IntSpots()}");
            }
        }

        static void DiceTest(DiceClass dice)
        {
            int numberRolls = 1000;
            int sum = 0;
            
            for (int i = numberRolls; i > 0; i--)
            {
                sum += dice.IntSpots();
            }
            int average = sum / numberRolls;
            Console.WriteLine("The average is {0}", average);
        }

        static void DiceTestFair(FairDice dice)
        {
            int numberRolls = 1000;
            int sum = 0;

            for (int i = numberRolls; i > 0; i--)
            {
                sum += dice.IntSpots();
            }
            int average = sum / numberRolls;
            Console.WriteLine("The average is {0}", average);
        }

        static int one;
        static int two;
        static int three;
        static int four;
        static int five;
        static int six;

        static void DiceClassTestSpots(DiceClass dice)
        {
            int numberRolls = 1000;
            one = 0;
            two = 0;
            three = 0;
            four = 0;
            five = 0;
            six = 0;

            for (int i = numberRolls; i > 0; i--)
            {
                int dRoll = dice.IntSpots();
                DiceSwitch(dRoll);
            }

            Console.WriteLine($"{one} Ones   {two} Twos   {three} Threes   {four} Fours   {five} Fives   {six} Sixes");
        }

        static void FairDiceTestSpots(FairDice dice)
        {
            int numberRolls = 1000;
            one = 0;
            two = 0;
            three = 0;
            four = 0;
            five = 0;
            six = 0;

            for (int i = numberRolls; i > 0; i--)
            {
                int dRoll = dice.IntSpots();
                DiceSwitch(dRoll);
            }

            Console.WriteLine($"{one} Ones   {two} Twos   {three} Threes   {four} Fours   {five} Fives   {six} Sixes");
        }

        static int DiceSwitch(int dRoll)
        {
            int def = 0;
            switch (dRoll)
            {
                case 1:
                    return one++;

                case 2:
                    return two++;

                case 3:
                    return three++;

                case 4:
                    return four++;

                case 5:
                    return five++;

                case 6:
                    return six++;
            }
            return def;
        }

        static void DicePLayer(DiceClass dice)
        {
            Console.WriteLine("Enter the Name of the Player: ");
            dice.SetPlayer(Console.ReadLine().Trim());
            Console.WriteLine(dice.IntSpots());
        }

        static void PlayerTest()
        {
            DiceClass dice1 = new DiceClass();
            dice1.SetPlayer("Fred");
            DiceClass dice2 = new DiceClass();
            Console.WriteLine("Enter the name of Player 2: ");
            string p2Name = Console.ReadLine().Trim();
            dice2.SetPlayer(p2Name);

            Console.WriteLine("Fred's Average:");
            DiceTest(dice1);

            Console.WriteLine($"\n{p2Name}'s Average:");
            DiceTest(dice2);

            Console.WriteLine("Fred's Rolls:");
            RollDice(dice1);

            Console.WriteLine($"\n{p2Name}'s Rolls:");
            RollDice(dice2);

            Console.WriteLine($"Fred roll 2 - 6.\nAll other players roll 1 - 5");
        }
    }
}
