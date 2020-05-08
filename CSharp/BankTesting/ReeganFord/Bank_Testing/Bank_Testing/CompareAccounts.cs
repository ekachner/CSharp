using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

namespace Bank_Testing
{
    public class CompareAccounts : IEqualityComparer<Account>
    {
        public bool Equals(Account account1, Account account2)
        {
            if (account1.Name == account2.Name && account1.Address == account2.Address && account1.Balance == account2.Balance)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int GetHashCode(Account account)
        {
            return account.GetHashCode();
        }

        public bool Equals([AllowNull] Account other)
        {
            throw new NotImplementedException();
        }

        public static void ReturnEquality(bool accountsEqual)
        {
            if (accountsEqual)
            {
                Console.WriteLine("Accounts are equal.");
            }
            else
            {
                Console.WriteLine("Accounts are not equal.");
            }
        }
    }
}
