using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Model;

namespace BankingSystem.Repository
{
    public interface IBankRepository
    {
        BankAccount GetAccount(string accountNumber);
        List<BankAccount> GetAllAccounts();
        List<BankAccount> GetAccounts(string customerID);
        double GetBalance(string AccountNumber);
        void AddAccount(BankAccount account);
    }
}
