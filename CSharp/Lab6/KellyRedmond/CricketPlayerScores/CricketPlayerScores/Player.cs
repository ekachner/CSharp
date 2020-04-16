using System;

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
