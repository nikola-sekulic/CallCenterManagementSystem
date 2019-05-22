using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Models
{
    public abstract class Employee
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Name { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime? DateEnded { get; set; }

        public string Qualification { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }

        public Designation Designation { get; private set; }

        public int DesignationId { get; set; }

        public string Gender { get; set; }

        
    }
}