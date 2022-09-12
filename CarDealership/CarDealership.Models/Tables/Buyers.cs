using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Buyers
    {
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public string BuyerPhone { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerStreet1 { get; set; }
        public string BuyerStreet2 { get; set; }
        public string BuyerCity { get; set; }
        public string StateId { get; set; }
        public int BuyerZipCode { get; set; }
    }
}
