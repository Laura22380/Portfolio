using SWC.Models;
using SWC.Models.Interfaces;
using SWC.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC.Data
{
    public class OrderRepository : iOrderRepository
    {
        string filepath = $@"C:\Repos\online-net-2021-Triton22830\Summatives\SWC.UI\SWC.Data\OrderFiles\Orders_{DateTime.Now.ToString("MMddyyyy")}.txt";
        string tempPath = $@"C:\Repos\online-net-2021-Triton22830\Summatives\SWC.UI\SWC.Data\OrderFiles\TemporaryFile.txt";

        List<Order> data;


        public OrderRepository(string _filePath)
        {
            filepath = _filePath;
            data = new List<Order>();
        }

        public Order LoadOrder(int OrderNumber, string FilePath)
        {
            ReadAllFromFile(OrderNumber, FilePath);

            return data != null
            ? data.FirstOrDefault(x => x.OrderNumber == OrderNumber)
                : new Order();
        }

        private void ReadAllFromFile(int OrderNumber, string FilePath)
        {
            using (StreamReader reader = new StreamReader(FilePath))
            {
                foreach (string line in File.ReadLines(FilePath))
                {
                    //reader.ReadLine();
                    while (line.StartsWith(OrderNumber.ToString()))
                    {
                        Order newOrder = new Order();
                        string[] columns = line.Split(',');
                        newOrder.OrderNumber = Int32.Parse(columns[0]);
                        newOrder.CustomerName = columns[1];
                        newOrder.State = columns[2];
                        newOrder.TaxRate = Decimal.Parse(columns[3]);
                        newOrder.ProductType = columns[4];
                        newOrder.Area = Decimal.Parse(columns[5]);
                        newOrder.CostPerSquareFoot = Decimal.Parse(columns[6]);
                        newOrder.LaborCostPerSquareFoot = Decimal.Parse(columns[7]);
                        newOrder.MaterialCost = Decimal.Parse(columns[8]);
                        newOrder.LaborCost = Decimal.Parse(columns[9]);
                        newOrder.Tax = Decimal.Parse(columns[10]);
                        newOrder.Total = Decimal.Parse(columns[11]);

                        data.Add(newOrder);
                        break;
                    }
                    continue;
                }
                
            }
        }

        public void SaveOrder(Order order, string OrderDate)
        {
            
            data.Add(order);
            WriteNewFile(OrderDate);
        }

        private void WriteNewFile(string OrderDate)
        {
            if (!File.Exists(filepath))
            {
                string newPath = $@"C:\Repos\online-net-2021-Triton22830\Summatives\SWC.UI\SWC.Data\OrderFiles\Orders_{DateTime.Now.ToString("MMddyyyy")}.txt";
                using (StreamWriter sw = File.CreateText(newPath))
                {
                        foreach (var order in data)
                        {
                            sw.WriteLine(ConvertObjectToLine(order));
                        }
                    
                }
            }
            else
            {
                string filePathToEdit = $@"C:\Repos\online-net-2021-Triton22830\Summatives\SWC.UI\SWC.Data\OrderFiles\Orders_{OrderDate}";
                AddToFile(filePathToEdit);
            }

        }

        public void AddToFile(string filePathToEdit)
        {
            using (StreamWriter sw = File.AppendText(filePathToEdit))
            {
                foreach (var order in data)
                {
                    sw.WriteLine(ConvertObjectToLine(order));
                }
            }
         
        }
        private string ConvertObjectToLine(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", order.OrderNumber, order.CustomerName, order.State, order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
        }

        public void RemoveOrder(int OrderNumber, string FilePath)
        {
            LoadOrder(OrderNumber, FilePath);
            string tempPath = $@"C:\Repos\online-net-2021-Triton22830\Summatives\SWC.UI\SWC.Data\OrderFiles\TemporaryFile.txt";

            string line = null;
            string lineToRemove = OrderNumber.ToString();
            using (StreamReader reader = new StreamReader(FilePath))
            {
                using (StreamWriter sw = new StreamWriter(tempPath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith(lineToRemove))
                        {
                            continue;
                        }
                        sw.WriteLine(line);
                    }
                }
            }
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
            File.Copy(tempPath, FilePath);

        }
    }
}
