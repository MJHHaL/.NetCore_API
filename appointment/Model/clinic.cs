namespace appointment.Model
{
    public class Clinic
    {
        public Clinic()
        {
            Doctor = new HashSet<Doctors>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Doctors> Doctor{ get; set; }
        
    }
}
