using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Profex_Dtos.Auth;

public class RegisterDto
{
    [JsonProperty("FirstName")]
    public string FirstName { get; set; } = String.Empty;
    
    [JsonProperty("LastName")]
    public string LastName { get; set; } = String.Empty;

    [JsonProperty("PhoneNumber")]
    public string PhoneNumber { get; set; } = String.Empty;
    
    [JsonProperty("Password")]
    public string Password { get; set; } = string.Empty;
}
