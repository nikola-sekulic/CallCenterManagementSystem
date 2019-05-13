using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Models
{
    public class Agent:Employee
    {
        public int SupervisorId { get; set; }
        public Supervisor Supervisor { get; set; }

        public Agent()
        {
            DesignationId = 2;
        }

    }
}