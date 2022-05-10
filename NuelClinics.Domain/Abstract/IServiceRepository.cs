using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Abstract
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetAllServices { get; }
        IEnumerable<Service> SearchService(string searchTerm);
        void SaveService(Service service);
        void UpdateService(Service service);
        void DeleteService(Service service);
        Service GetServiceById(int Id);
        void Dispose();
    }
}
