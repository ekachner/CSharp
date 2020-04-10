using System;

namespace CricketPlayerScores
{
    class Program
    {
        static void Main()
        {
            Player[] players = Team.PlayerEntry();
            Sort.PickSort(players);
        }
    }
}