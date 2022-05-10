using NuelClinics.Domain.Abstract;
using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Concrete
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private readonly EFDbContext _dbcontext;
        public EFEmployeeRepository()
        {
            _dbcontext = new EFDbContext();
        }

        public IEnumerable<Employee> GetAllEmployees
        {
            get { return _dbcontext.Employees; }
        }


        public IEnumerable<Employee> SearchEmployee(string searchTerm)
        {


            var employees = _dbcontext.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                employees = employees.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return employees.ToList();
        }

        public void SaveEmployee(Employee employee)
        {
            _dbcontext.Employees.Add(employee);

            _dbcontext.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            var local = _dbcontext.Set<Employee>()
                         .Local
                         .FirstOrDefault(f => f.ID == employee.ID);
            if (local != null)
            {
                _dbcontext.Entry(local).State = EntityState.Detached;
            }
            _dbcontext.Entry(employee).State = EntityState.Modified;

            _dbcontext.SaveChanges();

            //_dbcontext.Entry(employee).State = System.Data.Entity.EntityState.Modified;

            //_dbcontext.SaveChanges();
        }
        public void DeleteEmployee(Employee employee)
        {

            _dbcontext.Entry(employee).State = System.Data.Entity.EntityState.Deleted;

            _dbcontext.SaveChanges();
        }

        public Employee GetEmployeeById(int Id)
        {
            return _dbcontext.Employees.Find(Id);
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}

