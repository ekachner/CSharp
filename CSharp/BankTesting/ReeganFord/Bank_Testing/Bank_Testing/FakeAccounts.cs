using System;
using System.Collections.Generic;

namespace Bank_Testing
{
    public class FakeAccounts
    {
        public static List<Account> CreateAccounts(Bank bank, int numOfAccounts)
        {
            string[] FirstNames = new string[] { "Rob", "Fred", "Jim", "Ethel", "Nigel", "Simon", "Gloria", "Evande" };
            string[] LastNames = new string[] { "Bloggs", "Smith", "Jones", "Thomson", "Wooster", "Brown", "Acaster", "Berry" };
            string[] StreetAddresses = new string[] { "123 Dunn Avenue", "442 1st Street", "9980 Murphy Drive", "1773 Jones Street", "913 12th Street", "110 6th Street", "801 Sanders Drive" };
            string[] Towns = new string[] { "Rawlins, WY", "Laramie, WY", "Cheyenne, WY", "Douglas, WY", "Sheridan, WY", "Casper, WY", "Saratoga, WY" };

            Random rand = new Random();

            for (int i = 0; i < numOfAccounts; i++)
            {
                int randFirst = rand.Next(0, FirstNames.Length);
                int randLast = rand.Next(0, LastNames.Length);
                int randAddress = rand.Next(0, StreetAddresses.Length);
                int randTown = rand.Next(0, Towns.Length);
                int randBalance = rand.Next(-100, 10000);

                string firstName = FirstNames[randFirst];
                string lastName = LastNames[randLast];
                string address = StreetAddresses[randAddress];
                string town = Towns[randTown];
                bank.AddAccount($"{firstName} {lastName}", $"{address}, {town}", randBalance);
            }

            return bank.bankAccounts;
        }
    }
}
