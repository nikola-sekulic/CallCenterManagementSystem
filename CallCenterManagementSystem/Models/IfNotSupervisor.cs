using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CallCenterManagementSystem.Models
{
    public class IfNotSupervisor : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var employee = (Employee)validationContext.ObjectInstance;

            if (employee.SupervisorId == 1)
                return ValidationResult.Success;

            return (employee.SupervisorId == null && employee.DesignationId !=1)
                ? new ValidationResult("Required")
                : ValidationResult.Success;



        }

    }
}