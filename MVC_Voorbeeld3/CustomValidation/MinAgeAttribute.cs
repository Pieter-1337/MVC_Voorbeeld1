using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Globalization;

namespace MVC_Voorbeeld3.CustomValidation
{
    public class MinAgeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = null;
            DateTime CurrentDate = DateTime.Now;
            if (value != null)
            {
                DateTime BirthDate = DateTime.Parse(value.ToString());
                int Age = CurrentDate.Year - BirthDate.Year;
                if (Age < 18)
                {
                    result = new ValidationResult("De minimum leeftijd bedraagt 18 jaar");
                    
                }
                else
                {
                    result = ValidationResult.Success;   
                }
            }
            else
            {
                result = new ValidationResult("Gelieve een geldige datum in te geven");
            }
            return result;
        }
    }
}