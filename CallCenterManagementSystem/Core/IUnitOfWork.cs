using CallCenterManagementSystem.Core.Repositories;
using System;

namespace CallCenterManagementSystem.Core
{
    public interface IUnitOfWork:IDisposable
    {
        IApplicationUserRepository Users { get; }
        IEmployeeRepository Employees { get; }
        IDepartmentRepository Departments { get; }
        IDesignationRepository Designations { get; }
        IReclamationRepository Reclamations { get; }
        ISoldDeviceRepository SoldDevices { get; }

        int Complete();
    }
}