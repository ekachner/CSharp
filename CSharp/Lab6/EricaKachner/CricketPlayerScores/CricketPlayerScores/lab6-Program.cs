using System;

namespace CricketPlayerScores
{
    class Program
    {

        public static void Main(string[] args)
        {
            Player[] players = new Player[11];           

            EnterTeamStats(players);
            string sortOption = ChooseBetween("How do you wish to sort your list? By the names of the players or by their scores (Enter: N or S): ", "N", "S");
            PrintPlayers(players, sortOption);
        }



        //creation of new "type" to make array of two type values
        struct Player
        {
            public string Name;
            public int Score;
        }



        //cycles through each Player array to get a name and score for that player
        static void EnterTeamStats(Player[] players)
        {
            for (int i = 0; i < players.Length; i++)
            {
                string name = Methods.EnterPlayerName();
                int score = Methods.EnterScore(0, 500);
                players[i] = new Player { Name = name, Score = score };
            }
        }



        //asks user to choose between two values
        static string ChooseBetween(string prompt, string option1, string option2)
        {
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine().ToUpper().Trim();
                if (input == option1 || input == option2)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine($"Error: Please select {option1} or {option2}");
                }
            } while (true);
        }



        //Prints players name and corresponding scores using the answer they chose from ChooseBetween()
        static void PrintPlayers(Player[] players, string chooseBetweenOption)
        {            
            if (chooseBetweenOption == "N")
            {
                SortByName(players);

                foreach(Player p in players)
                {
                    Console.WriteLine($"{p.Name} scored {p.Score} points");
                }
            }

            if (chooseBetweenOption == "S")
            {
                SortByScores(players);

                foreach (Player p in players)
                {
                    Console.WriteLine($"{p.Name} scored {p.Score} points");
                }
            }
        }


        //sorts names alphabetically using character comparison method, inequality operators against "0" and BUBBLE SWAP
        static void SortByName(Player[] players)
        {
            bool doneSwapping;
            do
            {
                doneSwapping = false;
                for (int i = 0; i < players.Length - 1; i++)
                {
                    if (players[i].Name.CompareTo(players[i + 1].Name) > 0)
                    {
                        Player temp = players[i];
                        players[i] = players[i + 1];
                        players[i + 1] = temp;
                        doneSwapping = true;
                    }
                }
            } while (doneSwapping);
        }


        //sorts scores highest to lowest using integer inequality operators and BUBBLE SWAP
        static void SortByScores(Player[] players)
        {
            bool doneSwapping;

            do
            {
                doneSwapping = false;
                for (int i = 0; i < players.Length - 1; i++)
                {
                    if (players[i].Score < players[i + 1].Score)
                    {
                        Player temp = players[i];
                        players[i] = players[i + 1];
                        players[i + 1] = temp;
                        doneSwapping = true;
                    }
                }
            } while (doneSwapping);
        }
    }
}







