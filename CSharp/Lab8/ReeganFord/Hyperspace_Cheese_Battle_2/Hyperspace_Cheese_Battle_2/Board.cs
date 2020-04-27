using System;
namespace Hyperspace_Cheese_Battle
{
    public class Board
    {
        public static int[,] CellDirections = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1},
            {3, 3, 4, 0, 1, 1, 2, 2},
            {3, 3, 1, 3, 2, 4, 2, 2},
            {3, 3, 1, 3, 1, 1, 2, 2},
            {3, 4, 1, 3, 1, 1, 2, 2},
            {3, 3, 3, 3, 1, 4, 2, 2},
            {3, 3, 1, 0, 1, 3, 2, 2},
            {0, 3, 3, 3, 3, 3, 0, 5}
        };

        public static bool RocketInSquare(Player[] players)
        {
            for(int i = 0; i < players.Length - 1; i++)
            {
                if(players[i].X == players[i + 1].X && players[i].Y == players[i + 1].Y)
                {
                    return true;
                }
            }
            return false;
        }

        public static void CheeseSquare(Player[] players, Player player)
        {
            Console.WriteLine("You've landed on a CHEESE square!");

            int question1 = Inputs.ReadNumber("Would you like to \n\n" +
                "1. Use your cheese powers for good, and roll the dice again, or \n\n" +
                "2. Use your cheese powers for evil, and send one player back to the beginning?", 1, 2);
            if (question1 == 1)
            {
                Player.PlayerTurn(player, players, CellDirections, true);
            }
            else
            {
                Console.WriteLine("You have chosen the path of evil. Which player would you like to send to (0, 0)? ");
                Player.PrintPlayerNames(players);
                int question2 = Inputs.ReadNumber("(select number of player): ", 1, players.Length);
                players[question2 - 1].X = 0;
                players[question2 - 1].Y = 0;
            }
        }
    }
}