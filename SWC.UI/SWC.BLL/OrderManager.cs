using SWC.BLL.Rules;
using SWC.Models;
using SWC.Models.Interfaces;
using SWC.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC.BLL
{
    public class OrderManager
    {
        private iOrderRepository _orderRepository;

        public OrderManager(iOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderLookupResponse LookupOrder(int OrderNumber, string FilePath)
        {
            OrderLookupResponse response = new OrderLookupResponse
            {
                Order = _orderRepository.LoadOrder(OrderNumber, FilePath)
            };

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"Cannot find order {OrderNumber}. Try again.";
                return response;
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public RemoveOrderResponse RemoveOrder(int orderNumber, string FilePath)
        {
            RemoveOrderResponse response = new RemoveOrderResponse();
            response.Order = _orderRepository.LoadOrder(orderNumber, FilePath);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"{orderNumber} has not been removed.";
                return response;
            }
            else
            {
                response.Success = true; 
                _orderRepository.RemoveOrder(orderNumber, FilePath);
            }
            return response;
        }
        public AddOrderFileResponse AddOrderFile(Order order, string OrderDate)
        {
            AddOrderFileResponse response = new AddOrderFileResponse();
            var rule = new AddOrderRules();
            var validationResponse = rule.Validate(order);

            if (validationResponse.Success)
            {
                _orderRepository.SaveOrder(order, OrderDate);
                response.Success = true;
                response.Message = "Order saved successfully.";
            }
            if (!validationResponse.Success)
            {
                response.Message = validationResponse.Message;
                response.Success = false;
            }
            response.Order = order;
            return response;
        } 

        public EditOrderResponse Edit(Order order, string OrderDate)
        {
            EditOrderResponse response = new EditOrderResponse();
            var rule = new AddOrderRules();
            var validationResponse = rule.Validate(order);

            if (validationResponse.Success)
            {
                _orderRepository.SaveOrder(order, OrderDate);
            }
            response.Success = true;
            response.Order = order;
            return response;
        }
    }
}
