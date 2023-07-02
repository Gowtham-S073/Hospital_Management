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
        public async Task<List<DoctorTemp>> GetDoctorDetails()
        {
            return await _context.GetDoctorDetails();
        }
        [HttpPost]
        public async Task<ActionResult<List<DoctorTemp>>> PostDoctorDetails(DoctorTemp docDetail)
        {
            return await _context.PostDoctorDetails(docDetail);
        }
        [HttpDelete]
        public async Task<string> DeleteDoctorDetail(string Username)
        {
            return await _context.DeleteDoctorDetail(Username);
        }
    }
}
