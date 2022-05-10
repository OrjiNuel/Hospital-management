using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Entities
{
    public class EmployeeType
    {
        [Key]
        public int ID { get; set; }
        public string TypeName { get; set; }
    }
}
