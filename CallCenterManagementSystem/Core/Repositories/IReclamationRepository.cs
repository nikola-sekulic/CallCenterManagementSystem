using CallCenterManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterManagementSystem.Core.Repositories
{
    public interface IReclamationRepository
    {
        IEnumerable<Reclamation> GetReclamations();
        Reclamation GetReclamation(int id);
        void Add(Reclamation reclamation);
        void Remove(Reclamation reclamation);
    }
}
