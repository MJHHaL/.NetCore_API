namespace appointment.Model
{
    public class Patients
    {

        public int Id { get; set; }
        public int IdNumber { get; set; }
        public string Name { get; set; }
        public virtual PatientRecord PatientRecord { get; set; }
        
    }
}
