using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class SalesItem
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } //just UserName?
        public string LastName { get; set; }
        public decimal SalePrice { get; set; }
        public string VIN { get; set; }//TotalVehicles?
    }
}
