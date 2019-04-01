using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CallCenterManagementSystem.Models;

namespace CallCenterManagementSystem.ViewModels
{
    public class NewReclamationViewModel
    {
        public Reclamation Reclamation { get; set; }
        public IEnumerable<CallHistory> CallHistories { get; set; }
        public IEnumerable<Buyer> Buyers { get; set; }

    }
}