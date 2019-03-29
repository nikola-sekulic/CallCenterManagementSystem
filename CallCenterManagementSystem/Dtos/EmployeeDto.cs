using CallCenterManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Dtos
{
    public class EmployeeDto
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

        public int DepartmentId { get; set; }
        public DepartmentDto Department { get; set; }


        public int DesignationId { get; set; }
        public DesignationDto Designation { get; set; }

        //[IfNotSupervisor]
        public int? SupervisorId { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}