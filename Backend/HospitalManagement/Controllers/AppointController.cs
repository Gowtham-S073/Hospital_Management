using HospitalManagement.Models;
using HospitalManagement.Repository.Appointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

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
        public async Task<ActionResult<List<AppointmentDetail>>> GetAllAppointments()
        {
            try
            {
                return await _dbcontext.GetAllAppointments();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving appointments.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<AppointmentDetail>>> PostAppointment(AppointmentDetail appointmentDetail)
        {
            try
            {
                return await _dbcontext.PostAppointment(appointmentDetail);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating an appointment.");
            }
        }
    }
}
