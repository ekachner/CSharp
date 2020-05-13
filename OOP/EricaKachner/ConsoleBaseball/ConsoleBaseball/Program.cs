using System;
using ConsoleBaseball.Player;

namespace ConsoleBaseball
{
    class Program
    {
        static void Main(string[] args)
        {
            const int TEAM_SIZE = 9;
            Team homeTeam = new Team("Lotte Giants", TEAM_SIZE);
            Team awayTeam = new Team("Hanwha Eagles", TEAM_SIZE);

            for(int i = 0; i < TEAM_SIZE; i++)
            {
                homeTeam.AddHitter(new Hitter(homeTeam.Name, i.ToString(), 4575, 1380));
                awayTeam.AddHitter(new Hitter(awayTeam.Name, i.ToString(), 4575, 1380));
            }

            BallGame ballGame = new BallGame(homeTeam, awayTeam, 2);
            ballGame.Start();
        }
    }
}
