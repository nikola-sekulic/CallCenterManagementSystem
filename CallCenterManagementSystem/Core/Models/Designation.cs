﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Models
{
    public class Designation
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        public readonly static int Supervisor = 1;
        public readonly static int Agent = 2;
        public readonly static int Specialist = 3;
    }
}