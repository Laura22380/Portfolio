using SWC.BLL;
using SWC.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC.UI.WorkFlows
{
    public class RemoveFileWorkFlow
    {
        public (int OrderNumber, string filepath) Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Look up an order");
            Console.WriteLine(Menu.stars);
            Console.WriteLine("Enter an order number: ");
            string orderNum = Console.ReadLine().Trim();
            int orderNumber;
            while(!int.TryParse(orderNum, out orderNumber))
            {
                Console.WriteLine("Invalid number. Enter a valid number: ");
                orderNum = Console.ReadLine().Trim();
            }
            orderNumber = Int32.Parse(orderNum);
            Console.WriteLine("Enter the order date: (MMDDYYYY)");
            string orderDate = Console.ReadLine().Trim();
            string filepath = $@"C:\Repos\online-net-2021-Triton22830\Summatives\SWC.UI\SWC.Data\OrderFiles\Orders_{orderDate}.txt";

            OrderLookupResponse lookupResponse = manager.LookupOrder(orderNumber, filepath);
            if (lookupResponse.Success)
            {
                ConsoleIO.DisplayOrderDetails(lookupResponse.Order, orderDate);
            }
            Console.WriteLine($"Would you like to delete order {orderNumber} ?");
            string confirm = Console.ReadLine().ToUpper();
            if (confirm != "Y" && confirm != "YES")
            {
                Menu.Start();
            }
            else
            {
                Console.WriteLine("Loading order to remove. Press any key to continue.");
                Console.ReadKey();
            }

            return (orderNumber, filepath);
        }
    }
}
