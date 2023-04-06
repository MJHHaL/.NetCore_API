using appointment.Dto;
using appointment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {

        private readonly AppointmentDbContext _context;

        public DoctorsController(AppointmentDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public ActionResult GetAll()
        {

            var res = _context.Doctors.ToList();
            return Ok(res);

        }

        [HttpPost]
        public ActionResult AddDoctor(CreateDoctor createDoctor)
        {
            var clinic = _context.Clinics.Where(d => d.Name == createDoctor.Clinic.Name).FirstOrDefault();

            var NewDoctor = new Doctors()
            {

                Name = createDoctor.Name,
                Clinic = clinic


            };
            return Ok(NewDoctor);
        }

    }
}
