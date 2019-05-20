using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using CallCenterManagementSystem.Persistance.EntityConfigurations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CallCenterManagementSystem.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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

            modelBuilder.Entity<Agent>()
                .Property(e => e.SupervisorId).HasColumnName("SupervisorId");

            modelBuilder.Entity<Specialist>()
                .Property(e => e.SupervisorId).HasColumnName("SupervisorId");
                
                
        }
    }
}