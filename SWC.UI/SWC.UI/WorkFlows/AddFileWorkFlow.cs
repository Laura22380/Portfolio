using SWC.BLL;
using SWC.BLL.Rules;
using SWC.Data;
using SWC.Models;
using SWC.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC.UI.WorkFlows
{
    public class AddFileWorkFlow
    {
        public Order Execute()
        {
            Order newOrder = new SWC.Models.Order();
            Console.Clear();
            Console.WriteLine("Create new order");
            Console.WriteLine(Menu.stars);
            Console.WriteLine("Order Number: ");
            string orderNum = Console.ReadLine().Trim();
            int orderNumber;
            while (!int.TryParse(orderNum, out orderNumber))
            {
                Console.WriteLine("Invalid number. Enter a valid number: ");
                orderNum = Console.ReadLine().Trim();
            }
            newOrder.OrderNumber = Int32.Parse(orderNum);
            Console.WriteLine("Customer Name: ");
            string custName = Console.ReadLine().Trim();
            while (String.IsNullOrEmpty(custName) || (custName.Contains("?")) || (custName.Contains("!")))//could add more special chars here
            {
                Console.WriteLine("Customer Name cannot be blank or contain special characters. Enter a valid customer Name:");
                custName = Console.ReadLine().Trim();
            }
            newOrder.CustomerName = custName;
            Console.WriteLine("State: ");
            newOrder.State = Console.ReadLine().Trim().ToUpper();
            // Figure out how to get state to be an abbreviation
            Tax Tax = GetTax();
            newOrder.TaxRate = Tax.TaxRate;
            Console.WriteLine("Available Products:");
            GetAvailableProducts();
            Console.WriteLine("Type in your product type: ");
            newOrder.ProductType = Console.ReadLine().Trim();
            Console.WriteLine("Area: ");
            newOrder.Area = Convert.ToDecimal(Console.ReadLine().Trim());
            newOrder.CostPerSquareFoot = GetProductCost(newOrder.ProductType);
            newOrder.LaborCostPerSquareFoot = GetLaborCost(newOrder.ProductType);
            newOrder.MaterialCost = (newOrder.Area * newOrder.CostPerSquareFoot);
            newOrder.LaborCost = (newOrder.Area * newOrder.LaborCostPerSquareFoot);
            newOrder.Tax = ((newOrder.MaterialCost + newOrder.LaborCost) * (newOrder.TaxRate / 100));
            newOrder.Total = (newOrder.MaterialCost + newOrder.LaborCost + newOrder.Tax);

            //ConsoleIO.DisplayOrderDetails(newOrder, DateTime.Now.ToString("MMddyyyy"));
            Console.WriteLine("Would you like to place this order? (Y/N)");
            string confirm = Console.ReadLine().ToUpper();
            if (confirm != "Y")
            {
                Menu.Start();
            }
            //Console.WriteLine("Creating order. Press any key to continue.");
            //Console.ReadKey();

            return newOrder;
        }

        private decimal GetLaborCost(string productType)
        {
            List<Product> products;
            products = new List<Product>();
            string productPath = @"C:\Repos\online-net-2021-Triton22830\Summatives\SWC.UI\SWC.Data\ProductsFile\ExampleProductFile.txt";
            using (StreamReader sr = new StreamReader(productPath))
            {
                Product product = new Product();
                foreach (string line in File.ReadLines(productPath))
                {
                    if (!line.StartsWith(productType))
                    {
                        continue;
                    }
                    string[] columns = line.Split(',');
                    product.LaborCostPerSquareFoot = Convert.ToDecimal(columns[2]);
                    break;
                }
                return product.LaborCostPerSquareFoot;
            }
        }

        private decimal GetProductCost(string productType)
        {
            List<Product> products;
            products = new List<Product>();
            string productPath = @"C:\Repos\online-net-2021-Triton22830\Summatives\SWC.UI\SWC.Data\ProductsFile\ExampleProductFile.txt";
            using (StreamReader sr = new StreamReader(productPath))
            {
                Product product = new Product();
                foreach (string line in File.ReadLines(productPath))
                {
                    if (!line.StartsWith(productType))
                    {
                        continue;
                    }
                    string[] columns = line.Split(',');
                    product.CostPerSquareFoot = Convert.ToDecimal(columns[1]);
                    break;
                }
                return product.CostPerSquareFoot;
            }
        }

        private void GetAvailableProducts()
        {
            List<string> availableProducts;
            availableProducts = new List<string>();
            string productPath = @"C:\Repos\online-net-2021-Triton22830\Summatives\SWC.UI\SWC.Data\ProductsFile\ExampleProductFile.txt";
            using (StreamReader reader = new StreamReader(productPath))
            {
                foreach (string line in File.ReadLines(productPath))
                {
                    string[] columns = line.Split(',');
                    string product = columns[0];
                    availableProducts.Add(product);
                }
                for (int i = 0; i < availableProducts.Count; i++)
                {
                    if (availableProducts != null)
                    {
                        Console.Write($"{availableProducts[i]}, ");
                    }
                }
                return;
            }
        }

        private Tax GetTax()
        {
            List<Tax> taxData;
            taxData = new List<Tax>();
            string taxPath = @"C:\Repos\online-net-2021-Triton22830\Summatives\SWC.UI\SWC.Data\TaxFiles\TaxExample.txt";
            using (StreamReader sr = new StreamReader(taxPath))
            {

                Tax stateTax = new Tax();
                foreach (string line in File.ReadLines(taxPath))
                {
                    string[] columns = line.Split(',');
                    stateTax.StateAbbreviation = columns[0];
                    stateTax.StateName = columns[1];
                    stateTax.TaxRate = Convert.ToDecimal(columns[2]);
                    taxData.Add(stateTax);
                }

                return stateTax;
            }
        }
    }
}
