using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class PurchaseViewModel : IValidatableObject
    {
        public VehicleItem Vehicle { get; set; }
        [Required]
        public Buyers Buyer { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public VehicleSales VehicleSale { get; set; }
        public string PurchaseType { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Buyer.BuyerName))
            {
                errors.Add(new ValidationResult("Name is required."));
            }

            if (VehicleSale.PurchasePrice <= 0)
            {
                errors.Add(new ValidationResult("Purchase price must be greater than 0."));
            }

            if (string.IsNullOrEmpty(PurchaseType))
            {
                errors.Add(new ValidationResult("Purchase type is required."));
            }

            if (string.IsNullOrEmpty(Buyer.BuyerPhone) && string.IsNullOrEmpty(Buyer.BuyerEmail))
            {
                errors.Add(new ValidationResult("Either buyer's phone or email is required for purchase."));
            }

            if ((Buyer.BuyerZipCode).ToString().Length != 5)
            {
                errors.Add(new ValidationResult("Zip code must be 5 digits."));
            }

            if (Buyer.BuyerEmail != null)
            {
                //validate email
                
            }

            if (VehicleSale.PurchasePrice < (Vehicle.SalePrice*0.95M))
            {
                errors.Add(new ValidationResult("Vehicle cannot be purchased for less than 95% of the sale price."));
            }

            if (VehicleSale.PurchasePrice > Vehicle.MSRP)
            {
                errors.Add(new ValidationResult("Vehicle cannot be purchased for more than MSRP."));
            }

            return errors;
        }
    }
}