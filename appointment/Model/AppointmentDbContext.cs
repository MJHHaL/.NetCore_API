using Microsoft.EntityFrameworkCore;

namespace appointment.Model
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options):base(options)
        {
            
        }

        public virtual DbSet<appointments> Appointments { get; set; }
        public virtual DbSet<Clinic> Clinics  { get; set; }
        public virtual DbSet<Doctors> Doctors  { get; set; }
        public virtual DbSet<Patients>   Patients { get; set; }
        public virtual DbSet<PatientRecord> PatientRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
