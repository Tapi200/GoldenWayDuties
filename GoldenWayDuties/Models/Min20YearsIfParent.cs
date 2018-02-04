using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoldenWayDuties.Models
{
    public class Min20YearsIfParent : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var owner = (Owner) validationContext.ObjectInstance;

            if (owner.ResidentTypeId == ResidentType.Unknown || 
                owner.ResidentTypeId != ResidentType.Parent)
                return ValidationResult.Success;

            if (owner.DateOfBirth == null)
                return new ValidationResult("date of birth required");

            var age = DateTime.Today.Year - owner.DateOfBirth.Value.Year;

           return (age >= 18)
                ? ValidationResult.Success 
                : new ValidationResult("Owner should be at least 18 years old to be a Parent");
           
        }
    }
}