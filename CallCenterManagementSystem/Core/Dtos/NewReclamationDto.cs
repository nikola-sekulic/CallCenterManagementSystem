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
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProblemDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        
        public Agent Agent { get; set; }

        [Required]
        public int AgentId { get; set; }


        public Employee Specialist { get; set; }

        [Required]
        public int SpecialistId { get; set; }

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