using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class VehiclePurchase
    {
        public int UserId { get; set; }
        public string User { get; set; }
        public decimal TotalSales { get; set; }
        public int TotalVehicles { get; set; }
        public string BuyerFirstName { get; set; } 
        public string BuyerLastName { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchaseType { get; set; }
        public DateTime PurchaseDate { get; set; }
        //Everything from buyer contact and vehicle total description?
    }
}
