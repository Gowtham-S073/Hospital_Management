using HospitalManagement.Models; 
using HospitalManagement.Repository.Appointment;

namespace HospitalManagement.Repository.DoctorDetail
{
    public interface IDocDetail
    {
        Task<List<DoctorDetails>> GetAllDoctorDetails();
        Task<List<DoctorDetails>> GetDoctorDetailbyUsername(string id);
        Task<List<DoctorDetails>> PostDoctorDetails(DoctorDetails docDetail);

    }
}
