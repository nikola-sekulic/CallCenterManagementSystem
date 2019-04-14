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
using System.Data.Entity.Validation;

namespace CallCenterManagementSystem.Controllers.API
{
    public class ReclamationsController : ApiController
    {
        private ApplicationDbContext _context;

        public ReclamationsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult GetReclamations()
        {
            var reclamationsQuery = _context.Reclamations
                .Include(m => m.Agent)
                .Include(m => m.Specialist)
                .Include(m => m.SoldDevice)
                .Include(m => m.ReclamationType)
                .Include(m => m.SoldDevice.Buyer)
                .ToList()
                .Select(Mapper.Map<Reclamation, NewReclamationDto>);

            return Ok(reclamationsQuery);
        }

        public IHttpActionResult GetReclamation(int id)
        {
            var reclamation = _context.Reclamations.SingleOrDefault(c => c.Id == id);

            if (reclamation == null)
                return NotFound();

            return Ok(Mapper.Map<Reclamation, NewReclamationDto>(reclamation));
        }

        [HttpPost]
        public IHttpActionResult CreateNewReclamations(NewReclamationDto newReclamationDto)
        {
            var soldDevice = _context.SoldDevices.Single(c => c.Id == newReclamationDto.SoldDeviceId);

            if (soldDevice.ExpiredWarranty() == true)
                return BadRequest("Warranty for this device has expired.");

            if (!ModelState.IsValid)
                return BadRequest();
            var reclamation = Mapper.Map<NewReclamationDto, Reclamation>(newReclamationDto);

            _context.Reclamations.Add(reclamation);
            _context.SaveChanges();

            newReclamationDto.Id = reclamation.Id;
            return Ok();
        }

        [HttpPut]
        public void UpdateReclamation(int id, NewReclamationDto reclamationDbo)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var reclamationInDb = _context.Reclamations.SingleOrDefault(c => c.Id == id);

            if (reclamationInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(reclamationDbo, reclamationInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteReclamation(int id)
        {
            var reclamationInDb = _context.Reclamations.SingleOrDefault(c => c.Id == id);

            if (reclamationInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Reclamations.Remove(reclamationInDb);
            _context.SaveChanges();
        }

    }
}

