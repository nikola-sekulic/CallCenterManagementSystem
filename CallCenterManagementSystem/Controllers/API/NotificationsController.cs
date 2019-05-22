using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CallCenterManagementSystem.Core.Models;
using CallCenterManagementSystem.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace CallCenterManagementSystem.Controllers.API
{
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Notifications
        public IEnumerable<Notification> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = db.UserNotifications
                .Where(un => un.UserId == userId && !un.isRead)
                .Select(un => un.Notification)
                .Include(n => n.Reclamation.Agent)
                .ToList();

            return notifications;
        }

        // GET: api/Notifications/5
        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();

            var notifications = db.UserNotifications
               .Where(un => un.UserId == userId && !un.isRead)
               .ToList();

            notifications.ForEach(n => n.Read());

            db.SaveChanges();

            return Ok();
        }

    }
}