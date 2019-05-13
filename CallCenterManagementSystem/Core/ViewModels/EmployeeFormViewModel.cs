using CallCenterManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CallCenterManagementSystem.ViewModels
{
    public class EmployeeFormViewModel
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

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Display(Name = "Designation")]
        public int DesignationId { get; set; }

        public string Gender { get; set; }

        [Required]
        public int SupervisorId { get; set; }

        public RegisterViewModel RegisterViewModel { get; set; }

        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Designation> Designations { get; set; }
    }
}