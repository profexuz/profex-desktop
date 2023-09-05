using Profex_Integrated.Interfaces;

namespace Profex_Integrated.Services.Auth.JwtToken;

public class IdentityService : IIdentityService
{
    public long Id { get; set; }

    public string RoleName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }
}
