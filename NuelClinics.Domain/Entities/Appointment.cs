using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Entities
{
    public class Appointment
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required.")]
        public string Name { get; set; }

        [Display(Name = "Mobile Phone")]
        [Required(ErrorMessage = "Phone number is required.")]
        public string Phone { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required.")]
        public string Email { get; set; }

        [Display(Name = "Book a Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Display(Name = "Card Number")]
        [Required(ErrorMessage = "Card Number is required.")]
        public int CardNum { get; set; }

        [Display(Name = "Service")]
        [Required(ErrorMessage = "Service is required.")]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}
