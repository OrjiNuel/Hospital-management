using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NuelClinics.Models
{
    public class AppointmentViewModel
    {
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public int? ServiceId { get; set; }
    }

    public class AppointmentActionViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Room is required.")]
        public string Name { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Room is required.")]
        public string Phone { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Room is required.")]
        public string Email { get; set; }

        [Display(Name = "Book a Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Display(Name = "Card Numer")]
        [Required(ErrorMessage = "Room is required.")]
        public int CardNum { get; set; }

        [Display(Name = "Hospital Services")]
        [Required(ErrorMessage = "Room is required.")]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        public IEnumerable<Service> Services { get; set; }

    }
}