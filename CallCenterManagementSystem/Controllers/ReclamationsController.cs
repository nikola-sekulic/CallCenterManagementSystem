using CallCenterManagementSystem.Models;
using CallCenterManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AutoMapper;

namespace CallCenterManagementSystem.Controllers
{
    public class ReclamationsController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}