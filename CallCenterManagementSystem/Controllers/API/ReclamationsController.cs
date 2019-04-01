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
    public class ReclamationsController : ApiController
    {
        private ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CreateNewReclamations(NewReclamationDto newReclamation)
        {
            var agent = _context.Employees.Single(c => c.Id == newReclamation.EmployeeId);
            var specialist = _context.Employees.Single(c => c.Id == newReclamation.SpecialistId);
            var soldDevice = _context.SoldDevices.Single(c => c.Id == newReclamation.SoldDeviceId);
            var type = _context.ReclamationTypes.Single(c => c.Id == newReclamation.ReclamationTypeId);

            var reclamation = new Reclamation
            {
                Agent = agent,
                Specialist = specialist,
                SoldDevice = soldDevice,
                ReclamationType = type,
                ReclamationCreated=DateTime.Now
            };

            _context.Reclamations.Add(reclamation);
            _context.SaveChanges();

            return Ok(); 
        }
    }
}
