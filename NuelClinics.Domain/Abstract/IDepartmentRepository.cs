using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Abstract
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments { get; }
        IEnumerable<Department> SearchDepartment(string searchTerm);
        void SaveDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(Department department);
        Department GetDepartmentById(int Id);
        void Dispose();
    }
}
