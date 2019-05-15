using CallCenterManagementSystem.Core.Repositories;
using CallCenterManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Persistance.Repositories
{
    public class SoldDevicesRepository : ISoldDeviceRepository
    {
        private readonly ApplicationDbContext _context;

        public SoldDevicesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SoldDevice> GetSoldDevices()
        {
            return _context.SoldDevices.ToList();
        }

        public SoldDevice GetSoldDevice(int id)
        {
            return _context.SoldDevices.SingleOrDefault(c => c.Id == id);
        }
    }
}