using CallCenterManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Dtos
{
    public class SupervisorDto:EmployeeDto
    {
        public ICollection<AgentDto> AgentsDto { get; set; }
        public ICollection<SpecialistDto> SpecialistsDto { get; set; }
    }
    
}