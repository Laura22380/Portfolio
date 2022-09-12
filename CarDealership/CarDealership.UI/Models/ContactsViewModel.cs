using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class ContactsViewModel : IValidatableObject
    {
        public Contacts Person { get; set; }
        public string VIN { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (Person == null)
            {
                errors.Add(new ValidationResult("Please enter contact information."));
                return errors;
            }

            if (string.IsNullOrEmpty(Person.ContactPhone) && string.IsNullOrEmpty(Person.ContactEmail))
            {
                errors.Add(new ValidationResult("Please enter either phone or email."));
            }

            if (string.IsNullOrEmpty(Person.ContactName))
            {
                errors.Add(new ValidationResult("Please enter your name."));
            }

            if (string.IsNullOrEmpty(Person.ContactMessage))
            {
                errors.Add(new ValidationResult("Please enter a message so we know how to assist you."));
            }

            return errors;
        }
    }
}