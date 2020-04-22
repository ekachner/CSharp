using System;

namespace HyperspaceCheeseBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.ResetGame();

            //Reset Game Test
            foreach(Player player in Game.players)
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
            for(int i = 0; i < Game.players.Length; i++)
            {
                string playerName = $"Player {i + 1}";
                Game.players[i] = new Player(playerName, 0, 0);
            }

            for (int i = 0; i < Game.players.Length; i++)
            {
                Game.PlayerTurn(i);
          
            }

        }
    }
}

