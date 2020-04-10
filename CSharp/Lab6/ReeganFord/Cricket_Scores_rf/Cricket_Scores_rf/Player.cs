using System;

namespace CricketScores
{
    public class Player
    {
        public readonly string FirstName;
        public readonly string LastName;
        public readonly int Score;

        public Player(string firstName, string lastName, int score)
        {
            FirstName = firstName;
            LastName = lastName;
            Score = score;
        }
    }
}