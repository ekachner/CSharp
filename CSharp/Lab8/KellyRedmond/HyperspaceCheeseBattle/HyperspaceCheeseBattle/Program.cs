using System;

namespace HyperspaceCheeseBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            string playAgain = "Y";

            Game.TestMode();
            Game.ResetGame();

            do
            {
                Game.PlayGame();
                playAgain = Methods.StringChoice("Would you like to play again? ( Y / N ): ", "Y", "N");
                if (playAgain == "Y")
                {
                    string samePlayers = Methods.StringChoice("Play with the same players? ( Y / N ): ", "Y", "N");
                    if (samePlayers == "N")
                    {
                        Game.ResetGame();
                    }
                    else
                    {
                        Game.ResetXY();
                    }
                }
            } while (playAgain == "Y");
        }

        static void Tests()
        {
            Game.ResetGame();

            //Reset Game Test
            foreach (Player player in Game.players)
            {
                Console.WriteLine(player.ToString());
            }

            Console.WriteLine();

            if (Game.NumberPlayersInGame >= 2 && Game.NumberPlayersInGame <= 4)
            {
                Console.WriteLine($"Number of Players Successful \nNumber of players was {Game.NumberPlayersInGame}");
            }
            else
            {
                Console.WriteLine("Number of Players in Game failed");
            }

            Console.WriteLine();

            //create player array with names then run for loop on array for player turns link in board or create one
            for (int i = 0; i < Game.players.Length; i++)
            {
                string playerName = $"Player {i + 1}";
                Game.players[i] = new Player(playerName, 0, 0);
            }

            for (int i = 0; i < Game.players.Length; i++)
            {
                Game.PlayerTurn(i);
            }

            //show status test
            Game.ShowStatus();
        }
    }
}
