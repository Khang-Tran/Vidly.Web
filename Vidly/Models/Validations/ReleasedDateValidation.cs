using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Vidly.Models.Validations
{
    public class ReleasedDateValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = validationContext.ObjectInstance as Movies;
            if (string.IsNullOrWhiteSpace(movie.ReleasedDate.ToString(CultureInfo.InvariantCulture)))
                return new ValidationResult("Released Date is required");
            return DateTime.Compare(movie.ReleasedDate,DateTime.Now) < 0 ? new ValidationResult("Released Date must be greater than Added Date") : ValidationResult.Success;
        }
    }
}