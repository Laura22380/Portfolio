﻿using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.WorkFlows
{
    public class DepositWorkFlow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();
            Console.WriteLine("Enter the account number: ");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("Enter a deposit amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

            if(response.Success)
            {
                Console.WriteLine("Deposit completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Previous Balance: {response.OldBalance:c}");
                Console.WriteLine($"Amount Depositied: {response.Amount:c}");
                Console.WriteLine($"New Balance: {response.Account.Balance:c}");
            }
            else
            {
                Console.WriteLine("An error occurred...");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue... ");
            Console.ReadKey();
        }
    }
}
