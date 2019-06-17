using CallCenterManagementSystem.Core;
using System.Linq;
using System.Web.Mvc;

namespace CallCenterManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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