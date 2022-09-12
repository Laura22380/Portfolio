using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.WorkFlows
{
    public class WithdrawWorkFlow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();
            Console.WriteLine("Account Number: ");
            string accountNumber = Console.ReadLine();

            AccountLookupResponse responseOne = accountManager.LookupAccount(accountNumber);
            if (responseOne.Success)
            {
                ConsoleIO.DisplayAccountDetails(responseOne.Account);
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(responseOne.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.WriteLine("Withdraw Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountWithdrawResponse response = accountManager.Withdraw(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Withdraw completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Previous Balance: {response.OldBalance:c}");
                Console.WriteLine($"Amount Withdrawn: {response.Amount:c}");
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
