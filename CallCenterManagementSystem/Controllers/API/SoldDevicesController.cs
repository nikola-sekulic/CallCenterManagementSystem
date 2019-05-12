using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CallCenterManagementSystem.Dtos;
using CallCenterManagementSystem.Models;
using System.Data.Entity;

namespace CallCenterManagementSystem.Controllers.API
{
    public class SoldDevicesController : ApiController
    {
        private ApplicationDbContext _context;

        public SoldDevicesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetSoldDevices(Nullable<int> query = null)
        {
            var SoldDevicesQuery = _context.SoldDevices.Include(m => m.DeviceSupplier).Include(m => m.Buyer);

            if (!String.IsNullOrWhiteSpace(query.ToString()))
                
                SoldDevicesQuery = SoldDevicesQuery.Where(m => m.Id==query);

            var SoldDevicesDtos = SoldDevicesQuery.ToList().Select(Mapper.Map<SoldDevice, SoldDeviceDto>);

            return Ok(SoldDevicesDtos);
        }

        public IHttpActionResult GetSoldDevice(int id)
        {
            var soldDevice = _context.SoldDevices.SingleOrDefault(m => m.Id == id);

            if (soldDevice == null)
                return NotFound();

            return Ok(Mapper.Map<SoldDevice, SoldDeviceDto>(soldDevice));

        }
    }
}
