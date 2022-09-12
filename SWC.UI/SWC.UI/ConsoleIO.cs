using SWC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails(Order order, string orderDate)
        {
            Console.Clear();
            Console.WriteLine(Menu.stars);
            Console.WriteLine($"[ {order.OrderNumber} ]  |  [ {orderDate} ]");
            Console.WriteLine($"[ {order.CustomerName} ]");
            Console.WriteLine($"[ {order.State} ]");
            Console.WriteLine($"Product: [ {order.ProductType} ]");
            Console.WriteLine($"Materials: [ {order.MaterialCost} ]");
            Console.WriteLine($"Labor: [ {order.LaborCost} ]");
            Console.WriteLine($"Tax: [ {order.Tax} ]");
            Console.WriteLine($"Total: {order.Total}");
            Console.WriteLine(Menu.stars);

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            
        }
    }
}
