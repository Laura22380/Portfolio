using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC.Models.Interfaces
{
    public interface iOrderRepository
    {
        Order LoadOrder(int OrderNumber, string FilePath);
        void SaveOrder(Order order, string OrderDate);
        void RemoveOrder(int orderNumber, string FilePath);

    }
}
