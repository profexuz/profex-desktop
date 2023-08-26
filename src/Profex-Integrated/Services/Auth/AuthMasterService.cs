using Newtonsoft.Json;
using Profex_Dtos.Auth;
using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_Integrated.Security;
using Profex_Integrated.Services.Auth.JwtToken;
using Profex_Integrated.Services.Masters;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace Profex_Integrated.Services.Auth;

public class AuthMasterService : IAuthMasterService
{
    private JwtParser _jwtParser = new JwtParser();
    public async Task<(bool Result, string Token)> LoginAsync(LoginDto loginDto)
    {
        try
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.LOGIN_URL);

            using (var formData = new MultipartFormDataContent())
            {
                StringContent number = new StringContent(loginDto.PhoneNumber.ToString());
                StringContent psw = new StringContent(loginDto.Password.ToString());
                // Try as I might C# adds a CrLf to the end of the job_id tag - so have to strip it in ruby
                formData.Add(number, "PhoneNumber");
                formData.Add(psw, "Password");
                var result = await client.PostAsync(client.BaseAddress, formData);

                // If the upload failed there is not a lot we can do 
                if (result.IsSuccessStatusCode)
                {
                    string responseContent = await result.Content.ReadAsStringAsync();
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent)!;
                    var token = IdentitySingelton.GetInstance();
                    token.Token = jsonResponse.token.ToString();
                    IdentityService tokenModel = _jwtParser.ParseToken(token.Token);
                    token.Id = tokenModel.Id;

                    return (Result: jsonResponse.result, Token: token.Token);
                }
                else
                {
                    return (Result: false, Token: "");
                }
            }
        }
        catch
        {
            return (Result: false, Token: ""); ;
        }
    }



    public async Task<bool> RegisterAsync(RegisterDto dto)
    {
        try
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.REGISTER_URL);

            using (var formData = new MultipartFormDataContent())
            {
                StringContent fname = new StringContent(dto.FirstName.ToString());
                StringContent lname = new StringContent(dto.LastName.ToString());
                StringContent pwd = new StringContent(dto.Password.ToString());
                StringContent number = new StringContent(dto.PhoneNumber.ToString());
                // Try as I might C# adds a CrLf to the end of the job_id tag - so have to strip it in ruby
                formData.Add(fname, "FirstName");
                formData.Add(lname, "LastName");
                formData.Add(pwd, "Password");
                formData.Add(number, "PhoneNumber");
                var result = await client.PostAsync(client.BaseAddress, formData);

                // If the upload failed there is not a lot we can do 
                return result.IsSuccessStatusCode;
            }
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> SendCodeForRegisterAsync(string phone)
    {

        try
        {
            HttpClient client = new HttpClient();
            var phoneNumber = Uri.EscapeDataString(phone);
            var request = new HttpRequestMessage(HttpMethod.Post, $"{API.SENDCODE_URL}?phone=%2B{phone.Substring(1)}");
            request.Headers.Add("phone", phone);
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("phone", phone));
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;

        }
        catch
        {
            return false;
        }
    }

    public async Task<(bool Result, string Token)> VerifyRegisterAsync(VerifyRegisterDto dtos)
    {
        try
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.VERIFY_URL);

            using (var formData = new MultipartFormDataContent())
            {
                StringContent number = new StringContent(dtos.PhoneNumber.ToString());
                StringContent code = new StringContent(dtos.Code.ToString());
                // Try as I might C# adds a CrLf to the end of the job_id tag - so have to strip it in ruby
                formData.Add(number, "PhoneNumber");
                formData.Add(code, "Code");
                var result = await client.PostAsync(client.BaseAddress, formData);

                // If the upload failed there is not a lot we can do 
                if (result.IsSuccessStatusCode)
                {
                    string responseContent = await result.Content.ReadAsStringAsync();
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent)!;                    var token = IdentitySingelton.GetInstance();
                    token.Token = jsonResponse.token.ToString();
                    IdentityService tokenModel = _jwtParser.ParseToken(token.Token);
                    token.Id = tokenModel.Id;
                    return (Result: true, Token: token.Token);
                }
                else
                {
                    return (Result: false, Token: "");
                }
            }
        }
        catch
        {
            return (Result: false, Token: ""); ;
        }
    }

    
}
