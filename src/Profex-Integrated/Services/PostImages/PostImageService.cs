using Profex_Dtos.PostImages;
using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_Integrated.Services.Auth.JwtToken;
using Profex_ViewModels.Requests;
using System.Net.Http.Headers;

namespace Profex_Integrated.Services.PostImages
{
    public class PostImageService : IPostImageService
    {
        public static long PostId;
        private string Token = "User";
        public string token;
        public long page = 1;
        private string _path = "C:\\Users\\Public\\Token.txt";
        private JwtParser jwtParser = new JwtParser();

        public async Task<int> AddPostImage(PostImageCreateDto dto)
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
                    client.BaseAddress = new Uri(API.CREATE_IMAGE_POST);
                    MultipartFormDataContent formData = new MultipartFormDataContent();
                    formData.Add(new StringContent(dto.PostId.ToString()), "PostId");
                    if (dto.ImagePath != null)
                    {
                        // Ma'lumotlarni IFormFile turidagi ma'lumot sifatida qo'shish
                        formData.Add(new StreamContent(dto.ImagePath.OpenReadStream()), "ImagePath", dto.ImagePath.FileName);
                    }
                   

                    //formData.Add(new StringContent(dto.ImagePath.ToString()), "ImagePath");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var response = await client.PostAsync("", formData);
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
