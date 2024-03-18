using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_in_ATM_machine
{
    using System;

    public class Account
    {
        private decimal balance = 0;

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false; // Insufficient funds
            }
        }

        public decimal CheckBalance()
        {
            return balance;
        }
    }

    public class ATM
    {
        private Account account = new Account();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\nATM Machine");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Deposit();
                        break;
                    case 2:
                        Withdraw();
                        break;
                    case 3:
                        CheckBalance();
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using ATM. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
        }

        private void Deposit()
        {
            Console.Write("Enter amount to deposit: ");
            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            account.Deposit(amount);
            Console.WriteLine($"Deposited {amount:C}. New balance: {account.CheckBalance():C}");
        }

        private void Withdraw()
        {
            Console.Write("Enter amount to withdraw: ");
            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            if (account.Withdraw(amount))
            {
                Console.WriteLine($"Withdrawn {amount:C}. New balance: {account.CheckBalance():C}");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }

        private void CheckBalance()
        {
            Console.WriteLine($"Current balance: {account.CheckBalance():C}");
        }
    }

    /*class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();
            atm.Run();
        }
    }*/


}
