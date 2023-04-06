using appointment.Model;

namespace appointment.Dto
{
    public class CreateDoctor
    {

        public string Name { get; set; }
        public CreateClinicDto Clinic { get; set; }
       

    }
}
