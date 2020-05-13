using System;
using ConsoleBaseball.Player;
using System.Linq;

namespace ConsoleBaseball
{
    class Program
    {
        //creating two teams of 9 players and 
        static void Main(string[] args)
        {
            string designSymbol = "\u20AA";
            string space = " ";
            int horizontalValue = 50;
            var horizontal = Enumerable.Repeat(designSymbol, horizontalValue);
            var vertical = Enumerable.Repeat(space, (horizontalValue-2));

            foreach (string h in horizontal)
            {
                Console.Write(h);
            }
            Console.WriteLine();

            foreach (string v in vertical)
            {
                Console.WriteLine($"{v}                                            {v}");
            }

            foreach (string h in horizontal)
            {
                Console.Write(h);
            }
        }


        static void JasonCode()
        {
            const int TEAM_SIZE = 9;
            Team homeTeam = new Team("Lotte Giants", TEAM_SIZE);
            Team awayTeam = new Team("Hanwha Eagles", TEAM_SIZE);

            for (int i = 0; i < TEAM_SIZE; i++)
            {
                //1380 = starting point for atBats
                //4575 = max bats a player can have
                homeTeam.AddHitter(new Hitter(homeTeam.Name, i.ToString(), 4575, 1380));
                awayTeam.AddHitter(new Hitter(awayTeam.Name, i.ToString(), 4575, 1380));
            }

            BallGame ballGame = new BallGame(homeTeam, awayTeam, 2);
            ballGame.Start();
        }
    }
}

//what do the numbers in 17 and 18 represent