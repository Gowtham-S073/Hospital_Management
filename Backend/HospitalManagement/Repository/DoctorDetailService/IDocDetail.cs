using HospitalManagement.Models; 
using HospitalManagement.Repository.Appointment;

namespace HospitalManagement.Repository.DoctorDetail
{
    public interface IDocDetail
    {
        Task<List<DoctorDetails>> GetAllDoctorDetails();
        Task<string> DeleteDoctorDetails(int id);

        Task<List<DoctorDetails>> PostDoctorDetails(DoctorDetails docDetail);

    }
}
