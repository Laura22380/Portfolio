using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class AddEditViewModel : IValidatableObject
    {[Required]
        public Vehicles Vehicle {get; set;}

        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }

        public IEnumerable<SelectListItem> BodyStyles { get; set; }
        public IEnumerable<SelectListItem> Colors { get; set; }
        public IEnumerable<SelectListItem> Interiors { get; set; }
        public IEnumerable<SelectListItem> Transmissions { get; set; }
        public string Type { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Vehicle.VIN))
            {
                errors.Add(new ValidationResult("VIN is required."));
            }

            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".jpeg" };
                var extension = Path.GetExtension(ImageUpload.FileName);

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a jpg, png, or jpeg"));
                }
            }

            if (Vehicle.SalePrice <= 0)
            {
                errors.Add(new ValidationResult("Sale price must be greater than 0."));
            }

            if (Vehicle.MSRP <= 0)
            {
                errors.Add(new ValidationResult("MSRP must be greater than 0."));
            }

            if (string.IsNullOrEmpty(Vehicle.Mileage))
            {
                errors.Add(new ValidationResult("Mileage must be greater than 0."));
            }

            if (string.IsNullOrEmpty(Vehicle.VehicleDescription))
            {
                errors.Add(new ValidationResult("Please include a description."));
            }

            return errors;
        }
    }
}