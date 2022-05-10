using Microsoft.AspNet.Identity.EntityFramework;
using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuelClinics.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("EFDBContext") { }

        public static EFDbContext Create()
        {
            return new EFDbContext();
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Pharmaceutical> Pharmaceuticals { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<NuelClinicUser> ClinicUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
