using appointment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly AppointmentDbContext _context;

        public ClinicController(AppointmentDbContext context)
        {
            _context = context;
        }
    }
}
