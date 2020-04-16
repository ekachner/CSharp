using System;
using System.Globalization;

namespace CricketPlayerScores
{
    public class CreatePlayer
    {
        public static string EnterName()
        {
            string nameIn = "";
            bool nameAccepted = false;

            while (!nameAccepted)
            {
                Console.Write("Enter the players name: ");
                nameIn = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().Trim());

                if (nameIn.Length > 0 && !nameIn.Contains(" "))
                {
                    nameAccepted = true;
                }
                else
                {
                    Console.WriteLine("Name not entered correctly.");
                }
            }
            return nameIn;
        }

        public static int EnterScore(string playerName)
        {
            int scoreIn = Methods.IsNumber($"Enter {playerName}'s score: ", 0, 500, "score");
            return scoreIn;
        }
    }
}
