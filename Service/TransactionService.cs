
using BankingSystem.Model;
using BankingSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Transactions;

namespace BankingSystem.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly IBankRepository _repository;
        public TransactionService(IBankRepository repository) {
            _repository = repository;
        }
        public void Deposit(string accountNumber, double amount)
        {
            Console.WriteLine("**************** Deposit transaction processing ****************************************");

            if (IsValid(accountNumber,amount))
            {
                BankAccount account = _repository.GetAccount(accountNumber);

                if (account != null)
                {
                    account.Balance += amount;
                    Console.WriteLine($"Deposited {amount:C} to Account {account.AccountNumber}. *** New balance: {account.Balance:C}");

                }
                else
                {
                    Console.WriteLine($"Account number {accountNumber} not found.");
                }
            }
        }
        public void Transfer(string sourceAccountNumber, string receiptAccountNumber, double amount)
        {
            Console.WriteLine("**************** Transfer transaction processing ****************************************");

            if (string.IsNullOrEmpty(sourceAccountNumber)|| string.IsNullOrEmpty(receiptAccountNumber))
            {
                Console.WriteLine("Invalid source or destination account.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Transfer amount must be greater than zero.");
                return;
            }

            BankAccount sourceAccount = _repository.GetAccount(sourceAccountNumber);
            BankAccount destinationAccount = _repository.GetAccount(receiptAccountNumber);

            if (sourceAccount == null || destinationAccount == null)
            {
                Console.WriteLine("Invalid source or destination account.");
                return;
            }

            if (IsValidWithdrwal(sourceAccount,amount))
            {
                sourceAccount.Balance -= amount;
                destinationAccount.Balance += amount;
                Console.WriteLine($"Transferred {amount:C} from {sourceAccount.AccountNumber}'s account to {destinationAccount.AccountNumber}'s account. New Balance is {destinationAccount.Balance:C}");
            }
            else
            {
                Console.WriteLine("Transfer failed. Insufficient funds in the source account.");
            }
        }
        public void Withdraw(string accountNumber, double amount)
        {
            Console.WriteLine("**************** Withdrawal transaction processing ****************************************");

            if (IsValid(accountNumber, amount))
            {
                BankAccount account = _repository.GetAccount(accountNumber);

                if (account != null)
                {
                    if (IsValidWithdrwal(account, amount))
                    {
                        account.Balance -= amount;
                        Console.WriteLine($"Withdrawn {amount:C} From Account {account.AccountNumber}. *** New balance: {account.Balance:C}");
                    }
                }
                else
                {
                    Console.WriteLine($"Account number {accountNumber} not found.");
                }
            }
        }
        public bool IsValid(string accountNumber, double amount)
        {
            if (string.IsNullOrEmpty(accountNumber))
            {
                Console.WriteLine("Account Number cannot be null or empty.");
                return false;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Deposit/Withdrawal must be greater than zero.");
                return false;
            }
            return true;
        }
        public bool IsValidWithdrwal(BankAccount account, double amount)
        {

            if (account.Balance < amount)
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
                return false;
            }
            // Individual Investment accounts have a withdrawal limit of 500 dollars.
            if (account.InvestmentAccount == InvestmentAccount.Individual)
            {
                if (account.Balance < amount)
                {
                    Console.WriteLine("Insufficient funds for withdrawal.");
                    return false;
                }
                else if (amount > 500)
                {
                    Console.WriteLine("Individual Investment accounts have a withdrawal limit of $500.");
                    return false;
                }

            }

            return true;
        }
    }
}
