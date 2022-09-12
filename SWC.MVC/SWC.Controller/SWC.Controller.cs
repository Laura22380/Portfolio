using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC.Controller
{
    public class SWCController
    {
        private View.View userInterface;
        private SWCRepository repo;
        private SWCManager manager;

        public SWCController()
        {
        userInterface = new View.View();
        manager = new SWCManager();
        }

        public void Run()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                int menuChoice = userInterface.ShowMenuAndGetUserChoice();
                switch (menuChoice)
                {
                    case 1:
                        LookupOrder();
                        break;
                    case 2:
                        AddOrder();
                        break;
                    case 3:
                        EditOrder();
                        break;
                    case 4:
                        RemoveOrder();
                        break;
                    case 5:
                        keepRunning = false;
                        return;
                    
                }
            }
        }

        private void LookupOrder()
        {

        }
        private void AddOrder()
        {
            Order newOrder = userInterface.GetNewOrderInformation();
            Order addedOrder = catManager.AddOrder(newOrder);
            if (addedOrder == null)
            {
                userInterface.ShowActionFailure("Create Order")
            }
            userInterface.DisplayOrder(addedOrder);
            userInterface.ShowActionSuccess("Create Order");
        }
        private void EditOrder()
        {
            int orderNumber = userInterface.GetOrderNumber();
            Order orderToModify = userInterface.GetNewOrderInformation();
            catToModify.OrderNumber = orderNumber;
            Order updatedOrder = manager.EditOrder(orderToModify);
            if (updatedOrder != null)
            {
                userInterface.DisplayOrder(updatedOrder);
                userInterface.ShowActionSuccess("Edit order");
            }
            else
            {
                userInterface.ShowActionFailure("Edit Order");
            }
        }
        private void RemoveOrder()
        {
            int orderNumber = userInterface.GetOrderNumber();
            Order order = manager.GetOrder(orderNumber);
            string confirm = userInterface.ConfirmRemoval().ToUpper();
            if (confirm !="Y" && confirm !="YES")
            {
                userInterface.ShowActionFailure("Remove Order");
            }
            manager.DeleteOrder(order);
            userInterface.ShowActionSuccess("Remove Order");
        }
    }
}
