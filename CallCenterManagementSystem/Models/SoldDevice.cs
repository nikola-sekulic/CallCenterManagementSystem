using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Models
{
    public class SoldDevice
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime WarrantyStartDate { get; set; }

        [Required]
        public DateTime WarrantyEndDate { get; set; }

        public DeviceSupplier DeviceSupplier { get; set; }

        public Buyer Buyer { get; set; }

        [Required]
        public int BuyerId { get; set; }

        [Required]
        public decimal Price { get; set; }

    }
}