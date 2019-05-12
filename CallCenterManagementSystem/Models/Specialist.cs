using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Models
{
    public class Specialist:Employee
    {
        public int SupervisorId { get; set; }
        public Supervisor Supervisor { get; set; }

        public Specialist()
        {
            DesignationId = 3;
        }
    }
}