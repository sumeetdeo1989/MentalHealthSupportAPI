using mentalhealthapi.Data;
using mentalhealthapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mentalhealthapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public DoctorController(AppDBContext dbContext) =>
            _dbContext = dbContext;

        [HttpGet]
        public async Task<List<Doctor>> Get() => await _dbContext.Doctors.ToListAsync();

        [HttpGet("{id}")]
        public async Task<Doctor?> GetById(int id) => await _dbContext.Doctors.FirstOrDefaultAsync(x => x.DoctorId == id);

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Doctor doctor)
        {
            if (doctor == null ||
                string.IsNullOrWhiteSpace(doctor.FirstName) ||
                string.IsNullOrWhiteSpace(doctor.LastName) ||
                string.IsNullOrWhiteSpace(doctor.Gender.ToString())
                )
            {
                return BadRequest("Invalid Request");
            }

            await _dbContext.Doctors.AddAsync(doctor);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = doctor.DoctorId}, doctor);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Doctor doctor)
        {
            if (doctor.DoctorId == 0 ||
                string.IsNullOrWhiteSpace(doctor.FirstName) ||
                string.IsNullOrWhiteSpace(doctor.LastName) ||
                string.IsNullOrWhiteSpace(doctor.Gender.ToString())
                )
            {
                return BadRequest("Invalid Request");
            }

            _dbContext.Doctors.Update(doctor);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var doctor = await GetById(id);
            if (doctor == null)
                return NotFound();
            _dbContext.Doctors.Remove(doctor);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
