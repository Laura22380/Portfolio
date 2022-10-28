using CCAPL.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CCAPL.UI.Models
{
    public class AddEditMembersViewModel : IValidatableObject
    {
        public Members Member { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Member.MemberFirstName))
            {
                errors.Add(new ValidationResult("First name is required."));
            }

            if (string.IsNullOrEmpty(Member.MemberLastName))
            {
                errors.Add(new ValidationResult("Last name is required."));
            }

            return errors;
        }
    }
}