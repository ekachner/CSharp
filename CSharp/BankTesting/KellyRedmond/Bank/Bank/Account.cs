using System;
namespace Bank
{
    public class Account
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

        public decimal GetOverdraft(decimal outAmount)
        {
            overdraft = balance - outAmount;
            return overdraft;
        }

        public decimal SetOverdraft(decimal outAmount)
        {
            overdraft = GetOverdraft(outAmount) < 0 ? overdraft : 0;
            balance -= outAmount;
            return overdraft;
        }

        public override string ToString()
        {
            return $"Acccount Information\n\tHolder:  {name}\n\tAddress:  {address}\n\tBalance:  {balance:C}\n\tOverdrawn:  {overdraft:C}\n\tAccount Number:  {accountNumber}";
        }

        public override bool Equals(object obj)
        {
            Account compareWith = (Account)obj;
            if (
                name != compareWith.name ||
                address != compareWith.address ||
                balance != compareWith.balance ||
                overdraft != compareWith.overdraft ||
                accountNumber != compareWith.accountNumber 
                )
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return accountNumber;
        }
    }
}
