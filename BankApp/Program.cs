using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        static List<Account> Accounts = new List<Account>();
        static void Main(string[] args)
        {
            checkPassword();
        }

        public static void checkPassword()
        {
            Console.WriteLine("Welcome to your bank app. Please enter password to login");
            var password = Console.ReadLine();

            if (password == "History")
            {
                acceptOperation();
            }

            checkPassword();
        }

        public static void openAccount()
        {
            Console.WriteLine("Enter account name");
            var name = Console.ReadLine();


            Console.WriteLine("Enter account type (S - Savings, C - Current, F - Fixed) ");
            var type = Console.ReadLine();

            Account acc = new Account(name, type);

            Accounts.Add(acc);

            Console.WriteLine("Account created successfully! Account number is: " + acc.AccountNumber);
        }

        public static void withdraw()
        {
            Console.WriteLine("Enter account number");
            var number = Console.ReadLine();

            var validAccountNumber = findAccountNumber(number);

            if (validAccountNumber == -1)
            {
                Console.WriteLine("Invalid account number");
            }
            else
            {
                Console.WriteLine("Enter amount to withdraw");
                var amount = Convert.ToDouble(Console.ReadLine());

                var acc = Accounts[validAccountNumber];
                acc.withdraw(amount);
            }
        }

        public static void deposit()
        {
            Console.WriteLine("Enter account number");
            var number = Console.ReadLine();

            var validAccountNumber = findAccountNumber(number);

            if (validAccountNumber == -1)
            {
                Console.WriteLine("Invalid account number");
            }
            else
            {
                Console.WriteLine("Enter amount to deposit");
                var amount = Convert.ToDouble(Console.ReadLine());

                var acc = Accounts[validAccountNumber];
                acc.deposit(amount);
            }
        }


        public static void balanceEnq()
        {
            Console.WriteLine("Enter account number");
            var number = Console.ReadLine();

            var validAccountNumber = findAccountNumber(number);

            if (validAccountNumber == -1)
            {
                Console.WriteLine("Invalid account number");
            }
            else
            {
                var acc = Accounts[validAccountNumber];
                acc.enquiry();
            }
        }

        public static void transfer()
        {
            Console.WriteLine("Enter account number to transfer from");
            var number = Console.ReadLine();

            var validAccountNumber = findAccountNumber(number);

            if (validAccountNumber == -1)
            {
                Console.WriteLine("Invalid account number");
            }
            else
            {
                var transferAcc = Accounts[validAccountNumber];

                Console.WriteLine("Enter amount to transfer");
                var amount = Convert.ToDouble(Console.ReadLine());

                if (transferAcc.balance > amount)
                {
                    Console.WriteLine("Enter account number to transfer to");
                    var receiveN = Console.ReadLine();

                    var receiveAccIndex = findAccountNumber(receiveN);

                    if (receiveAccIndex == -1)
                    {
                        Console.WriteLine("Invalid receiver account number");
                    }
                    else
                    {
                        var receiveAcc = Accounts[receiveAccIndex];
                        receiveAcc.balance += amount;
                        transferAcc.balance -= amount;

                        Console.WriteLine("Transfer completed. Transfer account balance is: " + transferAcc.balance);
                    }
                }

                Console.WriteLine("Inadequate funds in transferring account. Balance is: " + transferAcc.balance);

            }
        }


        public static void closeAnAccount()
        {
            Console.WriteLine("Enter account number");
            var number = Console.ReadLine();

            var validAccountNumber = findAccountNumber(number);

            if (validAccountNumber == -1)
            {
                Console.WriteLine("Invalid account number");
            }
            else
            {
                Accounts.RemoveAt(validAccountNumber);
                Console.WriteLine("Account closed successfully");
            }
        }

        public static void modifyAnAccount()
        {
            Console.WriteLine("Enter account number to modify");
            var number = Console.ReadLine();

            var validAccountNumber = findAccountNumber(number);

            if (validAccountNumber == -1)
            {
                Console.WriteLine("Invalid account number");
            }
            else
            {
                Console.WriteLine("Enter new account type (S - Savings, C - Current, F - Fixed) ");
                var type = Console.ReadLine();
                var acc = Accounts[validAccountNumber];
                acc.AccountType = type;

                Console.WriteLine("Account modified successfully");
            }
        }


        public static void listAllAccounts()
        {
            Console.WriteLine("All accounts");

            int sn = 1;
            foreach (var acc in Accounts)
            {
                Console.Write(sn + ". ");
                Console.WriteLine("Account Number: " + acc.AccountNumber + "\t Account Name: " + acc.AccountName + "\t Account Type: " + acc.AccountType + "\t Account Balance: " + acc.balance);
                Console.WriteLine();
            }
        }



        static int findAccountNumber(string number)
        {
            int output = -1;
            int index = 0;
            foreach (var acc in Accounts)
            {
                if(acc.AccountNumber == number)
                {
                    output = index;
                }
                index += 1;
            }
            return output;
        }


        static void acceptOperation()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please select the operation you want to perform");
            Console.WriteLine("1 - Open an account");
            Console.WriteLine("2 - Deposit");
            Console.WriteLine("3 - Withdraw");
            Console.WriteLine("4 - Transfer");
            Console.WriteLine("5 - Balance Enquiry");
            Console.WriteLine("6 - All Accounts");
            Console.WriteLine("7 - Close an account");
            Console.WriteLine("8 - Modify an account");
            Console.WriteLine("9 - Exit");

            var op = Convert.ToInt32(Console.ReadLine());

            switch (op)
            {
                case 1:
                    openAccount();
                    break;
                case 2:
                    deposit();
                    break;
                case 3:
                    withdraw();
                    break;
                case 4:
                    transfer();
                    break;
                case 5:
                    balanceEnq();
                    break;
                case 6:
                    listAllAccounts();
                    break;
                case 7:
                    closeAnAccount();
                    break;
                case 8:
                    modifyAnAccount();
                    break;
                case 9:
                   Environment.Exit(1);
                   break;
                default:
                    acceptOperation();
                    break;
            }

            acceptOperation();
        }
    }
}
