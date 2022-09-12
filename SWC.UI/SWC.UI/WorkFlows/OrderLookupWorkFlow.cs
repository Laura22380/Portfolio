using SWC.BLL;
using SWC.Data;
using SWC.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC.UI.WorkFlows
{
    public class OrderLookupWorkFlow
    {
        public (int orderNumber, string _pathWithDate, string orderDate) Execute()
        {
            Console.Clear();
            Console.WriteLine("Look up an order");
            Console.WriteLine(Menu.stars);
            Console.WriteLine("Enter an order number: ");
            string orderNum = Console.ReadLine().Trim();
            int orderNumber;
            while (!int.TryParse(orderNum, out orderNumber))
            {
                Console.WriteLine("Invalid number. Enter a valid number: ");
                orderNum = Console.ReadLine().Trim();
            }
            orderNumber = Int32.Parse(orderNum);
            Console.WriteLine("Enter the order date: (MMDDYYYY) ");
            string orderDate = Console.ReadLine().Trim();
            while (orderDate.Length != 8)
            {
                Console.WriteLine("Date must be in MMddyyyy format.");
                orderDate = Console.ReadLine().Trim();
            }

            string filepath = $@"C:\Repos\online-net-2021-Triton22830\Summatives\SWC.UI\SWC.Data\OrderFiles\Orders_{orderDate}.txt";
            string _pathWithDate = filepath;

            Console.WriteLine($"Looking up order {orderNumber}. Press any key to continue.");
            Console.ReadKey();

            return (orderNumber, _pathWithDate, orderDate);

        }
    }
}
