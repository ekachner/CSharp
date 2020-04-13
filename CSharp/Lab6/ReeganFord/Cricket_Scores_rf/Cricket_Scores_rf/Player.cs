using System;
using System.Linq;

namespace CricketScores
{
    public class Player
    {
        public readonly string FirstName;
        public readonly string LastName;
        public readonly int Score;

        public Player(string firstName, string lastName, int score)
        {
            FirstName = firstName;
            LastName = lastName;
            Score = score;
        }

        public static Player[] EnterPlayerInfo()
        {
            var Team = new Player[11];

            for (int i = 0; i < 11; i++)
            {
                int counter = i + 1;
                string Fname = Inputs.ReadString($"(Player {counter}) Please enter player's first name: ");
                string Lname = Inputs.ReadString("Please enter player's last name: ");
                int Score = Inputs.ReadNumber("Please enter player's score: ", 0, 500);

                Team[i] = new Player(Fname, Lname, Score);
                Console.Clear();
                Console.WriteLine("Accepted! Next player:");
            }
            return Team;
        }

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
            Console.WriteLine($"AVERAGE SCORE: {averageScore} POINTS");
        }
    }
}