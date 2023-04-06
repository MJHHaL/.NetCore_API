using appointment.Dto;
using appointment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appointment.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly AppointmentDbContext _context;

        public AppointmentController(AppointmentDbContext context)
        {
            _context = context;
        }

        #region 
        //List<Patients> patient = new List<Patients>();
        //public AppointmentController()
        //{
        //    patient.Add(new Patients { 
        //        Id = 1,
        //        Name = "Mohammed",
        //        Description = "hot and pain"

        //    });
        //    patient.Add(new Patients
        //    {
        //        Id = 2,
        //        Name = "Ali",
        //        Description = "hot onlay"

        //    });
        //}
        #endregion


        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var db = _context.Appointments.Include(x => x.Patient).Include(e => e.Doctor).ThenInclude(i => i.Clinic).ToList();
                return Ok(db);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpGet("{id}")]
        public ActionResult<appointments> GetById(int id)
        {

            var res = _context.Patients.FirstOrDefault(p => p.Id == id);
            if (res == null)
            {

                return NotFound();
            }

            return Ok(res);

        }



        [HttpPost]
        public ActionResult AppointmentBooking(CreateAppoitnmentDto appoitnment)
        {

            
            try
            {
                
                DateTime dateTime = new DateTime();
                dateTime = DateTime.Now;
                var date = dateTime.ToShortDateString();
                var time = dateTime.ToShortTimeString();
                
                var IdNumber = _context.Patients.Where(p => p.IdNumber == appoitnment.IdNumber).FirstOrDefault();
                var doctor = _context.Doctors.Where(d => d.Name == appoitnment.DoctorName && d.Clinic.Name == appoitnment.ClincName).FirstOrDefault();
                var checkByDate = _context.Appointments.ToList();

                foreach (var itme in checkByDate)
                {
                    if (itme.BookDate.ToShortDateString() == date)
                    {
                          var differenceTime = DateTime.Now.Minute - itme.BookDate.Minute;
                            if (differenceTime != 60)
                            {
                                return BadRequest("booked up");

                            }
                        var res = new appointments()
                        {
                            PatientID = IdNumber.Id,
                            BookDate = DateTime.Now,
                            DoctorID = doctor.ID,
                        };
                        _context.Appointments.Add(res);
                    }
                }
                    _context.SaveChanges();
                    return Ok();
            }
            catch
            {
                return BadRequest();
            }
            

           
        }



        [HttpDelete("{id}")]
        public void AppointmentDelete(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id is not found");
            }
            var app = _context.Appointments.Find(id);
            if (app == null)
            {
                throw new Exception("The values ​​are empty");
            }
            _context.Appointments.Remove(app);
            _context.SaveChanges();

        }
    }
}
