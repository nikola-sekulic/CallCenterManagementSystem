using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CallCenterManagementSystem.Models;

namespace CallCenterManagementSystem.ViewModels
{
    public class NewEmployeeViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Designation> Designations { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public Employee Employee { get; set; }

        public string Title
        {
            get
            {
                if (Employee != null && Employee.Id != 0)
                    return "Edit Employee";

                return "New Employee";
            }
        }
    }
}