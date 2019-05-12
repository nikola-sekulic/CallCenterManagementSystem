using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Models
{
    public class Supervisor:Employee
    {
        public ICollection<Agent> Agents { get; set; }
        public ICollection<Specialist> Specialists { get; set; }

        public Supervisor()
        {
            Agents = new Collection<Agent>();
            Specialists = new Collection<Specialist>();
            DesignationId = 1;
        }
    }
}