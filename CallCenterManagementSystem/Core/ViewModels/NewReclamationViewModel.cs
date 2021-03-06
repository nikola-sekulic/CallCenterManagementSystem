﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CallCenterManagementSystem.Models;

namespace CallCenterManagementSystem.ViewModels
{
    public class NewReclamationViewModel
    {
        public Reclamation Reclamation { get; set; }
        public IEnumerable<SoldDevice> SoldDevices { get; set; }
        public IEnumerable<ReclamationType> ReclamationTypes { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

    }
}