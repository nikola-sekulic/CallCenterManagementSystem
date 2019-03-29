using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Models
{
    public class CallHistory
    {
        public int Id { get; set; }

        [Required]
        public DateTime CallDate { get; set; }

        public Buyer Buyer { get; set; }
        public int BuyerId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public int EmployeeId { get; set; }

    }
}