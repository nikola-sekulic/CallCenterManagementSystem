using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        [MustBeAgent]
        public Employee Agent { get; set; }

        [Required]
        [MustBeSpecialist]
        public Employee Specialist { get; set; }

        public SoldDevice SoldDevice { get; set; }

        [Required]
        public int SoldDeviceId { get; set; }

        [Required]
        public DateTime ReclamationCreated { get; set; }

        public DateTime? ReclamationEnded { get; set; }

        public ReclamationType ReclamationType { get; set; }

        [Required]
        public int ReclamationTypeId { get; set; }


    }
}