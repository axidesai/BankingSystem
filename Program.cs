// See https://aka.ms/new-console-template for more information
using BankingSystem.Model;
using BankingSystem.Repository;
using BankingSystem.Service;
using System.Transactions;

Console.WriteLine("Welcome to OPENLANE Bank");

IBankRepository repository = new BankRepository();
TransactionService transactionService = new TransactionService(repository);

BankAccount acccount1 = new BankAccount("J001", "John", AccountType.Checking, "C12345", InvestmentAccount.Individual);
BankAccount acccount2 = new BankAccount("J001", "John", AccountType.Investment, "I12345", InvestmentAccount.Individual);

repository.AddAccount(acccount1);
repository.AddAccount(acccount2);

transactionService.Deposit(acccount1.AccountNumber, 500);
transactionService.Deposit(acccount1.AccountNumber, 1500);
transactionService.Deposit("", 1500); 

transactionService.Deposit(acccount2.AccountNumber, 1000);
transactionService.Withdraw(acccount2.AccountNumber, 700);
transactionService.Transfer(acccount1.AccountNumber, acccount2.AccountNumber, 200);
