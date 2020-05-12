using System;
namespace ConsoleBaseball.Player
{
    public class Hitter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AtBats { get; set; }
        public int Hits { get; set; }

        public Hitter(string fname, string lname, int atBats, int hits)
        {
            FirstName = fname;
            LastName = lname;
            AtBats = atBats;
            Hits = hits;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public bool DidHitPitch(double pitch)
        {
            return pitch < GetBattingAverage();
        }

        public double GetBattingAverage()
        {
            return (double)Hits/AtBats;
        }

        public override string ToString()
        {
            return $"Up to bat is {GetFullName()}. He/she has {Hits} in his/her {AtBats} AtBats";
        }

    }
}
