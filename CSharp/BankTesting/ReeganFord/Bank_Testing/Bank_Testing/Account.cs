using System;

namespace Bank_Testing
{
    public class Account
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public decimal Balance { get; private set; }
        public decimal Overdraft { get; private set; }

        public int AccountNumber { get; }

        public override string ToString()
        {
            return $"Name: {Name} \nBalance: {Balance} \nAddress: {Address}";
        }

        public static bool AccountsEqual(Account account1, Account account2)
        {
            if(account1.Name == account2.Name
                && account1.Address == account2.Address
                && account1.Balance == account2.Balance
               )
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool Save(System.IO.TextWriter textOut)
        {
            try
            {
                textOut.WriteLine(AccountNumber);
                textOut.WriteLine(Name);
                textOut.WriteLine(Address);
                textOut.WriteLine(Balance);
                textOut.WriteLine(Overdraft);
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
            return new Account(nameText, addressText, balanceValue, accountNumber, overdraftValue);
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

        public Account(string inName, string inAddress, decimal inBalance, int inAccountNumber, decimal overdraft)
        {
            Name = inName;
            Address = inAddress;
            Balance = inBalance;
            AccountNumber = inAccountNumber;
            Overdraft = overdraft;
        }
    }
}
