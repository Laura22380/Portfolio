using SWC.Data;
using SWC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC.BLL
{
    public class OrderManager
    {
        OrderRepository repo;

        public OrderManager()
        {
            repo = new OrderRepository();
        }
        public Order AddOrder(Order order)
        {
            bool isValid = validateOrder(order);
            if (!isValid)
            {
                return null;
            }
            return repo.CreateOrder(order);
        }
        public void DeleteOrder(Order order, string FilePath)
        {
            repo.DeleteOrder(order.OrderNumber, FilePath);
        }
        private bool validateOrder(Order order)
        {
            if (String.IsNullOrEmpty(order.CustomerName)|| )
            {
                return false;
            }
            return true;
        }
        public Order EditOrder(Order order)
        {
            return repo.EditOrder(order);
        }
        public Order GetOrder(int orderNumber, string FilePath)
        {
            return repo.RetrieveOrder(orderNumber, FilePath);
        }
    }
}
