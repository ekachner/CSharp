using System;
namespace Hyperspace_Cheese_Battle
{
    public class Player
    {
        public string Name;
        public int X;
        public int Y;

        public static bool InvalidCoordinates(int x)
        {
            if(x > 7 || x < 0)
            {
                Console.WriteLine("This would take you off the board! Please wait until your next turn.");
                return true;
            } else
            {
                return false;
            }
        }

        public static void ShowStatus(Player [] players, int round)
        {
            Console.Clear();
            Console.WriteLine("HYPERSPACE CHEESE BATTLE STATUS REPORT");
            Console.WriteLine($"AFTER ROUND {round}:");

            foreach(var Player in players)
            {
                Console.WriteLine($"{Player.Name}:    Current Position: ({Player.X}, {Player.Y})");
            }
        }
    }
}
