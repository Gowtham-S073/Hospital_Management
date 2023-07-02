using HospitalManagement.Models;
using HospitalManagement.Repository.DoctorDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class DoctorDetailController : ControllerBase
        {
            private IDocDetail _dbcontext;
            public DoctorDetailController(IDocDetail dbcontext)
            {
                _dbcontext = dbcontext;
            }


            [HttpGet]
            public async Task<List<DoctorDetails>> GetAllDoctorDetails()
            {
                return await  _dbcontext.GetAllDoctorDetails();
            }

            [HttpPost]
            public async Task<List<DoctorDetails>> PostDoctorDetails(DoctorDetails docDetail)
            {
                return await _dbcontext.PostDoctorDetails(docDetail);
            }

            [HttpDelete]
            public async Task<string> DeleteDoctorDetails(int id)
            {
                return await _dbcontext.DeleteDoctorDetails(id);

            }

        }
}