using NuelClinics.Domain.Abstract;
using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Concrete
{
    public class EFDepartmentRepository : IDepartmentRepository
    {
        private readonly EFDbContext _dbcontext;
        public EFDepartmentRepository()
        {
            _dbcontext = new EFDbContext();
        }

        public IEnumerable<Department> GetAllDepartments
        {
            get { return _dbcontext.Departments; }
        }


        public IEnumerable<Department> SearchDepartment(string searchTerm)
        {
            var products = _dbcontext.Departments.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return products.ToList();
        }

        public void SaveDepartment(Department department)
        {
            _dbcontext.Departments.Add(department);

            _dbcontext.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {

            _dbcontext.Entry(department).State = System.Data.Entity.EntityState.Modified;

            _dbcontext.SaveChanges();
        }
        public void DeleteDepartment(Department department)
        {

            _dbcontext.Entry(department).State = System.Data.Entity.EntityState.Deleted;

            _dbcontext.SaveChanges();
        }

        public Department GetDepartmentById(int Id)
        {
            return _dbcontext.Departments.Find(Id);
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
