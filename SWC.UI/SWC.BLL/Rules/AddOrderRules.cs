using SWC.Models;
using SWC.Models.Interfaces;
using SWC.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SWC.BLL.Rules
{
    public class AddOrderRules : iEditOrder
    {
        public EditOrderResponse Validate(Order order)
        {
            EditOrderResponse response = new EditOrderResponse();

            if (string.IsNullOrEmpty(order.CustomerName))
            {
                response.Success = false;
                response.Message = "Error. Customer Name cannot be blank";
                return response;
            }
            
            if (order.CustomerName.Contains("?"))
            {
                response.Success = false;
                response.Message = "Error. Customer Name may only contain letters, numbers, commas, and periods";
                return response;
            }

            /*if (!Regex.Match(order.CustomerName, @"^[A-Z][a-z][0-9]\s\.\,"))
            {
                response.Success = false;
                response.Message = "Error. Customer Name may only contain letters, numbers, commas, and periods";
                return response;
            }*/

            string stateFilePath = @"C:\Repos\online-net-2021-Triton22830\Summatives\SWC.UI\SWC.Data\TaxFiles\TaxExample.txt";
            using (StreamReader sr = new StreamReader(stateFilePath))
            {
                string line = sr.ReadLine();
                if (!(line.StartsWith(order.State)))
                {
                    response.Success = false;
                    response.Message = $"Error. We are not taking orders in {order.State} at this time.";
                    return response;
                }
            }

            if (order.Area < 100)
            {
                response.Success = false;
                response.Message = "Error. Area must be at least 100SF";
                return response;
            }


            response.Success = true;
            response.Message = "Order edited/added successfully";
            return response;
        }
    }
}
