using System.Globalization;
using HospitalManagement.Models;
namespace HospitalManagement.Repository.Appointment
{
    public interface IPatientAppoint
    {
        public Task<List<AppointmentDetail>> GetAllAppointments();

        
        public Task<List<AppointmentDetail>> PostAppointment(AppointmentDetail appoint);
        

    }
}
