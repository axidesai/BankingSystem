using BankingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Repository
{
    public class BankRepository : IBankRepository
    {
        private List<BankAccount> _accounts;
        public BankRepository()
        { 
               _accounts = [];
        }

        public BankAccount GetAccount(string accountNumber)
        {
            return _accounts.FirstOrDefault(acc => acc.AccountNumber == accountNumber);
         }

        public List<BankAccount> GetAccounts(string customerID)
        {
            return _accounts.FindAll(acc=> acc.CustomerID==customerID);
        }

        public List<BankAccount> GetAllAccounts()
        {
            return _accounts.ToList();
        }

        public double GetBalance(string accountID)
        {
            var account = _accounts.FirstOrDefault(acc => acc.AccountNumber == accountID);

            if (account != null)
            {
                return account.Balance;
            }
            else
            {
                // Return a default value (e.g., 0.0) when the account is not found.
                return 0.0;
            }
        }
        public void AddAccount(BankAccount account)
        {
            if (account != null)
            {
                _accounts.Add(account);
            }
        }
    }
}
