using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Abstract
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees { get; }
        IEnumerable<Employee> SearchEmployee(string searchTerm);
        void SaveEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Employee GetEmployeeById(int Id);
        void Dispose();
    }
}
