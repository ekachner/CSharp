using System;
namespace ConsoleBaseball.Player
{
    public class Pitcher
    {
        private readonly Random random;

        public Pitcher()
        {
            random = new Random();
        }

        public double ThrowPitch()
        {
            return random.NextDouble();
        }
    }
}
