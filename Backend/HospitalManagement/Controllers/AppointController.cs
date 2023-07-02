using HospitalManagement.Models;
using HospitalManagement.Repository.Appointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointController : ControllerBase
    {
        private IPatientAppoint _dbcontext;

        public AppointController(IPatientAppoint dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<List<AppointmentDetail>> GetAllAppointments()
        {
            return await _dbcontext.GetAllAppointments();
        }

        [HttpPost]
        public async Task<List<AppointmentDetail>> PostAppointment(AppointmentDetail appointmentDetail)
        {
            return await _dbcontext.PostAppointment(appointmentDetail);
        }


    }

}
