using NuelClinics.Domain.Abstract;
using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Concrete
{
    public class EFServiceRepository : IServiceRepository
    {
        private readonly EFDbContext _dbcontext;
        public EFServiceRepository()
        {
            _dbcontext = new EFDbContext();
        }

        public IEnumerable<Service> GetAllServices
        {
            get { return _dbcontext.Services; }
        }


        public IEnumerable<Service> SearchService(string searchTerm)
        {
            var services = _dbcontext.Services.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                services = services.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return services.ToList();
        }

        public void SaveService(Service service)
        {
            _dbcontext.Services.Add(service);

            _dbcontext.SaveChanges();
        }

        public void UpdateService(Service service)
        {

            _dbcontext.Entry(service).State = System.Data.Entity.EntityState.Modified;

            _dbcontext.SaveChanges();
        }
        public void DeleteService(Service service)
        {

            _dbcontext.Entry(service).State = System.Data.Entity.EntityState.Deleted;

            _dbcontext.SaveChanges();
        }

        public Service GetServiceById(int Id)
        {
            return _dbcontext.Services.Find(Id);
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
