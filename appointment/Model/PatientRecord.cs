namespace appointment.Model
{
    public class PatientRecord
    {

        public PatientRecord()
        {
            Doctor = new HashSet<Doctors>();
        }
        public int Id { get; set; }
        public string CasePatint { get; set; }
        public int PatientID { get; set; }
        public virtual Patients Patient { get; set; }
        public virtual ICollection<Doctors> Doctor { get; set; }

    }
}
