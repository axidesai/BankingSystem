# BankingSystem

# Task:
Write a program adhering to the simple requirements listed below. This program should require no input to run and should not have a user interface. To demonstrate the functionality 
of your application, please write test classes that invoke a deposit, a withdrawal, and a transfer.

# Requirements
• A bank has a name.
• A bank also has several accounts.
• An account has an owner and a balance.
• Account types include: Checking, Investment.
• There are two types of Investment accounts: Individual, Corporate.
• Individual accounts have a withdrawal limit of 500 dollars.
• Transactions are made on accounts.
• Transaction types include: Deposit, Withdraw, and Transfer

*********************************************************************************************************

# Progam Details

The program is structured using classes, interfaces, and dependency injection for modularity and testability. We have created repository for managing bank accounts. 
It creates service for processing the bank transactions.

# Classes:
Bank: We have not created bank class to make it simple. Right now the bank name is hard coded as "OPENLANE Bank". We can create bank class in the future.
BankAccount: Represents a bank account with an CustomerID, CustomerName, AccountNumber, AccountType (Checking or Investment), InvestmentAccount (Individual, Corporate) and balance.
AccountType: Declare as Enum (Checking or Investment)
InvestmentAccount: Declare as Enum (Individual, Corporate)

# Interfaces:
IBankRepository: Defines methods for accessing and managing bank accounts.
ITransactionService: Defines methods for processing transactions like Deposit, Transfer, Withdrawal.

# Services:
TransactionService: Implements ITransactionService and handles the processing of transactions.

# Repository
BankRepository: Implements IBankRepository and manages the customer bank accounts.


# How to Run
Open the solution in your preferred C# development environment (Visual Studio, VS Code, etc.).

Build the solution.

Run the program.

Follow the on-screen instructions to interact with the banking system. Example transactions are provided in the Program class of the code.

# Dependencies
The program uses basic C# language features and does not rely on external libraries or frameworks.