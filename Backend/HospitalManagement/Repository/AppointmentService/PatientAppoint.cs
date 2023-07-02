using Microsoft.EntityFrameworkCore;
using HospitalManagement.Models;

namespace HospitalManagement.Repository.Appointment
{
    public class PatientAppoint : IPatientAppoint
    {
        private DBContext _dbcontext;

        public PatientAppoint(DBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        
        public async Task<List<AppointmentDetail>> GetAllAppointments()
        {
            var AppointDetails = await _dbcontext.Appointment.ToListAsync();
            return AppointDetails;
        }

        public async Task<List<AppointmentDetail>> PostAppointment(AppointmentDetail appoint)
        {
            var postAppoint = _dbcontext.Add(appoint);
            await _dbcontext.SaveChangesAsync();
            return await _dbcontext.Appointment.ToListAsync();
        }
    }
}
