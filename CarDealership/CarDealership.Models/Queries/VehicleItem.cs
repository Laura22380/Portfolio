using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class VehicleItem
    {
        public string VIN { get; set; }
        public int Year { get; set; }
        public int MakeId { get; set; }
        public string Make { get; set; }
        public int ModelId { get; set; }
        public string Model { get; set; }
        public int BodyStyleId { get; set; }
        public string BodyStyleName { get; set; }
        public int TransmissionId { get; set; }
        public string TransmissionName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int InteriorId { get; set; }
        public string InteriorName { get; set; }
        public string Mileage { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public string VehicleDescription { get; set; }
        public string ImageFileName { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsPurchased { get; set; }
    }
}
