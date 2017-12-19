/******************************************************************
** auth: Frank
** date: 12/19/2017 9:31:34 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Demo.Validations
{
    public class EmployeeFirstNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                string msg = string.IsNullOrEmpty(this.ErrorMessage) ? "Please provider first name" : this.ErrorMessage;
                return new ValidationResult(msg);
            }
            else
            {
                if (value.ToString().Contains("@"))
                {
                    return new ValidationResult("First name should not contain @");
                }
            }

            return ValidationResult.Success;
        }
    }
}
