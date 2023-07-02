using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repository.DoctorDetail
{
    public class DocDetail : IDocDetail
    {
        private DBContext _dbContext;

        public DocDetail(DBContext dBContext) 
        {
            _dbContext = dBContext;
        }

        public async Task<string> DeleteDoctorDetails(int id)
        {
            var details = await _dbContext.DoctorDetails.FirstOrDefaultAsync(x => x.id == id);
            _dbContext.Remove(details);
            _dbContext.SaveChanges();
            return "Deleted";
        }

        public async Task<List<DoctorDetails>> GetAllDoctorDetails()
        {
            var details = await _dbContext.DoctorDetails.ToListAsync();
            return details;
        }

        public async Task<List<DoctorDetails>> PostDoctorDetails(DoctorDetails docDetail)
        {
            var details = _dbContext.DoctorDetails.Add(docDetail);
            _dbContext.SaveChanges();
            return await _dbContext.DoctorDetails.ToListAsync();
        }
    }
}
