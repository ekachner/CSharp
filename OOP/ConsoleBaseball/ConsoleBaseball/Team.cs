﻿using System;
using System.Diagnostics;
using ConsoleBaseball.Player;

namespace ConsoleBaseball
{
    public class Team
    {
        public string Name { get; private set; }
        public Hitter[] Hitters { get; private set; }
        public int MaxHitters;
        private int head;
        private int tail;

        //constructor for team
        public Team(string name, int teamSize = 9)
        {
            Name = name;
            MaxHitters = teamSize;
            Hitters = new Hitter[MaxHitters];
            head = 0;
            tail = 0;
        }

        public void AddHitter(Hitter hitter)
        {
            //tail keeps track of where the end of the array is for the purposes of adding a new hitter
            Debug.Assert(tail < MaxHitters);
            Hitters[tail] = hitter;
            tail++;
        }

        public Hitter GetNextHitter()
        {
            //head keeps track of the position of the current hitter
            Hitter hitter = Hitters[head];
            head = (head + 1) == MaxHitters ? 0 : head + 1;
            return hitter;
        }

        public void Reset()
        {
            head = 0;
        }
    }
}
