using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Account
    {
        public string AccountName;
        public string AccountNumber;
        public string BVN;
        public string AccountType;
        public double balance = 0.00;

        public Account(string name, string type)
        {
            Random rand = new Random();
            this.AccountName = name;
            this.AccountType = type;
            this.AccountNumber = rand.Next(111111111, 999999999).ToString();
            this.BVN = rand.Next(111111111, 999999999).ToString();
        }

        public void deposit(double amount)
        {
            if (amount > 100)
            {
                balance += amount;
                Console.WriteLine("Deposit successful. Your new balance is " + balance);
            }
            else
            {
                Console.WriteLine("You cannot deposit an amount less than 100");
            }
        }

        public void withdraw(double amount)
        {
            if (balance > amount)
            {
                balance -= amount;
                Console.WriteLine("Withdrawal successful. Your new balance is " + balance);
            }
            else
            {
                Console.WriteLine("Balance is not enough. You currently have " + balance + " in your account");
            }
        }

        public void enquiry()
        {
            Console.WriteLine("You currently have " + balance + " in your account");
        }
    }
}
