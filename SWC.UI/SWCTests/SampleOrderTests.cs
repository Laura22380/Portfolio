using NUnit.Framework;
using SWC.BLL;
using SWC.Models;
using SWC.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCTests
{
    [TestFixture]
    public class SampleOrderTests
    {
        string testFilePath = @"C:\Repos\online-net-2021-Triton22830\Summatives\SWC.UI\SWC.Data\OrderFiles\Orders_01012017";

        [Test]
        public void CanLoadSampleOrderTestData()
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderLookupResponse response = manager.LookupOrder(1, testFilePath);
            Assert.IsNotNull(response.Order);
            Assert.AreEqual(1, response.Order.OrderNumber);
        }

        [Test]
        public void CanRemoveSampleOrderTest()
        {
            OrderManager manager = OrderManagerFactory.Create();
            RemoveOrderResponse response = manager.RemoveOrder(1, testFilePath);
            Assert.IsNotNull(response.Order);
        }
        [Test]
        public void CanAddOrderTest()
        {
            Order order = new Order();
            order.OrderNumber = 2;
            order.CustomerName = "Test";
            order.State = "OH";
            order.TaxRate = 2;
            order.ProductType = "test";
            order.Area = 100;
            order.CostPerSquareFoot = 2;
            order.LaborCostPerSquareFoot = 2;
            order.MaterialCost = 2;
            order.LaborCost = 2;
            order.Tax = 4;
            order.Total = 1000;
            string OrderDate = DateTime.Now.ToString("MMddyyyy");
            OrderManager manager = OrderManagerFactory.Create();
            AddOrderFileResponse response = manager.AddOrderFile(order, OrderDate);
            Assert.IsNotNull(response.Order);
        }
        [Test]
        public void CanEditOrderTest()
        {
            Order order = new Order();
            order.OrderNumber = 1;
            order.CustomerName = "Test";
            order.State = "OH";
            order.TaxRate = 2;
            order.ProductType = "test";
            order.Area = 100;
            order.CostPerSquareFoot = 2;
            order.LaborCostPerSquareFoot = 2;
            order.MaterialCost = 2;
            order.LaborCost = 2;
            order.Tax = 4;
            order.Total = 1000;
            string OrderDate = "01012017";
            OrderManager manager = OrderManagerFactory.Create();
            EditOrderResponse response = manager.Edit(order, OrderDate);
            Assert.IsNotNull(response.Order);
        }
    }
}
