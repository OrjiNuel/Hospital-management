using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Entities
{
    public class Pharmaceutical
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime Exp_Date { get; set; }
    }
}
