using appointment.Dto;
using appointment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly AppointmentDbContext _context;

        public PatientController(AppointmentDbContext context)
        {
            _context = context;
        }


        [HttpGet("Patients")]
        public List<Patients> GetAllPatients()
        {
            var db = _context.Patients.ToList();
            return db;
        }

        [HttpGet("{id}")]
        public ActionResult<Patients> GetById(int id)
        {

            var res = _context.Patients.FirstOrDefault(p => p.Id == id);
            if (res == null)
            {

                return NotFound();
            }

            return res;

        }

        [HttpPost]
        public ActionResult AddPatient(CreatePatiantDto patient)
        {

            var res = new Patients()
            {
                Name = patient.Name,
                IdNumber = patient.IdNumber,
            };

            if (res == null)
            {
                return NoContent();
            }
      
            _context.Patients.Add(res);
            _context.SaveChanges();


            return Ok(res);
        }


    }
}
