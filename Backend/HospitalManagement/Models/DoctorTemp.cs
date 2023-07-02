using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace HospitalManagement.Models
{
    public class DoctorTemp
    { 
        [Key]
        [Required]
        public string UserName { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public string? Sex { get; set; }
        public string? Password { get; set; }
        public string? BloodGroup { get; set; }
        public string? Specialization { get; set; }
        public string? Experience { get; set; }
        
        public Int64? PhoneNumber { get; set; }
        
        public string? Address { get; set; }
        
        public ICollection<AppointmentDetail?> Appointments { get; set; } = new List<AppointmentDetail>();
    }
}
