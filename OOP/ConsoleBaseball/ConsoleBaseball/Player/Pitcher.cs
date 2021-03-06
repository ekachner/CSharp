﻿using System;
namespace ConsoleBaseball.Player
{
    public class Pitcher
    {
        private readonly Random random;

        public Pitcher()
        {
            random = new Random();
        }

        //gives random double value to represent the quality of the pitch. higher value = better, lower value = poor
        public double ThrowPitch()
        {
            return random.NextDouble();
        }
    }
}
