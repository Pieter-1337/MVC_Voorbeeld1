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
            ValidationResult result; 

            // Do some validation checks here
            DateTime BirthDate = DateTime.Parse(value.ToString());
            DateTime CurrentDate = DateTime.Now;

            int Age = CurrentDate.Year - BirthDate.Year;


            if (Age < 18)
            {
                result = new ValidationResult("De minimum leeftijd bedraagt 18 jaar");
            }
            else
            {
                result = ValidationResult.Success;
            }
                
            return result;
        }
    }
}