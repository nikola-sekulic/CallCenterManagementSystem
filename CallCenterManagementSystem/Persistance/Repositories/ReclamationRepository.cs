using CallCenterManagementSystem.Core.Repositories;
using CallCenterManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CallCenterManagementSystem.Persistance.Repositories
{
    public class ReclamationRepository : IReclamationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReclamationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Reclamation reclamation)
        {
            _context.Reclamations.Add(reclamation);
        }

        public Reclamation GetReclamation(int id)
        {
            return _context.Reclamations
               .Include(e => e.Agent)
               .Include(e => e.Specialist)
               .Include(e => e.SoldDevice)
               .Include(e => e.SoldDevice.Buyer)
               .Include(e => e.ReclamationType)
               .SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<Reclamation> GetReclamations()
        {
            return _context.Reclamations
                .Include(e => e.SoldDevice)
                .Include(e => e.Agent)
                .Include(e => e.Specialist)
                .Include(e => e.SoldDevice.Buyer)
                .Include(e => e.ReclamationType)
                .ToList();
        }

        public void Remove(Reclamation reclamation)
        {
            _context.Reclamations.Remove(reclamation);
        }
    }
}