using CallCenterManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterManagementSystem.Core.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
    }
}
