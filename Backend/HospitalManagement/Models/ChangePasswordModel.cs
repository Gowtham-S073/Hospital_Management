using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class ChangePasswordModel
    {
        [Key]
        public int? id { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? CurrentPassword { get; set; }
        [Required]
        public string? NewPassword { get; set; }
        [Required]
        [Compare("NewPassword")]
        public string? ConfirmNewPassword { get; set; }
    }
}
