using appointment.Model;

namespace appointment.Dto
{
    public class CreateAppoitnmentDto
    {

        public DateTime BookDate { get; set; }
        public int IdNumber { get; set; }
        public string DoctorName { get; set; }
        public string ClincName  { get; set; }
    }
}
