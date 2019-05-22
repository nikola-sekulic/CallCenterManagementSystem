using CallCenterManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.Core.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }

        [Required]
        public Reclamation Reclamation { get; private set; }

        protected Notification()
        {
        }

        private Notification(NotificationType type,Reclamation reclamation)
        {
            if (reclamation == null)
                throw new ArgumentNullException("reclamation");

            Type = type;
            Reclamation = reclamation;
            DateTime = DateTime.Now;
        }

        public static Notification ReclamationCreated(Reclamation reclamation)
            {
                return new Notification(NotificationType.ReclamationCreated, reclamation);
            }
    }
}