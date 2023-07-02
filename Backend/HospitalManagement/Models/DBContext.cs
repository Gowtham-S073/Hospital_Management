using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HospitalManagement.Models
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<TokenInfo> TokenInfo { get; set; }
        public DbSet<AppointmentDetail> Appointment { get; set; }
        public DbSet<DoctorDetails> DoctorDetails { get; set; }
        public DbSet<DoctorTemp> DoctorTemp { get; set; }


    }

}
