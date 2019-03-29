using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Models
{
    public class Reclamation
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProblemDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string  Status { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public SoldDevice SoldDevice { get; set; }

        [Required]
        public int SoldDeviceId { get; set; }

        public CallHistory CallHistory { get; set; }

        [Required]
        public int CallHistoryId { get; set; }

    }
}