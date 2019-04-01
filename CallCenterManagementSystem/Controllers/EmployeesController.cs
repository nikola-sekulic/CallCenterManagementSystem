using CallCenterManagementSystem.Models;
using CallCenterManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AutoMapper;
using CallCenterManagementSystem.Dtos;

namespace CallCenterManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var departments = _context.Departments.ToList();
            var designations = _context.Designations.ToList();
            var viewModel = new NewEmployeeViewModel
            {
                Employee = new Employee(),
                Departments = departments,
                Designations = designations
                
            };
            return View("EmployeeForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewEmployeeViewModel
                {
                    Employee = employee,
                    Departments = _context.Departments.ToList(),
                    Designations = _context.Designations.ToList()
                };
                
                return View("EmployeeForm", viewModel);
            }
            if (employee.Id == 0)
                _context.Employees.Add(employee);
            else
            {
                var employeeInDb = _context.Employees.Single(m => m.Id == employee.Id);

                employeeInDb.Name = employee.Name;
                employeeInDb.DateStarted = employee.DateStarted;
                employeeInDb.DateEnded = employee.DateEnded;
                employeeInDb.DepartmentId = employee.DepartmentId;
                employeeInDb.DesignationId = employee.DesignationId;
                employeeInDb.SupervisorId = employee.SupervisorId;
                employeeInDb.Qualification = employee.Qualification;
                employeeInDb.Gender = employee.Gender;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Employees");
        }

        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var employee = _context.Employees
                .Include(c => c.Department)
                .Include(c => c.Designation)
                .SingleOrDefault(c => c.Id == id);

            if (employee == null)
                return HttpNotFound();

            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employee == null)
                return HttpNotFound();

            var viewModel = new NewEmployeeViewModel
            {
                Employee = employee,
                Departments = _context.Departments.ToList(),
                Designations = _context.Designations.ToList()
            };

            return View("EmployeeForm", viewModel);
        }
    }
}