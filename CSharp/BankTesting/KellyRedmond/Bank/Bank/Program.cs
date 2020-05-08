using System;

// Sample bank code for 08120 Week 31 Lab work
// Manages account and bank details
// Rob Miles February 2014

namespace Bank
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Bank friendlyBank = new Bank("The Friendly Bank");

            EqualsTests(friendlyBank);

            friendlyBank = TestData.CreateTestAccounts(friendlyBank);

            Account rob = friendlyBank.AddAccount("Rob", "Hull", 100);
            Console.WriteLine("Account created with account number: " + rob.AccountNumber);

            Account bob = friendlyBank.AddAccount("Bob", "Laramie", 100);
            bob.SetOverdraft(200);
            Console.WriteLine(bob.ToString());

            friendlyBank.Save("test.txt");

            Bank loadedBank = Bank.Load("test.txt");

            string test = (loadedBank.Equals(friendlyBank)) ? "Test Passed: Same Bank" : "Test Failed: Different Bank";
            Console.WriteLine(test);
        }

        static void EqualsTests(Bank friendlyBank)
        {
            Account a = friendlyBank.AddAccount("Rob", "Hull", 100);
            Account b = friendlyBank.AddAccount("Rob", "Hull", 100);

            string test = (a.Equals(b)) ? "Test Passed: Same Account" : "Test Failed: Different Account";
            Console.WriteLine(test);
        }
    }
}
