using CallCenterManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Dtos
{
    public class NewReclamationDto
    {
        [Required]
        [MustBeAgent]
        public int EmployeeId { get; set; }

        [ForeignKey("Employee")]
        [MustBeSpecialist]
        public int SpecialistId { get; set; }

        [Required]
        public int SoldDeviceId { get; set; }

        [Required]
        public int CallHistoryId { get; set; }

        [Required]
        public int ReclamationTypeId { get; set; }
    }
}