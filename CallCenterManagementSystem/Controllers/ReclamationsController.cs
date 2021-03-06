﻿using CallCenterManagementSystem.Models;
using CallCenterManagementSystem.ViewModels;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CallCenterManagementSystem.Core;

namespace CallCenterManagementSystem.Controllers
{
    public class ReclamationsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ReclamationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.SupervisorRoleName))
                return View("Index");
            return View("ReadOnlyIndex");
        }

        public ActionResult New()
        {
            var userId = User.Identity.GetUserId();
            var agent = _unitOfWork.Employees.GetProfile(userId);
            ViewBag.agent = agent;
            return View();
        }

        public ActionResult Edit(int id)
        {
            var reclamation = _unitOfWork.Reclamations.GetReclamation(id);

            if (reclamation == null)
                return HttpNotFound();

            var viewModel = new NewReclamationViewModel
            {
                Reclamation = reclamation,
                SoldDevices = _unitOfWork.SoldDevices.GetSoldDevices(),
                Employees = _unitOfWork.Employees.GetEmployees()
            };

            return View(reclamation);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            var reclamation = _unitOfWork.Reclamations.GetReclamation(id);

            TryUpdateModel(reclamation, null, null, new string[] { "AgentId", "SpecialistId","SoldDeviceId", "ReclamationCreated" });

            if (ModelState.IsValid)
            {
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            return View(reclamation);
        }


    }
}