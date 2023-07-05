    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models
{
    public class RegistrationModel
    {
        [Required]
        public string? Name { get; set; }
        [Key]
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
       
        [Required]
        public string Roles { get; set; } = string.Empty;
        
        [Required]
        public string? Password { get; set; }
        
    }
}
