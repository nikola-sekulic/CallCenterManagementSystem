using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenterManagementSystem.Models;
using CallCenterManagementSystem.Core.ViewModels;

namespace CallCenterManagementSystem.Core.Repositories
{
    public interface IApplicationUserRepository
    {
        List<UserViewModel> GetUsers();
        ApplicationUser GetUser(string id);
    }
}
