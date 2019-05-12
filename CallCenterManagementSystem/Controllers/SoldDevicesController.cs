using CallCenterManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CallCenterManagementSystem.Controllers
{
    public class SoldDevicesController : Controller
    {
        private ApplicationDbContext _context;

        public SoldDevicesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: SoldDevice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var soldDevice = _context.SoldDevices
                .Include(c => c.DeviceSupplier)
                .SingleOrDefault(c => c.Id == id);

            if (soldDevice == null)
                return HttpNotFound();

            return View(soldDevice);
        }
    }
}