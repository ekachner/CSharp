using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

namespace Bank_Testing
{
    public class CompareAccounts : IEqualityComparer<Account>
    {
        public bool Equals(Account account1, Account account2)
        {
            if (account1.name == account2.name && account1.address == account2.address && account1.balance == account2.balance)
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
