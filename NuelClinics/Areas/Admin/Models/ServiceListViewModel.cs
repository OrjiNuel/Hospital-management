using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NuelClinics.Areas.Admin.Models
{
    public class ServiceListViewModel
    {
        public IEnumerable<Service> Services { get; set; }
    }

    public class ServiceActionViewModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}