using CallCenterManagementSystem.Core.Repositories;
using CallCenterManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Persistance.Repositories
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly IApplicationDbContext _context;

        public DesignationRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Designation> GetDesignations()
        {
            return _context.Designations.ToList();
        }

        public IEnumerable<Designation> GetDesignationsWithoutSupervisor()
        {
            return _context.Designations.Where(e=>e.Id!=Designation.Supervisor).ToList();
        }
    }
}