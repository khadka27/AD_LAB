using Microsoft.AspNetCore.Mvc;
using WeekTwo.Model;

namespace AppointmentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase


    {
        // In-memory list simulating a database.
        private static List<Appointment> Appointments = new List<Appointment>
        {
            new Appointment { }
        };

        // GET: api/appointment
        [HttpGet]
        public ActionResult<IEnumerable<Appointment>> GetAppointments()
        {
            return Ok(Appointments);
        }

        // GET: api/appointment/{id}
        [HttpGet("{id}")]
        public ActionResult<Appointment> GetAppointment(int id)
        {
            var appointment = Appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null)
                return NotFound();
            return Ok(appointment);
        }

        // POST: api/appointment
        [HttpPost]
        public ActionResult<Appointment> CreateAppointment([FromBody] Appointment appointment)
        {
            appointment.Id = Appointments.Any() ? Appointments.Max(a => a.Id) + 1 : 1;
            Appointments.Add(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        // PUT: api/appointment/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, [FromBody] Appointment updatedAppointment)
        {
            var appointment = Appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null)
                return NotFound();

            appointment.Title = updatedAppointment.Title;
            appointment.AppointmentDate = updatedAppointment.AppointmentDate;
            appointment.Description = updatedAppointment.Description;
            return NoContent();
        }

        // DELETE: api/appointment/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            var appointment = Appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null)
                return NotFound();

            Appointments.Remove(appointment);
            return NoContent();
        }
    }
}
