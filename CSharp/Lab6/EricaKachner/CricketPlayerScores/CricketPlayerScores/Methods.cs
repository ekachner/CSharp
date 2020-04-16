using System;

namespace CricketPlayerScores
{
     public class Methods
    {

        public static string EnterPlayerName()
        {
            string name = Methods.ReadString("Please enter a player's name: ");
            return name;
        }



        public static string ReadString(string prompt)
        {
            string result;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
                if (result == "")
                {
                    Console.WriteLine("Please enter the player's name: ");
                }
            } while (result == "");
            return result;
        }



        public static int ReadInteger(string prompt, int min, int max)
        {
            int result = min - 1;
            do
            {
                try
                {
                    string intString = ReadString(prompt);
                    result = int.Parse(intString);
                    if (result < min || result > max)
                    {
                        Console.WriteLine($"Please list a score between {min} and {max}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + (e.Message) + $" Please enter a valid number between {min} and {max}");
                }
            } while ((result < min) || (result > max));
            return result;
        }



        public static int EnterScore(int min, int max)
        {

            int score = ReadInteger($"Please enter his score: ", min, max);
            return score;
        }

    }
}





