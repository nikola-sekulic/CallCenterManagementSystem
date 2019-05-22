using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CallCenterManagementSystem.Core.Repositories;
using CallCenterManagementSystem.Models;

namespace CallCenterManagementSystem.Persistance.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees
                .Include(c => c.Designation)
                .Include(c => c.Department)
                .SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees
                .Include(c => c.Designation)
                .Include(c => c.Department)
                .ToList();
        }

        public IEnumerable<Specialist> GetActiveSpecialists(string query)
        {
            return _context.Specialists
                .Include(c => c.Designation)
                .Include(c => c.Department)
                .Where(c=>c.Name.Contains(query)
                && c.DateEnded == null)
                .ToList();
        }

        public Employee GetProfile(string userId)
        {
            return _context.Employees
                .Include(c=>c.User)
                .SingleOrDefault(c => c.UserId == userId);
        }

        public Agent GetAgent(int agentId)
        {
            return _context.Agents
                .Include(c => c.Supervisor)
                .Include(c => c.Supervisor.User)
                .Include(c => c.User)
                .SingleOrDefault(c => c.Id == agentId);
        }

        public void Remove(Employee employee)
        {
            _context.Employees.Remove(employee);
        }
    }
}