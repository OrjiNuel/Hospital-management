using NuelClinics.Domain.Abstract;
using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Concrete
{
    public class EFEmployeeTypeRepository : IEmployeeTypeRepository
    {
        private readonly EFDbContext _dbcontext;
        public EFEmployeeTypeRepository()
        {
            _dbcontext = new EFDbContext();
        }

        public IEnumerable<EmployeeType> GetAllEmployeeTypes
        {
            get { return _dbcontext.EmployeeTypes; }
        }


        public IEnumerable<EmployeeType> SearchEmployeeType(string searchTerm)
        {


            var employeeTypes = _dbcontext.EmployeeTypes.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                employeeTypes = employeeTypes.Where(a => a.TypeName.ToLower().Contains(searchTerm.ToLower()));
            }

            return employeeTypes.ToList();
        }

        public void SaveEmployeeType(EmployeeType employeeType)
        {
            _dbcontext.EmployeeTypes.Add(employeeType);

            _dbcontext.SaveChanges();
        }

        public void UpdateEmployeeType(EmployeeType employeeType)
        {

            _dbcontext.Entry(employeeType).State = System.Data.Entity.EntityState.Modified;

            _dbcontext.SaveChanges();
        }
        public void DeleteEmployeeType(EmployeeType employeeType)
        {

            _dbcontext.Entry(employeeType).State = System.Data.Entity.EntityState.Deleted;

            _dbcontext.SaveChanges();
        }

        public EmployeeType GetEmployeeTypeById(int Id)
        {
            return _dbcontext.EmployeeTypes.Find(Id);
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
