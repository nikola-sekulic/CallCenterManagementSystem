﻿using CallCenterManagementSystem.Models;
using CallCenterManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AutoMapper;
using CallCenterManagementSystem.Persistance;
using Microsoft.AspNet.Identity;

namespace CallCenterManagementSystem.Controllers
{
    public class ReclamationsController : Controller
    {
        private ApplicationDbContext _context;
        private UnitOfWork _unitOfWork;


        public ReclamationsController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
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
            ViewBag.agentId = agent.Id;
            return View();
        }

        public ActionResult Edit(int id)
        {
            var reclamation = _context.Reclamations.SingleOrDefault(c => c.Id == id);

            if (reclamation == null)
                return HttpNotFound();

            var viewModel = new NewReclamationViewModel
            {
                Reclamation = reclamation,
                ReclamationTypes = _context.ReclamationTypes.ToList(),
                SoldDevices = _context.SoldDevices.ToList(),
                Employees = _context.Employees.ToList()
            };

            return View(reclamation);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            var reclamation = _context.Reclamations.Single(c => c.Id == id);

            TryUpdateModel(reclamation, null, null, new string[] { "AgentId", "SpecialistId","SoldDeviceId", "ReclamationCreated" });

            if (ModelState.IsValid)
            {
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reclamation);
        }


    }
}