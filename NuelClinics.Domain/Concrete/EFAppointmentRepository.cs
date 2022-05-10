using NuelClinics.Domain.Abstract;
using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Concrete
{
    public class EFAppointmentRepository : IAppointmentRepository
    {
        private readonly EFDbContext _dbcontext;
        public EFAppointmentRepository()
        {
            _dbcontext = new EFDbContext();
        }

        public IEnumerable<Appointment> GetAllAppointments
        {
            get { return _dbcontext.Appointments; }
        }


        public IEnumerable<Appointment> SearchAppointment(string searchTerm)
        {


            var appointments = _dbcontext.Appointments.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                appointments = appointments.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return appointments.ToList();
        }

        public void SaveAppointment(Appointment appointment)
        {
            _dbcontext.Appointments.Add(appointment);

            _dbcontext.SaveChanges();
        }

        public void UpdateAppointment(Appointment appointment)
        {

            _dbcontext.Entry(appointment).State = System.Data.Entity.EntityState.Modified;

            _dbcontext.SaveChanges();
        }
        public void DeleteAppointment(Appointment appointment)
        {

            _dbcontext.Entry(appointment).State = System.Data.Entity.EntityState.Deleted;

            _dbcontext.SaveChanges();
        }

        public Appointment GetAppointmentById(int Id)
        {
            return _dbcontext.Appointments.Find(Id);
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
