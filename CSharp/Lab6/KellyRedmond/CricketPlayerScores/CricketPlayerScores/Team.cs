using System;

namespace CricketPlayerScores
{
    public class Team
    {
        public const int NUMBEROFPLAYERS = 11;

        public static Player[] PlayerEntry()
        {
            //int numPlayers = Methods.IsNumber("Enter the number of players: ", 0, NUMBEROFPLAYERS);
            //Player[] players = new Player[numPlayers];

            Player[] players = new Player[NUMBEROFPLAYERS];

            int count = 1;

            for (int i = 0; i < players.Length; i++)
            {
                string playerCorrect = "N";

                while (playerCorrect == "N")
                {
                    Console.WriteLine($"Player {count}");
                    string playerName = Player.EnterName();
                    int playerScore = Player.EnterScore(playerName);

                    Console.Clear();

                    Console.WriteLine($"Player {count}");
                    playerCorrect = Methods.StringInput($"Name: {playerName}\nScore: {playerScore}\nIs this correct? ( Y / N ): ", "Y", "N");

                    if (playerCorrect == "Y")
                    {
                        players[i] = new Player(playerName, playerScore);
                        Console.WriteLine("Player added");
                    }

                    Console.Clear();
                }

                count++;
            }

            PrintRoster(players);

            return players;
        }

        public static void PrintRoster(Player[] players)
        {
            Console.WriteLine("Team Roster - Average Score: {0}\nName\tScore", PrintAverageScore(players));
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name}\t{Player.IsDuck(player.Score)}");
            }
            Console.WriteLine();
        }

        public static int PrintAverageScore(Player[] players)
        {
            int sum = 0;

            foreach (var player in players)
            {
                sum += player.Score;
            }

            int average = sum / players.Length;

            return average;
        }
    }
}
