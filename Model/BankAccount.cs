using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Model
{
    public class BankAccount(string customerID, string customerName, AccountType accountType, string accountNumber, InvestmentAccount investmentAccount)
    {
        public string CustomerID { get; set; } = customerID;
        public string CustomerName { get; set; } = customerName;
        public AccountType AccountType { get; set; } = accountType;
        public string AccountNumber { get; set; } = accountNumber;
        public double Balance { get; set; } = 0;
        public InvestmentAccount InvestmentAccount { get; set; } = investmentAccount;
    }

    public enum AccountType { Checking, Investment }
    public enum InvestmentAccount { Individual,Corporate}

}
