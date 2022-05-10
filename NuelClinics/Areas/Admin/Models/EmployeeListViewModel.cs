using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NuelClinics.Areas.Admin.Models
{
    public class EmployeeListViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<EmployeeType> EmployeeTypes { get; set; }
        public int? EmployeeTypeId { get; set; }
    }

    public class EmployeeActionViewModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public int EmployeeTypeId { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date_Of_Birth { get; set; }

        public int Age { get; set; }

        [DataType(DataType.Date)]
        public DateTime Start_Date { get; set; }

        public IEnumerable<EmployeeType> EmployeeTypes { get; set; }
    }
}