using System;

namespace CricketScores
{
    class Program
    {
        static void Main()
        {
            var Team = Player.EnterPlayerInfo();

            Console.Clear();
            Console.WriteLine("Team roster:");

            ListQueries.Roster(Team);

            ListQueries.SortList(Team);
        }
    }
}
