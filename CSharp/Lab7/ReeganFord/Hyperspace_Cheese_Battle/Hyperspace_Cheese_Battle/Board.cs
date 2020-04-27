using System;
namespace Hyperspace_Cheese_Battle
{
    public class Board
    {
        public static int[,] CellDirections = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1},
            {3, 3, 1, 0, 1, 1, 2, 2},
            {3, 3, 1, 3, 2, 3, 2, 2},
            {3, 3, 1, 3, 1, 1, 2, 2},
            {3, 3, 1, 3, 1, 1, 2, 2},
            {3, 3, 3, 3, 1, 1, 2, 2},
            {3, 3, 1, 0, 1, 3, 2, 2},
            {0, 3, 3, 3, 3, 3, 0, 4}
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
    }
}