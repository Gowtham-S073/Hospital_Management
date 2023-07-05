using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace HospitalManagement.Models
{
    public class DoctorTemp
    {
        [Required]
        public string? Name { get; set; }
        [Key]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }

        [Required]
        public string Roles { get; set; } = string.Empty;

        [Required]
        public string? Password { get; set; }

    }
}
