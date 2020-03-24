using System;
using System.Collections.Generic;

namespace boxing_weightclass1
{
    class Program
    {
        public static void Main()
        {
            List<WeightClass> ClassList = WeightClass.ClassList();

            Console.Write("Please enter your weight (in pounds): ");
            string weightInput = Console.ReadLine();
            int weight = int.Parse(weightInput);
            foreach (var WeightClass in ClassList)
            {
                if (weight >= WeightClass.MinRange && weight <= WeightClass.MaxRange)
                {
                    Console.WriteLine("Your weight class is: \"{0}\": {1} lbs - {2} lbs", WeightClass.ClassName, WeightClass.MinRange, WeightClass.MaxRange);
                }
            }

        }

        public class WeightClass
        {
            public readonly string ClassName;
            public readonly int MinRange;
            public readonly int MaxRange;

            public WeightClass(string className, int minRange, int maxRange)
            {
                ClassName = className;
                MinRange = minRange;
                MaxRange = maxRange;
            }

            public static List<WeightClass> ClassList()
            {
                List<WeightClass> ClassList = new List<WeightClass>();

                ClassList.Add(new WeightClass("Strawweight", 90, 105));
                ClassList.Add(new WeightClass("Junior Flyweight", 106, 108));
                ClassList.Add(new WeightClass("Flyweight", 109, 112));
                ClassList.Add(new WeightClass("Junior Bantamweight", 113, 115));
                ClassList.Add(new WeightClass("Bantamweight", 116, 118));
                ClassList.Add(new WeightClass("Junior Featherweight", 119, 122));
                ClassList.Add(new WeightClass("Featherweight", 123, 126));
                ClassList.Add(new WeightClass("Junior Lightweight", 127, 130));
                ClassList.Add(new WeightClass("Lightweight", 131, 135));
                ClassList.Add(new WeightClass("Junior Welterweight", 136, 140));
                ClassList.Add(new WeightClass("Welterweight", 141, 147));
                ClassList.Add(new WeightClass("Junior Middleweight", 148, 154));
                ClassList.Add(new WeightClass("Middleweight", 155, 160));
                ClassList.Add(new WeightClass("Super Middleweight", 161, 168));
                ClassList.Add(new WeightClass("Light Heavyweight", 169, 175));
                ClassList.Add(new WeightClass("Cruiserweight", 176, 190));
                ClassList.Add(new WeightClass("Heavyweight", 191, 400));

                return ClassList;
            }
        }
    }
}
