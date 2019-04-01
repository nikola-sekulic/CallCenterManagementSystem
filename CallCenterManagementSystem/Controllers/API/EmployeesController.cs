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

namespace CallCenterManagementSystem.Views.Employees.API
{
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext _context;
        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetEmployees (string query = null,string query2=null)
        {
            var employeesQuery = _context.Employees
                .Include(c => c.Designation)
                .Include(c => c.Department);

            if (!String.IsNullOrWhiteSpace(query))
                employeesQuery = employeesQuery.Where(c => c.Name.Contains(query) && c.DesignationId == Designation.Agent);

            if (!String.IsNullOrWhiteSpace(query2))
                employeesQuery = employeesQuery.Where(c => c.Name.Contains(query2)&&c.DesignationId==Designation.Specialist);


            var employeesDtos = employeesQuery
            .ToList()
            .Select(Mapper.Map<Employee, EmployeeDto>);

            return Ok(employeesDtos);
        }

        public IHttpActionResult GetEmployee(int id)
        {
            var employee = _context.Employees.SingleOrDefault(c => c.Id == id);


            if (employee == null)
                return NotFound();

            return Ok(Mapper.Map<Employee, EmployeeDto>(employee));

        }

        [HttpPost]
        public IHttpActionResult CreateEmployee(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employee = Mapper.Map<EmployeeDto, Employee>(employeeDto);
            _context.Employees.Add(employee);
            _context.SaveChanges();
            employeeDto.Id = employee.Id;
            return Created(new Uri(Request.RequestUri + "/" + employee.Id), employeeDto);


        }

        [HttpPut]
        public void UpdateCusutomer(int id, EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var employeeInDb = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employeeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(employeeDto, employeeInDb);


            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteEmployee(int id)
        {
            var employeeInDb = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employeeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();
        }
    }
}
