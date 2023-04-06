

namespace appointment.Model
{
    public class appointments
    {

        public int ID { get; set; }
        public DateTime BookDate { get; set; }
       // public DateTime EndDate { get; set; }
       
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        
        public virtual Patients? Patient { get; set; }
        public virtual Doctors? Doctor { get; set; }

       
    }
}
