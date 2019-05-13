using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Models
{
    public class DeviceSupplier
    {
        [Key]
        [Required]
        [StringLength(25)]
        public string CompamyName { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

    }
}