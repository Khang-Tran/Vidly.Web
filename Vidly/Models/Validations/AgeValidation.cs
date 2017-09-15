using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.Validations
{
    public class AgeValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers) validationContext.ObjectInstance;

            if (customer.MembershipTypesId == 0 || customer.MembershipTypesId == 1) 
                return ValidationResult.Success;
           if (customer.BirthDate == null)
                return new ValidationResult("Birth date is required");
            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;

            return age > 18
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 to register");
        }
    }
}