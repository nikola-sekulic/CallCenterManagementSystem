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
using CallCenterManagementSystem.Persistance;

namespace CallCenterManagementSystem.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private UnitOfWork _unitOfWork;

        public EmployeesController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Agent employee)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewEmployeeViewModel
                {
                    Employee = employee,
                    Departments = _unitOfWork.Departments.GetDepartments(),
                    Designations = _unitOfWork.Designations.GetDesignations()
                };

                return View("EmployeeForm", viewModel);
            }

            var employeeInDb = _unitOfWork.Employees.GetEmployee(employee.Id);

                employeeInDb.Name = employee.Name;
                employeeInDb.DateStarted = employee.DateStarted;
                employeeInDb.DateEnded = employee.DateEnded;
                employeeInDb.DepartmentId = employee.DepartmentId;
                employeeInDb.Qualification = employee.Qualification;
                employeeInDb.Gender = employee.Gender;

            _unitOfWork.Complete();
            return RedirectToAction("Index", "Employees");
        }

        // GET: Employees
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                if(User.IsInRole(RoleName.SupervisorRoleName))
                    return View();
            }
            return HttpNotFound();
        }

        public ActionResult Details(int id)
        {
            var employee = _unitOfWork.Employees.GetEmployee(id);

            if (employee == null)
                return HttpNotFound();

            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            var employee = _unitOfWork.Employees.GetEmployee(id);

            if (employee == null)
                return HttpNotFound();

            var viewModel = new NewEmployeeViewModel
            {
                Employee = employee,
                Departments = _unitOfWork.Departments.GetDepartments(),
                Designations = _unitOfWork.Designations.GetDesignations()
            };

            return View("EmployeeForm", viewModel);
        }
    }
}