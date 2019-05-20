using CallCenterManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Persistance.EntityConfigurations
{
    public class ReclamationConfiguration:EntityTypeConfiguration<Reclamation>
    {
        public ReclamationConfiguration()
        {
            Property(c => c.ProblemDescription).IsRequired().HasMaxLength(255);
            Property(c => c.Status).IsRequired().HasMaxLength(50);
            Property(c => c.AgentId).IsRequired();
            Property(c => c.SpecialistId).IsRequired();
            Property(c => c.SoldDeviceId).IsRequired();
            Property(c => c.ReclamationCreated).IsRequired();
            Property(c => c.ReclamationTypeId).IsRequired();
        }
    }
}