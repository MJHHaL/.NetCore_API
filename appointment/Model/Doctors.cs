namespace appointment.Model
{
    public class Doctors
    {
        public Doctors()
        {
            appointments = new HashSet<appointments>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int? ClinicID { get; set; }
        public int? PatientRecordId { get; set; }
        public virtual Clinic? Clinic { get; set; }
        public virtual PatientRecord? PatientRecord { get; set; }
        public virtual ICollection<appointments> appointments { get; set; }
    }
}
