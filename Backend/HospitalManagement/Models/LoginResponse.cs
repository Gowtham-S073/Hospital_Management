namespace HospitalManagement.Models
{
    public class LoginResponse : Status
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? Expiration { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }

        public string Roles { get; set; } = string.Empty;
    }
}
