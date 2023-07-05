using HospitalManagement.Models;

namespace HospitalManagement.Repository.Doctortemp
{
    public interface IDoctemp
    {
        Task<List<DoctorTemp>> GetDoctorDetails();

        

        Task<List<DoctorTemp>> PostDoctorDetails(DoctorTemp doctemp);

        Task<string> DeleteDoctorDetail(string id);
    }
}
