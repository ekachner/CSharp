using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Sample bank code for 08120 Week 31 Lab work
// Manages account and bank details
// Rob Miles February 2014

namespace Bank
{
    class Account
    {
        // TODO: Need to add a ToString method and an Equals method to this class

        private string name;
        private string address;
        private decimal balance;
        private int accountNumber;
        private decimal overdraft;

        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }

        public override string ToString()
        {
            return "Account: " + accountNumber +
                    "Name: " + name +
                    "Address: " + address +
                    "Balance: " + balance +
                    "Overdrawn: " + overdraft;

        }

        public override bool Equals(object obj)
        {
            Account compareWith = (Account)obj;
            if (name != compareWith.name ||
                address != compareWith.address ||
                balance != compareWith.balance ||
                accountNumber != compareWith.accountNumber)
            {
                return false;
            }

            return true;
        }

        public decimal GetOverdraft()
        {
            return overdraft;
        }

        public void SetOverdraft(decimal withdrawAmount)
        {
            overdraft = balance - withdrawAmount < 0 ? Math.Abs(balance - withdrawAmount) : 0;


        }

        public bool Save(System.IO.TextWriter textOut)
        {
            try
            {
                textOut.WriteLine(accountNumber);
                textOut.WriteLine(name);
                textOut.WriteLine(address);
                textOut.WriteLine(balance);
                textOut.WriteLine(overdraft);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Save(string filename)
        {
            System.IO.TextWriter textOut = null;
            try
            {
                textOut = new System.IO.StreamWriter(filename);
                Save(textOut);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (textOut != null) textOut.Close();
            }
        }

        public static Account Load(System.IO.TextReader textIn)
        {
            int accountNumber = int.Parse(textIn.ReadLine());
            string nameText = textIn.ReadLine();
            string addressText = textIn.ReadLine();
            string balanceText = textIn.ReadLine();
            decimal balanceValue = decimal.Parse(balanceText);
            string overdrawnText = textIn.ReadLine();
            decimal overdrawnValue = decimal.Parse(overdrawnText);
            return new Account(nameText, addressText, balanceValue, accountNumber);
        }

        public static Account Load(string filename)
        {
            Account result;
            System.IO.TextReader textIn = null;
            try
            {
                textIn = new System.IO.StreamReader(filename);
                result = Load(textIn);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (textIn != null) textIn.Close();
            }
            return result;
        }

        public Account(string inName, string inAddress, decimal inBalance, int inAccountNumber)
        {
            name = inName;
            address = inAddress;
            balance = inBalance;
            overdraft = 0;
            accountNumber = inAccountNumber;
        }

        public override int GetHashCode()
        {
            return accountNumber;
        }
    }

    class Bank
    {
        // TODO: Need to add a ToString method and an Equals method to this class

        private string bankName;

        public string BankName
        {
            get
            {
                return bankName;
            }
        }

        public override string ToString()
        {
            return "Bank Name: " + bankName +
                   "Number of Accounts: " + bankAccounts.Count;
        }

        public override bool Equals(object obj)
        {
            Bank compareWith = (Bank)obj;
            if (bankName != compareWith.bankName ||
                bankAccounts.Count != compareWith.bankAccounts.Count)
            {
                return false;
            }
            foreach (Account a in bankAccounts)
            {
                foreach (Account b in compareWith.bankAccounts)
                {
                    if (a.Equals(b))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        private List<Account> bankAccounts;
        static int newAccountNumber = 1;

        public Bank(string newBankName)
        {
            bankName = newBankName;
            bankAccounts = new List<Account>();
        }

        public Account AddAccount(string inName, string inAddress, decimal inBalance)
        {
            Account result = new Account(inName, inAddress, inBalance, newAccountNumber);
            bankAccounts.Add(result);
            newAccountNumber = newAccountNumber + 1;
            return result;
        }
        public Account FindAccount(int searchNumber)
        {
            foreach (Account a in bankAccounts)
            {
                if (a.AccountNumber == searchNumber)
                    return a;
            }
            return null;
        }

        public bool DeleteAccount(int deleteNumber)
        {
            Account del = FindAccount(deleteNumber);
            if (del != null)
            {
                bankAccounts.Remove(del);
                return true;
            }
            return false;
        }

        public void Save(System.IO.TextWriter textOut)
        {
            textOut.WriteLine(bankName);
            textOut.WriteLine(newAccountNumber);
            textOut.WriteLine(bankAccounts.Count);
            foreach (Account a in bankAccounts)
            {
                if (a != null)
                {
                    a.Save(textOut);
                }
            }
        }

        public void Save(string filename)
        {
            System.IO.TextWriter textOut = null;

            try
            {
                textOut = new System.IO.StreamWriter(filename);
                Save(textOut);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (textOut != null) textOut.Close();
            }
        }

        public static Bank Load(System.IO.TextReader textIn)
        {
            string bankName = textIn.ReadLine();
            Bank result = new Bank(bankName);
            newAccountNumber = int.Parse(textIn.ReadLine());
            int numberOfAccounts = int.Parse(textIn.ReadLine());
            for (int i = 0; i < numberOfAccounts; i++)
            {
                Account a = Account.Load(textIn);
                result.bankAccounts.Add(a);
            }
            return result;
        }

        public static Bank Load(string filename)
        {
            Bank result;
            System.IO.TextReader textIn = null;
            try
            {
                textIn = new System.IO.StreamReader(filename);
                result = Load(textIn);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (textIn != null) textIn.Close();
            }
            return result;
        }

        public override int GetHashCode()
        {
            return newAccountNumber;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Bank friendlyBank = new Bank("The Friendly Bank");

            EqualsTest(friendlyBank);



            string[] firstNames = new string[]            {                "Rob", "Fred", "Jim", "Ethel", "Nigel", "Simon", "Gloria", "Evadne", "Zach"
            };
            string[] lastNames = new string[]            {                "Bloggs", "Smith", "Jones", "Thompson", "Wooster", "Brown", "Acaster", "Berry", "Ackerman"
            };

            Random r = new Random(1);

            string[] streetAddresses = new string[]
            {
                "Red St.", "Blue St.", "Green St.", "Yellow St.", "Black St.", "Orange St.", "White St.", "Array St."
            };
            string[] cityNames = new string[]
            {
                "Cheyenne", "Casper", "Laramie", "Sheridan", "Gillette", "Cody", "Jackson", "Rawlins", "Rock Springs"
            };
            string state = "Wyoming";




            foreach (string lastName in lastNames)
            {
                foreach (string firstName in firstNames)
                {

                    friendlyBank.AddAccount($"{firstName} {lastName}", $"{r.Next(1000, 1999)} {streetAddresses[r.Next(0, 8)]} {cityNames[r.Next(0, 9)]}, {state}", r.Next(-100, 10000));
                }
            }


            Account rob = friendlyBank.AddAccount("Rob", "Hull", 100);
            Console.WriteLine("Account created with account number: " + rob.AccountNumber);
            friendlyBank.Save("test.txt");

            // TODO: Need to compare the loaded bank with the original to make sure they are the same




            Bank loadedBank = Bank.Load("test.txt");


            if (loadedBank.Equals(friendlyBank))
            {
                Console.WriteLine("Same Bank.");
            }
            else
            {
                Console.WriteLine("Different Bank.");
            }

        }

        static void EqualsTest(Bank friendlyBank)
        {
            Account a = friendlyBank.AddAccount("Rob", "Hull", 100);
            Account b = friendlyBank.AddAccount("Rob", "Hull", 100);

            if (a.Equals(b))
            {
                Console.WriteLine("Test passed");
            }
            else
            {
                Console.WriteLine("Test failed");
            }
        }



    }
}
