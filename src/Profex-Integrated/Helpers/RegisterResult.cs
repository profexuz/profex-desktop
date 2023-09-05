using Newtonsoft.Json;

namespace Profex_Integrated.Helpers;

public class RegisterResult
{
    [JsonProperty("result")]
    public bool result { get; set; }

    [JsonProperty("token")]
    public string token { get; set; } = String.Empty;
}
