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

        public string Name
        {
            get
            {
                return name;
            }
        }


        static decimal withdrawal;
        public decimal Overdraft
        {
            get
            {
                return overdraft;
            }
            set
            {
                decimal newBalance = balance - withdrawal;
                overdraft = newBalance < 0 ? newBalance : 0;
            }
        }


  //      public decimal GetOverdraft()
		//{

		//}

  //      public decimal SetOverdraft()
		//{
  //          decimal newBalance = balance - withdrawal;
  //          overdraft = newBalance < 0 ? newBalance : 0;
  //      }



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
            string overdraftText = textIn.ReadLine();
            decimal overdraftValue = decimal.Parse(overdraftText);

            return new Account(nameText, addressText, balanceValue, overdraftValue, accountNumber);
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

        public override string ToString()
        {
            return $"Account Details:\n\tName: {name}\n\tAddress: {address}" +
                $"\n\tBalance: {balance}\n\tOverdraft: {overdraft}\n\tAccount Number: {accountNumber}";
        }

        public override bool Equals(object obj)
        {
            Account compareWith = (Account)obj;
            if ((name != compareWith.name) ||
                (address != compareWith.address) ||
                (balance != compareWith.balance) ||
                (overdraft != compareWith.overdraft) ||
                (accountNumber != compareWith.accountNumber))
            {
                Console.WriteLine("Account Equals() = false");
                return false;
            }
            Console.WriteLine("Account Equals() = true");
            return true;
        }      
    }





    class Bank
    {
        private string bankName;
       
        public string BankName
        {
            get
            {
                return bankName;
            }
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

        public override string ToString()
        {
            return $"Bank Details:\n\tBank Name: {bankName}\n\tNumber of Accounts: {bankAccounts.Count}";
        }

        public override bool Equals(object obj)
        {
            Bank compareWith = (Bank)obj;
            if ((bankName != compareWith.bankName) ||
                (bankAccounts.Count != compareWith.bankAccounts.Count))
            {
                return false;
            }

            foreach (Account a in bankAccounts)
            {
                foreach (Account b in compareWith.bankAccounts)
                {
                    if (a.Equals(b))
                    {
                        Console.WriteLine("In Bank Equals() : These values are the same");
                        return true;
                    }
                }
            }
            return false;
        }        

    }



    class Program
    {
        static void Main(string[] args)
        {
            Bank friendlyBank = new Bank("The Friendly Bank");

            // TODO: Need to add some code that will create a large number of "fake" accounts
            GenerateAccounts(friendlyBank);

            Account pickle = friendlyBank.AddAccount("Pickle", "Cheyenne", 50M, 0);
            //Console.WriteLine("Account created with account number: " + pickle.AccountNumber);
            Account rick = friendlyBank.AddAccount("Rick", "Cheyenne", 500M, 0);
            //Console.WriteLine("Account created with account number: " + rick.AccountNumber);

            TestingEquals(pickle, rick);


            friendlyBank.Save("test.txt");

            Bank loadedBank = Bank.Load("test.txt");

            Console.WriteLine((loadedBank.Equals(friendlyBank)) ? "Checking Loaded Bank and Friendly Bank = Same Bank" : "Checking Loaded Bank and Friendly Bank = Different Bank");
        }



        static void TestingEquals(Account a, Account b)
        {
            if (a.Equals(b))
            {
                Console.WriteLine($"TestingEquals() Account {a.Name} is SAME as account {b.Name}");
            }
            else
            {
                Console.WriteLine($"TestingEquals() Account {a.Name} is DIFFERENT from account {b.Name}");
            }
        }



        static void GenerateAccounts(Bank bank)
        {
            string[] firstNames = new string[] { "Jimmy", "Dean", "Bean", "Adam", "Benjamin",
                "Caleb", "Daniel", "Ephraim", "Frankincense", "Giddeon" };
            string[] lastNames = new string[] { "Anderson", "Kachner", "Corbet", "Ahn",
                "Hegstrom", "Pontapee", "White", "Lasme", "Smith" };
            string[] address = new string[] { "Cheyenne", "Laramie", "Colorado Springs",
                "Geneva", "Gingins", "Hinesville", "Tacoma", "Stuttgart" };
            Random balance = new Random(1);

            foreach (string firstName in firstNames)
            {
                foreach (string lastName in lastNames)
                {
                    string fullName = firstName + " " + lastName;
                    foreach (string addy in address)
                    {
                        Account a = bank.AddAccount(fullName, addy, balance.Next(-100, 10000));
                        Console.WriteLine(a.ToString());
                    }
                }
            }
        }


        //how to create a test bank with 80 accounts 
        //Bank testBank = new Bank[80];
        //GenerateAccounts(testBank);
        //get and set overBalance methods (book pg.134  VS pdf pg.4)
        //issues with saving code. How to save everything to my name file in class-fullStack

    }
}

