using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using CallCenterManagementSystem.Core.Models;
using CallCenterManagementSystem.Persistance.EntityConfigurations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CallCenterManagementSystem.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<DeviceSupplier> DeviceSuppliers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<SoldDevice> SoldDevices { get; set; }
        public DbSet<ReclamationType> ReclamationTypes { get; set; }
        public DbSet<CallHistory> CallHistories { get; set; }
        public DbSet<Reclamation> Reclamations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new ReclamationConfiguration());

            modelBuilder.Entity<Agent>()
                .HasRequired(e => e.Supervisor)
                .WithMany(e => e.Agents)
                .HasForeignKey(e => e.SupervisorId);

            modelBuilder.Entity<Specialist>()
                .HasRequired(e => e.Supervisor)
                .WithMany(e => e.Specialists)
                .HasForeignKey(e => e.SupervisorId);

            modelBuilder.Entity<UserNotification>()
                .HasRequired(e => e.User)
                .WithMany(e => e.UserNotifications)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Agent>()
                .Property(e => e.SupervisorId).HasColumnName("SupervisorId");

            modelBuilder.Entity<Specialist>()
                .Property(e => e.SupervisorId).HasColumnName("SupervisorId");
        }
    }
}