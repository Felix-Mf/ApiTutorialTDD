using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly DataContext _context;

        public PatientController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddPatientAsync([FromBody] Patient Patient)
        {
            var FetchedPatient = await _context.Patient.FirstOrDefaultAsync(x => x.PhoneNumber == Patient.PhoneNumber);

            // If the patient does not exist create a new one
            if (FetchedPatient == null)
            {
                _context.Patient.Add(Patient);
                await _context.SaveChangesAsync();
                return Created($"/patient/{Patient.PatientId}", Patient);
            }
            // Else throw a bad request
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientAsync()
        {
            return BadRequest();
        }
    }
}