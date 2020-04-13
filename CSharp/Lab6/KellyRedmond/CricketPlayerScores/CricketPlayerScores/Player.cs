using System;
using System.Globalization;

namespace CricketPlayerScores
{
    public class Player
    {
        public string Name;
        public int Score;

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }

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

        public static string IsDuck(int pScore)
        {
            string writeScore;

            if (pScore == 0)
            {
                writeScore = "duck";
            }
            else
            {
                writeScore = pScore.ToString();
            }

            return writeScore;
        }
    }
}
