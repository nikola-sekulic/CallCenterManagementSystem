using AutoMapper;
using System.Linq;
using System.Net;
using System.Web.Http;
using CallCenterManagementSystem.Dtos;
using CallCenterManagementSystem.Models;
using CallCenterManagementSystem.Core;

namespace CallCenterManagementSystem.Controllers.API
{
    public class ReclamationsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public ReclamationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IHttpActionResult GetReclamations()
        {
            var reclamationsQuery = _unitOfWork.Reclamations.GetReclamations()
                .Select(Mapper.Map<Reclamation, NewReclamationDto>);

            

            return Ok(reclamationsQuery);
        }

        public IHttpActionResult GetReclamation(int id)
        {
            var reclamation = _unitOfWork.Reclamations.GetReclamation(id);

            if (reclamation == null)
                return NotFound();

            return Ok(Mapper.Map<Reclamation, NewReclamationDto>(reclamation));
        }

        [HttpPost]
        public IHttpActionResult CreateNewReclamations(NewReclamationDto newReclamationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var soldDevice = _unitOfWork.SoldDevices.GetSoldDevice(newReclamationDto.SoldDeviceId);

            if (soldDevice.ExpiredWarranty() == true)
                return BadRequest("Warranty for this device has expired.");

            var reclamation = Mapper.Map<NewReclamationDto, Reclamation>(newReclamationDto);

            if (User.IsInRole(RoleName.AgentRoleName))
            {
                reclamation.Agent = _unitOfWork.Employees.GetAgent(reclamation.AgentId);
                reclamation.Create();
            }

            _unitOfWork.Reclamations.Add(reclamation);
            _unitOfWork.Complete();

            newReclamationDto.Id = reclamation.Id;
            return Ok();
        }

        [HttpPut]
        public void UpdateReclamation(int id, NewReclamationDto reclamationDbo)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var reclamationInDb = _unitOfWork.Reclamations.GetReclamation(id);

            if (reclamationInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(reclamationDbo, reclamationInDb);

            _unitOfWork.Complete();
        }

        [HttpDelete]
        public void DeleteReclamation(int id)
        {
            var reclamationInDb = _unitOfWork.Reclamations.GetReclamation(id);

            if (reclamationInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _unitOfWork.Reclamations.Remove(reclamationInDb);
            _unitOfWork.Complete();
        }

    }
}

