using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Models
{
    public class MustBeSpecialist : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var employee = (Employee)validationContext.ObjectInstance;

            if (employee.DesignationId == 3)
                return ValidationResult.Success;

            else
                return new ValidationResult("Employee must be specialist.");
        }

    }
}