using System;

namespace HyperspaceCheeseBattle
{
    public struct Player
    {
        public string Name;
        public int X;
        public int Y;

        public Player(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"Player Name: {Name}\t\tStarting Position: {X}, {Y}";
        }

        public void PlayerPosition()
        {
            Console.WriteLine($"{Name} is on square ({X}, {Y})");
        }

        public bool NameEquals(object obj)
        {
            Player p = (Player)obj;
            if (p.Name == Name)
            {
                return true;
            }
            else
            {
                return false;
            } }
    }
}
