using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuelClinics.Areas.Admin.Models
{
    public class DepartmentListViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
    }

    public class DepartmentActionViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}