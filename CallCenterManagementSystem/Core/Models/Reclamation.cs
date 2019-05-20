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

        public string ProblemDescription { get; set; }

        public string Status { get; set; }

        public Employee Agent { get; set; }

        public int AgentId { get; set; }

        public Employee Specialist { get; set; }

        public int SpecialistId { get; set; }

        public SoldDevice SoldDevice { get; set; }

        public int SoldDeviceId { get; set; }

        public DateTime ReclamationCreated { get; set; }

        public DateTime? ReclamationEnded { get; set; }

        public ReclamationType ReclamationType { get; set; }

        public int ReclamationTypeId { get; set; }

    }
}