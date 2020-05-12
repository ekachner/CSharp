using System;
using System.Collections.Generic;
using ConsoleBaseball.Player;

namespace ConsoleBaseball
{
    public class BallGame
    {
        private readonly Team home;
        private readonly Team away;
        private readonly Pitcher pitcher;
        private readonly int maxInnings;
        public int Inning { get; private set; }
        public InningHalf InningHalf { get; private set; }
        public int Outs { get; private set; }
        public int[,] ScoreBoard { get; private set; }
        public List<Hitter> BaseRunners { get; private set; }

        public BallGame(Team homeTeam, Team awayTeam, int innings)
        {
            home = homeTeam;
            away = awayTeam;
            maxInnings = innings;
            pitcher = new Pitcher();
            Inning = 1;
            InningHalf = InningHalf.Top;
            Outs = 0;
            ScoreBoard = new int[maxInnings, 2];
            BaseRunners = new List<Hitter>();
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Console Baseball.");
            Console.WriteLine($"I'm Duane Kuiper and today the {away.Name} visit the {home.Name}.");
            Console.WriteLine("PLAAAAY BALL! Press any key to continue.");
            Console.ReadLine();
            while(Inning <= maxInnings)
            {
                PlayHalfInning();
            }
            (int homeScore, int awayScore) score = GetGameScore();
            Console.WriteLine($"That's all for Console Baseball. The final score is {away.Name} {score.awayScore}, {home.Name} {score.homeScore}");
            Console.ReadLine();
        }

        private void PlayHalfInning()
        {
            Team team = GetTeamAtBat();
            while (Outs < 3)
            {
                Console.Clear();
                Hitter hitter = team.GetNextHitter();
                Console.WriteLine(hitter);
                double pitch = pitcher.ThrowPitch();
                Console.WriteLine("The pitcher winds up and delivers...type swing to see if you can hit it");
                Console.ReadLine();
                bool isHit = hitter.DidHitPitch(pitch);
                if (isHit)
                {
                    Console.WriteLine("It's a hit!");
                    MoveBaseRunners(hitter);
                }
                else
                {
                    Outs++;
                    Console.WriteLine("You're out");
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }

            InningHalf = InningHalf == InningHalf.Top ? InningHalf.Bottom : InningHalf.Top;
            Inning = InningHalf == InningHalf.Top ? Inning + 1 : Inning;
            Outs = 0;
            BaseRunners.Clear();
            ShowScoreBoard();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        private void ShowScoreBoard()
        {
            (int homeScore, int awayScore) score = GetGameScore(); 
            string inningHalfString = InningHalf == InningHalf.Top ? "top of" : "bottom of";
            Console.WriteLine($"Its the {inningHalfString} inning {Inning}. There are {Outs} outs and the score is {away.Name}: {score.awayScore}. {home.Name}: {score.homeScore}.");
        }

        private (int homeScore, int awayScore) GetGameScore()
        {
            int homeTeamScore = 0;
            int awayTeamScore = 0;
            for (int i = 0; i < ScoreBoard.GetLength(0); i++)
            {
                awayTeamScore += ScoreBoard[i, 0];
                homeTeamScore += ScoreBoard[i, 1];
            }

            return (homeScore: homeTeamScore, awayScore: awayTeamScore);
        }

        private Team GetTeamAtBat()
        {
            if (InningHalf.Top == InningHalf)
            {
                return away;
            }

            return home;
        }

        private void MoveBaseRunners(Hitter hitter)
        {
            BaseRunners.Add(hitter);
            int baseRunners = BaseRunners.Count;
            if (baseRunners == 4)
            {
                AddRun();
                BaseRunners.RemoveAt(0);
            }
        }

        private void AddRun()
        {
            ScoreBoard[Inning - 1, (int)InningHalf]++;
            Console.Beep();
            ShowScoreBoard();
        }

    }

    public enum InningHalf
    {
        Top,
        Bottom
    }
}
