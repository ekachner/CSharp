using System;
using System.Collections.Generic;

namespace BoxerWeightClass
{
    class Program
    {
        public static void Main()
        {
            List<WeightClass> classList = new List<WeightClass>();
            classList.Add(new WeightClass("Strawweight", 90, 105));
            classList.Add(new WeightClass("Junior Flyweight", 106, 108));
            classList.Add(new WeightClass("Flyweight", 109, 112));
            classList.Add(new WeightClass("Junior Bantamweight", 113, 115));
            classList.Add(new WeightClass("Bantamweight", 116, 118));
            classList.Add(new WeightClass("Junior Featherweight", 119, 122));
            classList.Add(new WeightClass("Featherweight", 123, 126));
            classList.Add(new WeightClass("Junior Lightweight", 127, 130));
            classList.Add(new WeightClass("Lightweight", 131, 135));
            classList.Add(new WeightClass("Junior Welterweight", 136, 140));
            classList.Add(new WeightClass("Welterweight", 141, 147));
            classList.Add(new WeightClass("Junior Middleweight", 148, 154));
            classList.Add(new WeightClass("Middleweight", 155, 160));
            classList.Add(new WeightClass("Super Middleweight", 161, 168));
            classList.Add(new WeightClass("Light Heavyweight", 169, 175));
            classList.Add(new WeightClass("Cruiserweight", 176, 190));
            classList.Add(new WeightClass("Heavyweight", 191, 400));

            Console.Write("Please enter your weight (in pounds): ");
            string weightInput = Console.ReadLine();
            int weight = int.Parse(weightInput);
            foreach (var WeightClass in classList)
            {
                if (weight >= WeightClass.minRange && weight <= WeightClass.maxRange)
                {
                    Console.WriteLine("Your weight class is: \"{0}\": {1} lbs - {2} lbs", WeightClass.className, WeightClass.minRange, WeightClass.maxRange);
                }
            }

        }

        public class WeightClass
        {
            public string className;
            public int minRange;
            public int maxRange;

            public WeightClass(string className, int minRange, int maxRange)
            {
                this.className = className;
                this.minRange = minRange;
                this.maxRange = maxRange;
            }
        }
    }
}
