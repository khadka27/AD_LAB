using Microsoft.AspNetCore.Mvc;
using StudentDatabaseAPI.Services;
using StudentService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private DatabaseHandler _databaseHandler;
        public StudentController(DatabaseHandler handler)
        {
            _databaseHandler = handler;
        }

        [HttpGet]
        public async Task<List<Student>> Get()

        {
            return await _databaseHandler.GetStudentDetail();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
