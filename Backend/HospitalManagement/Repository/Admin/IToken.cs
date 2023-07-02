using HospitalManagement.Models;
using System.Security.Claims;

namespace HospitalManagement.Repository.Admin
{
    public interface IToken
    {
        TokenResponse GetToken(IEnumerable<Claim> claim);
        string GetRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
