using System;

namespace Hyperspace_Cheese_Battle
{
    class Program
    {
        static void Main()
        {
            bool anotherGame = true;
            do
            {
                Player[] players = Game.StartGame();
                Game.Turn(players);

            } while (anotherGame == true);
        }
    }
}
