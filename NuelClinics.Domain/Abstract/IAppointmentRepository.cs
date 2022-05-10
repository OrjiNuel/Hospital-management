using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Abstract
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAllAppointments { get; }
        IEnumerable<Appointment> SearchAppointment(string searchTerm);
        void SaveAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(Appointment appointment);
        Appointment GetAppointmentById(int Id);
        void Dispose();
    }
}
