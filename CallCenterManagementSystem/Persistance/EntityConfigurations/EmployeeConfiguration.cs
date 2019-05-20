using CallCenterManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Persistance.EntityConfigurations
{
    public class EmployeeConfiguration:EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            Property(c => c.Name).IsRequired().HasMaxLength(50);
            Property(c => c.DateStarted).IsRequired();
            Property(c => c.DateEnded).IsOptional();
            Property(c => c.Qualification).IsRequired().HasMaxLength(100);
            Property(c => c.DepartmentId).IsRequired();
            Property(c => c.DesignationId).IsRequired();
        }
    }
}