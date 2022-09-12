using SWC.Models;
using SWC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC.Data
{
    public class SampleOrderTestRepository : iOrderRepository
    {
        private static Order _order = new Order
        {
            OrderNumber = 1,
            CustomerName = "Wise",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
            MaterialCost = (100.00M * 5.15M),
            LaborCost = (100.00M * 4.75M),
            Tax = ((515.00M + 475.00M) * (0.0625M)),
            Total = 1051.88M
        };

        public Order LoadOrder(int OrderNumber, string FilePath)
        {
            return _order;
        }

        public void RemoveOrder(int orderNumber, string FilePath)
        {
            _order = null;
            return;
        }

        public void SaveOrder(Order order, string OrderDate)
        {
            _order = order;
        }
    }
}
