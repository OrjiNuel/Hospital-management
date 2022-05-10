using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Abstract
{
    public interface IEmployeeTypeRepository
    {
        IEnumerable<EmployeeType> GetAllEmployeeTypes { get; }
        IEnumerable<EmployeeType> SearchEmployeeType(string searchTerm);
        void SaveEmployeeType(EmployeeType employeeType);
        void UpdateEmployeeType(EmployeeType employeeType);
        void DeleteEmployeeType(EmployeeType employeeType);
        EmployeeType GetEmployeeTypeById(int Id);
        void Dispose();
    }
}
