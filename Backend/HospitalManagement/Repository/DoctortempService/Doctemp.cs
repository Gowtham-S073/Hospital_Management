using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repository.Doctortemp
{
    public class Doctemp : IDoctemp
    {
        private DBContext _dbcontext;

        public Doctemp(DBContext dBContext)
        {
            _dbcontext = dBContext;
        }
        public async Task<List<DoctorTemp>> GetDoctorDetails()
        {
            var details = await _dbcontext.DoctorTemp.ToListAsync();
            return details;
        }
        
        public async Task<List<DoctorTemp>> PostDoctorDetails(DoctorTemp doctemp)
        {
            _dbcontext.DoctorTemp.Add(doctemp);
            _dbcontext.SaveChanges();
            return await _dbcontext.DoctorTemp.ToListAsync();
        }
        public async Task<string> DeleteDoctorDetail(string Username)
        {
            var details = _dbcontext.DoctorTemp.FirstOrDefault(x => x.UserName == Username);
            _dbcontext.DoctorTemp.Remove(details);
            _dbcontext.SaveChanges();
            return "Detail Deleted";
        }
    }
}
