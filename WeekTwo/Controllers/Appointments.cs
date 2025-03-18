using Microsoft.AspNetCore.Mvc;
using StudentDatabaseAPI.Services;
using WeekTwo.Model;

namespace WeekTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly DatabaseHandler _databaseHandler;

        public AppointmentsController(DatabaseHandler handler)
        {
            _databaseHandler = handler;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> Get()
        {
            try
            {
                var appointments = await _databaseHandler.GetAppointment();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> Get(int id)
        {
            try
            {
                var appointment = await _databaseHandler.GetAppointmentById(id);
                if (appointment == null)
                    return NotFound($"Appointment with ID {id} not found");

                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/Appointments
        [HttpPost]
        public async Task<ActionResult<Appointment>> Post([FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _databaseHandler.AddAppointment(appointment);
                return CreatedAtAction(nameof(Get), new { id = appointment.Id }, appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/Appointments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Appointment appointment)
        {
            if (id != appointment.Id)
                return BadRequest("ID in URL does not match ID in request body");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var exists = await _databaseHandler.GetAppointmentById(id);
                if (exists == null)
                    return NotFound($"Appointment with ID {id} not found");

                var result = await _databaseHandler.UpdateAppointment(appointment);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var appointment = await _databaseHandler.GetAppointmentById(id);
                if (appointment == null)
                    return NotFound($"Appointment with ID {id} not found");

                var result = await _databaseHandler.DeleteAppointment(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
