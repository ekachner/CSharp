using System;

namespace CricketPlayerScores
{
    public class Team
    {
        public const int NUMBEROFPLAYERS = 11;

        public static Player[] PlayerEntry()
        {
            int numPlayers = Methods.IsNumber("Enter the number of players: ", 0, NUMBEROFPLAYERS);
            Player[] players = new Player[numPlayers];

            //Player[] players = new Player[NUMBEROFPLAYERS];

            int count = 1;

            for (int i = 0; i < players.Length; i++)
            {
                string playerCorrect = "N";

                while (playerCorrect == "N")
                {
                    Console.WriteLine($"Player {count}");
                    string playerName = CreatePlayer.EnterName();
                    int playerScore = CreatePlayer.EnterScore(playerName);

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

            return players;
        }

        public static void PrintRoster(Player[] players)
        {
            Console.WriteLine("\n   Team Roster - Average Score: {0}\n\t   {1,-20}\t{2,5}", PrintAverageScore(players), "Name", "Score");
            foreach (var player in players)
            {
                var playerNo = Array.FindIndex(players, x => x.Equals(player)) + 1;
                Console.WriteLine($"\t{playerNo}. {player.Name, -20}\t{Player.IsDuck(player.Score), 5}");
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
