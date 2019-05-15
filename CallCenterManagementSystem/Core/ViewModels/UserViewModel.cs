using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Core.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }
        public string Role { get; set; }
        public bool? IsActive { get; set; }
    }
}