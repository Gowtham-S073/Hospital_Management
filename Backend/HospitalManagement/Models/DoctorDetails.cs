using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class DoctorDetails
    {
        [Key]
        public int? id { get; set; }
        [Required]
        public string? DoctorName { get; set; }
        [Required]
        public string? Sex { get; set; }
        [Required]
        public string? Specialization { get; set; }
        [Required]
        public string? Experience { get; set; }
        [Required]
        public Int64? PhoneNumber { get; set; }

        public ICollection<AppointmentDetail> Appointments { get; set; } = new List<AppointmentDetail>();
    }
}
