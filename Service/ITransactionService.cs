using BankingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Service
{
    public interface ITransactionService
    {
        void Deposit(string accountNumber, double amount);
        void Withdraw(string accountNumber, double amount);
        void Transfer(string fromAccountNumber, string toAccountNumberD, double amount);
    }
}
