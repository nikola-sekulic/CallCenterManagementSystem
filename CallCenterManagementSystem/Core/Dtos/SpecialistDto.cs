using CallCenterManagementSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Models
{
    public class SpecialistDto:EmployeeDto
    {
        public int SupervisorId { get; set; }
        public SupervisorDto Supervisor { get; set; }

        
    }
}