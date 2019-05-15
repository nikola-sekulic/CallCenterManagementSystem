using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCenterManagementSystem.Models;

namespace CallCenterManagementSystem.Core.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        IEnumerable<Specialist> GetActiveSpecialists(string query);
        Employee GetEmployee(int id);
        Employee GetProfile(string userId);
        void Add(Employee employee);
        void Remove(Employee employeeInDb);
    }
}
