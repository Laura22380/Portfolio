using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class VehicleSales
    {
        public int SaleId { get; set; }
        public string VIN { get; set; }
        public int UserId { get; set; }
        public int BuyerId { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchaseType { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
