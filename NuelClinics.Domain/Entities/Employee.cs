using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }       
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date_Of_Birth { get; set; }

        public int Age { get; set; }

        [DataType(DataType.Date)]
        public DateTime Start_Date { get; set; }

        public int EmployeeTypeId { get; set; } 

        public IEnumerable<EmployeeType> EmployeeTypes { get; set; }
    }
}
