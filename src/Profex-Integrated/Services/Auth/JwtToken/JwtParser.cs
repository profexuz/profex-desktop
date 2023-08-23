using System.IdentityModel.Tokens.Jwt;

namespace Profex_Integrated.Services.Auth.JwtToken;

public class JwtParser
{
    public IdentityService ParseToken(string tokenString)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(tokenString);

        var myTokenModel = new IdentityService()
        {
            Id = long.Parse(token.Claims.FirstOrDefault(claim => claim.Type == "Id")?.Value),
            FirstName = token.Claims.FirstOrDefault(claim => claim.Type == "FirstName")?.Value,
            LastName = token.Claims.FirstOrDefault(claim => claim.Type == "LastName")?.Value,
            RoleName = token.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value,
            PhoneNumber = token.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone")?.Value,
        };

        return myTokenModel;
    }
}
