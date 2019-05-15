using CallCenterManagementSystem.Core.Repositories;
using CallCenterManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Persistance.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }
    }
}