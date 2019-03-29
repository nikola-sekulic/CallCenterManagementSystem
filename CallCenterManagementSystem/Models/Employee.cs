using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Models
{
    public class Employee
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }

        [Required]
        [StringLength(100)]
        public string Qualification { get; set; }


        public Department Department { get; set; }
        public int DepartmentId { get; set; }


        public Designation Designation { get; set; }

        public int DesignationId { get; set; }

        [IfNotSupervisor]
        public int? SupervisorId { get; set; }

        [Required]
        public string Gender { get; set; }

    }
}