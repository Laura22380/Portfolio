using SGBank.UI.WorkFlows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public static class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("SG Bank Application");
                Console.WriteLine("________________________");
                Console.WriteLine("1. Lookup an Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("\nQ to quit");
                Console.Write("\nEnter Selection: ");

                string userinput = Console.ReadLine();
                switch(userinput)
                {
                    case "1":
                        AccountLookupWorkFlow lookupWorkFlow = new AccountLookupWorkFlow();
                        lookupWorkFlow.Execute();
                        break;
                    case "2":
                        DepositWorkFlow depositWorkFlow = new DepositWorkFlow();
                        depositWorkFlow.Execute();
                        break;
                    case "3":
                        WithdrawWorkFlow withdrawWorkFlow = new WithdrawWorkFlow();
                        withdrawWorkFlow.Execute();
                        break;
                    case "Q":
                        return;

                }
            }

        }
    }
}
