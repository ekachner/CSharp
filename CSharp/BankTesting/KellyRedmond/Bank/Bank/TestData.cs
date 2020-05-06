using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank
{
    public class TestData
    {
        static List<string> firstNames = new List<string>
        {
            "Rob", "Fred", "Jim", "Ethel", "Nigel", "Simon", "Gloria", "Evadne"
        };

        static List<string> lastNames = new List<string>
        {
            "Bloggs", "Smith", "Jones", "Thompson", "Wooster", "Brown", "Acaster", "Berry", "Ackerman", ""
        };

        static List<string> towns = new List<string>
        {
            "Cheyenne", "Burns", "Pine Bluffs", "Chugwater", "Torrington", "Yoder"
        };

        static Random r = new Random(1);

        public static Bank CreateTestAccounts(Bank sampleBank)
        {
            foreach (string fname in firstNames)
            {
                foreach (string lname in lastNames)
                {
                    string randomTown = towns.OrderBy(x => Guid.NewGuid()).Take(1).ToString();
                    sampleBank.AddAccount(fname + lname, randomTown, r.Next(-100, 100000));
                }
            }

            return sampleBank;
        }
    }
}
