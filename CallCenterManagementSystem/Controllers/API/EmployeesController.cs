using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CallCenterManagementSystem.Dtos;
using CallCenterManagementSystem.Models;
using CallCenterManagementSystem.Core;

namespace CallCenterManagementSystem.Views.Employees.API
{
    [Authorize]
    public class EmployeesController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IHttpActionResult GetEmployees (string query = null)
        {
            var employeesQuery = _unitOfWork.Employees.GetEmployees();

            if (!String.IsNullOrWhiteSpace(query))
                employeesQuery = _unitOfWork.Employees.GetActiveSpecialists(query);

            var employeesDtos = employeesQuery
            .Select(Mapper.Map<Employee, EmployeeDto>);
            
            return Ok(employeesDtos);
        }

        public IHttpActionResult GetEmployee(int id)
        {
            var employee = _unitOfWork.Employees.GetEmployee(id);

            if (employee == null)
                return NotFound();

            return Ok(Mapper.Map<Employee, EmployeeDto>(employee));
        }

        [HttpDelete]
        public void DeleteEmployee(int id)
        {
            var employeeInDb = _unitOfWork.Employees.GetEmployee(id);

            if (employeeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _unitOfWork.Employees.Remove(employeeInDb);

            _unitOfWork.Complete();
        }
    }
}
