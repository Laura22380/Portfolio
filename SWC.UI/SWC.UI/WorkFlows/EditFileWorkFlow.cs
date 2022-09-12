using SWC.BLL;
using SWC.Data;
using SWC.Models;
using SWC.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC.UI.WorkFlows
{
    public class EditFileWorkFlow
    {
        public (Order, string OrderDate) Execute()
        {
            OrderManager orderManager = OrderManagerFactory.Create();
            {
                string filepath = null;
                int orderNumber = 0;
                string orderDate = null;
                OrderLookupResponse order = null;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Enter the order number you wish to edit: ");
                    string orderNum = Console.ReadLine().Trim();
                    //handle bad input / order number exists
                    orderNumber = Int32.Parse(orderNum);

                    Console.WriteLine("Enter the order date: (MMDDYYYY)");
                    orderDate = Console.ReadLine();


                    filepath = $@"C:\Repos\online-net-2021-Triton22830\Summatives\SWC.UI\SWC.Data\OrderFiles\Orders_{orderDate}.txt";
                    order = orderManager.LookupOrder(orderNumber, filepath);
                }
                while (!order.Success);

                OrderRepository repo = new OrderRepository(filepath);
                Order orderToEdit = repo.LoadOrder(orderNumber, filepath);

                Order newOrder = new SWC.Models.Order();
                Console.Clear();
                Console.WriteLine($"Edit order {orderToEdit.OrderNumber}");
                Console.WriteLine(Menu.stars);
                Console.WriteLine($"Customer Name: {orderToEdit.CustomerName}");
                newOrder.CustomerName = Console.ReadLine().Trim();
                bool blankName = string.IsNullOrEmpty(newOrder.CustomerName);
                if (blankName)
                {
                    newOrder.CustomerName = orderToEdit.CustomerName;   
                }
                Console.WriteLine($"State: {orderToEdit.State}");
                newOrder.State = Console.ReadLine().Trim().ToUpper();
                bool blankState = string.IsNullOrEmpty(newOrder.State);
                if (blankState)
                {
                    newOrder.State = orderToEdit.State;
                }
                Console.WriteLine($"Product Type: {orderToEdit.ProductType}");
                newOrder.ProductType = Console.ReadLine().Trim();
                bool blankProduct = string.IsNullOrEmpty(newOrder.ProductType);
                if (blankProduct)
                {
                    newOrder.ProductType = orderToEdit.ProductType;
                }
                Console.WriteLine($"Area: {orderToEdit.Area}");
                string stringArea = (Console.ReadLine().Trim());
                bool blankArea = string.IsNullOrEmpty(stringArea);
                if (blankArea)
                {
                    newOrder.Area = orderToEdit.Area;
                }
                else
                {
                    newOrder.Area = Convert.ToDecimal(stringArea);
                }
                newOrder.OrderNumber = orderToEdit.OrderNumber;
                newOrder.TaxRate = orderToEdit.TaxRate;
                newOrder.CostPerSquareFoot = orderToEdit.CostPerSquareFoot;
                newOrder.LaborCost = orderToEdit.LaborCost;
                newOrder.MaterialCost = (newOrder.Area * newOrder.CostPerSquareFoot);
                newOrder.LaborCost = (newOrder.Area * newOrder.LaborCostPerSquareFoot);
                newOrder.Tax = ((newOrder.MaterialCost + newOrder.LaborCost) * (newOrder.TaxRate / 100));
                newOrder.Total = (newOrder.MaterialCost + newOrder.LaborCost + newOrder.Tax);
                repo.RemoveOrder(orderToEdit.OrderNumber, filepath);

                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return (newOrder, orderDate);
            }
        }
    }
}
