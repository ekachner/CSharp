using System;
using DiceLibrary;

namespace Chucker
{
    public class FairDice : DiceClass
    {
        Random randomDice = new Random();

        public new int IntSpots()
        {
            int spots = randomDice.Next(1, 7);
            return spots;
        }
    }
}
