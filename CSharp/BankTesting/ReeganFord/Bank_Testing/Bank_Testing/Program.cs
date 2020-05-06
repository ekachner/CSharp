using System;
using System.Collections.Generic;

namespace Bank_Testing
{
    class Program
    {
        static void Main()
        {
            //Creates a bank with 80 randomly generated accounts
            Bank FakeBank = new Bank("Fake Bank");
            List<Account> accounts = FakeAccounts.CreateAccounts(FakeBank, 80);

            Account a = accounts[0];
            Console.WriteLine(Account.AccountString(a));

            //Accounts are equal test
            Bank bank1 = new Bank("Bank #1");
            Bank bank2 = new Bank("Bank #2");
            List<Account> bank1Accounts = FakeAccounts.CreateAccounts(bank1, 20);
            List<Account> bank2Accounts = FakeAccounts.CreateAccounts(bank2, 20);

            Account b = bank1Accounts[17];
            Account c = bank2Accounts[17];

            bool accountsEqual = Account.AccountsEqual(b, c);
            CompareAccounts.ReturnEquality(accountsEqual);

            c = b;
            accountsEqual = Account.AccountsEqual(b, c);
            CompareAccounts.ReturnEquality(accountsEqual);

            //Banks are equal test
            Bank.BanksEqual(bank1, bank2);

            //ToString tests for Account and Bank objects
            Console.WriteLine(Bank.BankString(bank1));
            Console.WriteLine(Account.AccountString(b));
            Console.WriteLine(Account.AccountString(c));

            bank1.Save("test.txt");
            bank2.Save("test.txt");

            Bank loadedBank = Bank.Load("test.txt");
        }
    }
}
