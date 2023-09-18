using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_Integrated.Services.Auth.JwtToken;
using System.Net.Http.Headers;

namespace Profex_Integrated.Services.Requests
{
    public class RequestService : IRequestService
    {
        public static long vacancyId;
        public static long UserId;
        private string Token = "Master";
        private string _path = "C:\\Users\\Public\\Token.txt";
        private string token;
        private JwtParser jwtParser = new JwtParser();

        public async Task<int> AddRequest(long vacancyId, long UserId)
        {

            try
            {
                string tokenFilePath = "C:\\Users\\Public\\Token.txt";


                if (File.Exists(tokenFilePath))
                {
                    token = File.ReadAllText(tokenFilePath).Trim();
                }
                using (HttpClient client = new HttpClient())
                {
                    //client.BaseAddress = new Uri(API.SENT_REQUEST);
                    client.BaseAddress = new Uri("http://64.227.42.134:4040/api/tokenmaster/request/post");

                    MultipartFormDataContent formData = new MultipartFormDataContent();

                    formData.Add(new StringContent(vacancyId.ToString()), "PostId");
                    formData.Add(new StringContent(UserId.ToString()), "UserId");

                    // Add the authentication token to the request headers.
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var response = await client.PostAsync(client.BaseAddress,formData);
                    if (response.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }

                }
            }
            catch { return -1; }
        }

    }
}
