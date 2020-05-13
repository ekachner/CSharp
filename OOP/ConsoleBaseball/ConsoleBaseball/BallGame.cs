using System;
using System.Collections.Generic;
using ConsoleBaseball.Player;

namespace ConsoleBaseball
{
    public class BallGame
    {
        private readonly Team home;
        private readonly Team away;
        private readonly Pitcher pitcher;   //Why is Pitcher a readonly? *
        private readonly int maxInnings;
        public int Inning { get; private set; }
        public InningHalf InningHalf { get; private set; }  //why is this it's own type? *
        public int Outs { get; private set; }
        public int[,] ScoreBoard { get; private set; }
        public List<Hitter> BaseRunners { get; private set; }

        //ballgame constructor
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

        //plays a half inning
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
            //tuple scores
            (int homeScore, int awayScore) score = GetGameScore();
            Console.WriteLine($"That's all for Console Baseball. The final score is {away.Name} {score.awayScore}, {home.Name} {score.homeScore}");
            Console.ReadLine();
        }

        private void PlayHalfInning()
        {
            Team team = GetTeamAtBat();  //based on inning half; top or bottom
            while (Outs < 3)
            {
                Console.Clear();
                Hitter hitter = team.GetNextHitter();
                Console.WriteLine(hitter);
                double pitch = pitcher.ThrowPitch();
                Console.WriteLine("The pitcher winds up and delivers...type \"swing\" to see if you can hit it");
                Console.ReadLine();   //here shouldn't this be done three times before out? proper strikeout *
                bool isHit = hitter.DidHitPitch(pitch);    //does this mean the pitcher only pitches once? Because batter gets out if he swings and misses three times. *
                if (isHit)
                {
                    Console.WriteLine("It's a hit!");
                    MoveBaseRunners(hitter);
                }
                else   //if this, then here should be given two more pitches before out right? *
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

        //states wheather it's the top or bottom of the __ inning
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
            for (int i = 0; i < ScoreBoard.GetLength(0); i++)  //GetLength vs. Length * multi dimensional array
            {
                awayTeamScore += ScoreBoard[i, 0];
                homeTeamScore += ScoreBoard[i, 1]; 
            }

            return (homeScore: homeTeamScore, awayScore: awayTeamScore); //named tuple
        }

        //top = visitors bat first(offense) ; bottom = visitors in defense 
        private Team GetTeamAtBat()
        {
            if (InningHalf.Top == InningHalf)
            {
                return away;
            }

            return home;
        }

        //baseRunners set to total number of hitters? *
        private void MoveBaseRunners(Hitter hitter)
        {
            BaseRunners.Add(hitter);
            int baseRunners = BaseRunners.Count;
            if (baseRunners == 4)
            {
                AddRun();
                BaseRunners.RemoveAt(0);   //remove baserunner from beginning of list "index[0]"
            }
        }

        private void AddRun()
        {
            ScoreBoard[Inning - 1, (int)InningHalf]++;  //Inning - 1 : converting back to index value
            Console.Beep();
            ShowScoreBoard();
        }

    }

    //top = visitors bat first(offense) ; bottom = visitors in defense
    public enum InningHalf
    {
        Top,
        Bottom
    }
}

