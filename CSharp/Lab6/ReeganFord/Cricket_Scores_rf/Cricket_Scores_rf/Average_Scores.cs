using System;
using System.Linq;

namespace CricketScores
{
    public class AverageScore
    {
        public static void FindAverage(Player[] arr)
        {
            int[] Scores = new int[11];

            for (int i = 0; i < 11; i++)
            {
                int playerScore = arr[i].Score;
                Scores[i] = playerScore;
            }

            int sum = Scores.Sum();
            int averageScore = sum / 11;
            Console.WriteLine("AVERAGE SCORE: {0} POINTS", averageScore);
        }
    }
}
