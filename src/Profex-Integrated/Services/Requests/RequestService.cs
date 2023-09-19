using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_Integrated.Services.Auth.JwtToken;
using Profex_ViewModels.Requests;
using Profex_ViewModels.Vacancies;
using System.Net.Http.Headers;

namespace Profex_Integrated.Services.Requests
{
    public class RequestService : IRequestService
    {
        public static long vacancyId;
        public static long UserId;
        public static long MasterId;
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
                    client.BaseAddress = new Uri("http://64.227.42.134:4040/api/tokenmaster/request/post");
                    MultipartFormDataContent formData = new MultipartFormDataContent();
                    formData.Add(new StringContent(vacancyId.ToString()), "PostId");
                    formData.Add(new StringContent(UserId.ToString()), "UserId");
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
        public async Task<int> DeleteReq(long vacancyId, long UserId)
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
                    client.BaseAddress = new Uri("http://64.227.42.134:4040/api/tokenmaster/post/request");
                    MultipartFormDataContent formData = new MultipartFormDataContent();
                    formData.Add(new StringContent(vacancyId.ToString()), "PostId");

                    formData.Add(new StringContent(UserId.ToString()), "UserId");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, "http://64.227.42.134:4040/api/tokenmaster/post/request");
                    request.Content = formData;
                    HttpResponseMessage response = await client.SendAsync(request);

                 //   var response = await client.DeleteAsync("http://64.227.42.134:4040/api/tokenmaster/post/request", formData);

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
            catch
            {
                return -1;
            }
        }



        public async Task<int> DeleteReq1(long MasterId, long PostId)
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
                    //client.BaseAddress = new Uri("http://64.227.42.134:4040/api/tokenmaster/post/request");
                    client.BaseAddress = new Uri("http://64.227.42.134:4040/api/user/post/delete/request");
                    MultipartFormDataContent formData = new MultipartFormDataContent();
                    formData.Add(new StringContent(MasterId.ToString()), "MasterId");

                    formData.Add(new StringContent(PostId.ToString()), "PostId");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, "http://64.227.42.134:4040/api/tokenmaster/post/request");
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, "http://64.227.42.134:4040/api/user/post/delete/request");
                    request.Content = formData;
                    HttpResponseMessage response = await client.SendAsync(request);


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
            catch
            {
                return -1;
            }
        }

        public async Task<IList<RequestViewModel>> GetAllAsync1(int page)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string tokenFilePath = "C:\\Users\\Public\\Token.txt";
                    if (File.Exists(tokenFilePath))
                    {
                        token = File.ReadAllText(tokenFilePath).Trim();
                    }
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.BaseAddress = new Uri(API.GET_ALL_REQUEST_USESR);

                    var result = await client.GetAsync($"{client.BaseAddress}?/page={page}");

                    // If the upload failed there is not a lot we can do 
                    if (result.IsSuccessStatusCode)
                    {
                        var responseContent = await result.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<IList<RequestViewModel>>(responseContent);  
                        return res;
                    }
                    else
                    {
                        return new List<RequestViewModel>();
                    }
                }
                catch
                {
                    return new List<RequestViewModel>();

                }
            }
        }








        public async Task<IList<RequestViewModel>> GetAllAsync(int page)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string tokenFilePath = "C:\\Users\\Public\\Token.txt";
                    if (File.Exists(tokenFilePath))
                    {
                        token = File.ReadAllText(tokenFilePath).Trim();
                    }
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.BaseAddress = new Uri(API.GET_ALL_REQUEST);

                    var result = await client.GetAsync($"{client.BaseAddress}?/page={page}");

                    // If the upload failed there is not a lot we can do 
                    if (result.IsSuccessStatusCode)
                    {
                        var responseContent = await result.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<IList<RequestViewModel>>(responseContent);
                        return res;
                    }
                    else
                    {
                        return new List<RequestViewModel>();
                    }
                }
                catch
                {
                    return new List<RequestViewModel>();

                }
            }
        }


    }

}
