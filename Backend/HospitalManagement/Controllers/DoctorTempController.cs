using HospitalManagement.Models;
using HospitalManagement.Repository.Appointment;
using HospitalManagement.Repository.Doctortemp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorTempController : ControllerBase
    {
        private readonly IDoctemp _context;

        public DoctorTempController(IDoctemp context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorDetails()
        {
            try
            {
                var doctorDetails = await _context.GetDoctorDetails();
                return Ok(doctorDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while retrieving doctor details.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostDoctorDetails(DoctorTemp docDetail)
        {
            try
            {
                var result = await _context.PostDoctorDetails(docDetail);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while saving doctor details.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDoctorDetail(string Username)
        {
            try
            {
                var result = await _context.DeleteDoctorDetail(Username);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while deleting doctor details.");
            }
        }
    }
}
