using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class VehicleFeaturedItem
    {
        public string VIN { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal SalePrice { get; set; }
        public string ImageFileName { get; set; }
        public bool IsFeatured { get; set; }

    }
}
