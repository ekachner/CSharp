using System;

namespace Cricketscores
{
    class Program
    {
        public static int result;
        public static string PlayerNames;
        public static int PlayerScores;
        static void Main(string[] args)

        {
            Player[] players = new Player[11];
            for (int i = 0; i < players.Length; i++)
            {
                bool validName = false;

                do
                {
                    int displayPlayerNames = i + 1;
                    Console.WriteLine("Enter the name of player " + displayPlayerNames + ":" );
                    string playerName = Console.ReadLine();
                    if (string.IsNullOrEmpty(playerName))
                    {
                        Console.WriteLine("Enter a valid name: ");
                    }
                    else
                    {
                        players[i].Names = playerName;
                        validName = true;
                    }
                } while (validName == false);

            }
            for (int i = 0; i < players.Length; i++)
            {
                bool validScore = false;

                do
                {
                    
                    Console.WriteLine("Enter " + players[i].Names + "'s score:") ;
                    int playerScores = int.Parse(Console.ReadLine());
                    if (playerScores >= 0 && playerScores <= 500)
                    {
                        players[i].Scores = playerScores;
                        validScore = true;
                    }
                    else
                    {
                        Console.WriteLine("Enter a score between 0 and 500: ");
                    }
                } while (validScore == false);

            }
            foreach(Player player in players)
            {
                Console.WriteLine(player.Names + "'s score; " + player.Scores);
            }
        }
        struct Player
        {
            public string Names;
            public int Scores;

        }
        static Player[] SortPlayersByName(Player[] players)
        {
            bool doneSwap;
            do
            {
                doneSwap = false;
                for (int i = 0; i < players.Length - 1; i++)
                {
                    if (players[i].Names[0] > players[i + 1].Names[0])
                    {
                        var player = players[i]; //make a temp copy of player
                        players[i] = players[i + 1];
                        players[i + 1] = player;
                        doneSwap = true;
                    }
                }
            } while (doneSwap);
            return players;
            
        }
        //static int PlayerScores(string[] Player)
        //{
        //    do
        //    {

        //        Console.WriteLine("Enter the players score: ");
        //        string resultString = Console.ReadLine();
        //        result = int.Parse(resultString);

        //    } while ((result < 0) || (result > 500));

        //    Console.WriteLine("Enter a valid score between 0 and 500");

        //    return result;
        //}
        //static int PlayerNames()
        //{
        //    string resultString;
        //    do
        //    {
        //        Console.WriteLine("Enter the players name: ");
        //        resultString = Console.ReadLine();

        //    } while (string.IsNullOrEmpty(resultString) == false);

        //    Console.WriteLine("Enter a valid player name; ");


        //    return result;

        //}
    }
}
           

