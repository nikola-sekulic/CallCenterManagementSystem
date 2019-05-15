using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CallCenterManagementSystem.Core;
using CallCenterManagementSystem.Core.Repositories;
using CallCenterManagementSystem.Models;
using CallCenterManagementSystem.Persistance.Repositories;

namespace CallCenterManagementSystem.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IApplicationUserRepository Users { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IDepartmentRepository Departments { get; private set; }
        public IDesignationRepository Designations { get; private set; }
        public IReclamationRepository Reclamations { get; private set; }
        public ISoldDeviceRepository SoldDevices { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Employees = new EmployeeRepository(_context);
            Designations = new DesignationRepository(_context);
            Departments = new DepartmentRepository(_context);
            Reclamations = new ReclamationRepository(_context);
            SoldDevices = new SoldDevicesRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

       

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}