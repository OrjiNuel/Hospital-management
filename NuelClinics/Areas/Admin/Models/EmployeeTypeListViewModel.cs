using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NuelClinics.Areas.Admin.Models
{
    public class EmployeeTypeListViewModel
    {
        public IEnumerable<EmployeeType> EmployeeTypes { get; set; }
    }

    public class EmployeeTypeActionViewModel
    {
        [Key]
        public int ID { get; set; }
        public string TypeName { get; set; }
    }
}