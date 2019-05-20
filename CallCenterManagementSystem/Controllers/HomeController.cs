using CallCenterManagementSystem.Models;
using CallCenterManagementSystem.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallCenterManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            return View();
        }

        #region Dashboard Statistics

        public ActionResult TotalReclamations()
        {
            var reclamations = _unitOfWork.Reclamations.GetReclamations();
            return Json(reclamations.Count(), JsonRequestBehavior.AllowGet);
        }








        #endregion

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}