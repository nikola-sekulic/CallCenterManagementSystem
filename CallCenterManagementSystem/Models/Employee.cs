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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateStarted { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateEnded { get; set; }

        [Required]
        [StringLength(100)]
        public string Qualification { get; set; }


        public Department Department { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }


        public Designation Designation { get; set; }

        [Display(Name = "Designation")]
        public int DesignationId { get; set; }

        [IfNotSupervisor]
        [Display(Name = "Supervisor")]
        public int? SupervisorId { get; set; }

        [Required]
        public string Gender { get; set; }

    }
}