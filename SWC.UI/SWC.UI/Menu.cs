using SWC.BLL;
using SWC.Data;
using SWC.Models;
using SWC.Models.Responses;
using SWC.UI.WorkFlows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC.UI
{
    public static class Menu
    {
        public static string stars = "*************************************";

        static OrderManager orderManager = OrderManagerFactory.Create();

        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(stars);
                Console.WriteLine("* Flooring Program");
                Console.WriteLine("*");
                Console.WriteLine("* 1. Display Orders");
                Console.WriteLine("* 2. Add an Order");
                Console.WriteLine("* 3. Edit an Order");
                Console.WriteLine("* 4. Remove an Order");
                Console.WriteLine("* 5. Quit");
                Console.WriteLine("*");
                Console.WriteLine(stars);

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        OrderLookupWorkFlow lookupWorkFlow = new OrderLookupWorkFlow();
                        (int orderNumber, string _pathWithDate, string orderDate) = lookupWorkFlow.Execute();
                        OrderLookupResponse lookupResponse = orderManager.LookupOrder(orderNumber, _pathWithDate);
                        if (!lookupResponse.Success)
                        {
                            Console.WriteLine(lookupResponse.Message);
                            Console.ReadKey();
                        }
                        else
                        {
                            ConsoleIO.DisplayOrderDetails(lookupResponse.Order, orderDate);
                        }
                        break;
                    case "2":
                        AddFileWorkFlow addFileWorkFlow = new AddFileWorkFlow();
                        Order newOrder = addFileWorkFlow.Execute();
                        orderDate = null;
                        AddOrderFileResponse response = orderManager.AddOrderFile(newOrder, orderDate);
                        if (response.Success == false)
                        {
                            Console.WriteLine(response.Message);
                            Console.ReadKey();
                        }
                        ConsoleIO.DisplayOrderDetails(response.Order, DateTime.Now.ToString("MMddyyyy"));
                        Console.WriteLine(response.Message);
                        break;
                    case "3":
                        EditFileWorkFlow editWorkFlow = new EditFileWorkFlow();
                        (Order order, string OrderDate) = editWorkFlow.Execute();
                        EditOrderResponse editResponse = orderManager.Edit(order, OrderDate);
                        ConsoleIO.DisplayOrderDetails(editResponse.Order, OrderDate);
                        break;
                    case "4":
                        RemoveFileWorkFlow removeWorkFlow = new RemoveFileWorkFlow();
                        (int OrderNumber, string filepath) = removeWorkFlow.Execute();
                        orderManager.RemoveOrder(OrderNumber, filepath);
                        break;
                    case "5":
                        return;

                }
            }
        }
    }
}
