using HospitalManagement.Models;
using HospitalManagement.Repository.DoctorDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorDetailController : ControllerBase
    {
        private IDocDetail _dbcontext;

        public DoctorDetailController(IDocDetail dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctorDetails()
        {
            try
            {
                var doctorDetails = await _dbcontext.GetAllDoctorDetails();
                return Ok(doctorDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while retrieving doctor details.");
            }
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetDoctorDetailByUsername(string id)
        {
            try
            {
                var doctorDetails = await _dbcontext.GetDoctorDetailbyUsername(id);
                return Ok(doctorDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while retrieving doctor details.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostDoctorDetails(DoctorDetails docDetail)
        {
            try
            {
                var result = await _dbcontext.PostDoctorDetails(docDetail);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while saving doctor details.");
            }
        }
    }
}
