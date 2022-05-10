using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Entities
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual int WardId { get; set; }
        public virtual Ward Ward { get; set; }
    }
}
