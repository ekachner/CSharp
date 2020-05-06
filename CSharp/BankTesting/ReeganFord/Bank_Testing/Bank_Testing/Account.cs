﻿using System;

namespace Bank_Testing
{
    public class Account
    {
        public string name;
        public string address;
        public decimal balance;
        public decimal Overdraft { get; set; }

        public int AccountNumber { get; }

        public static string AccountString(Account account)
        {
            string name = account.name;
            string address = account.address;
            string balance = account.balance.ToString("0.00");
            if(account.Overdraft < 0)
            {
                return $"You have insufficient funds. \nName: {name} \nBalance: {balance} \nAddress: {address}";
            } else
            {
                return $"Name: {name} \nBalance: {balance} \nAddress: {address}";
            }
        }

        public static bool AccountsEqual(Account account1, Account account2)
        {
            if(account1.name == account2.name
                && account1.address == account2.address
                && account1.balance == account2.balance
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
                textOut.WriteLine(name);
                textOut.WriteLine(address);
                textOut.WriteLine(balance);
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
            name = inName;
            address = inAddress;
            balance = inBalance;
            AccountNumber = inAccountNumber;
            Overdraft = overdraft;
        }
    }
}
