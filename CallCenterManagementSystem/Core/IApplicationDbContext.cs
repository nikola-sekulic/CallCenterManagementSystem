using System.Data.Entity;
using CallCenterManagementSystem.Core.Models;

namespace CallCenterManagementSystem.Models
{
    public interface IApplicationDbContext
    {
        DbSet<Agent> Agents { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
        DbSet<Buyer> Buyers { get; set; }
        DbSet<CallHistory> CallHistories { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Designation> Designations { get; set; }
        DbSet<DeviceSupplier> DeviceSuppliers { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<Reclamation> Reclamations { get; set; }
        DbSet<ReclamationType> ReclamationTypes { get; set; }
        DbSet<SoldDevice> SoldDevices { get; set; }
        DbSet<Specialist> Specialists { get; set; }
        DbSet<Supervisor> Supervisors { get; set; }
        DbSet<UserNotification> UserNotifications { get; set; }
    }
}