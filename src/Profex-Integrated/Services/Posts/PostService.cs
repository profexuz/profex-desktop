using Newtonsoft.Json;
using Profex_Dtos.Post;
using Profex_Dtos.PostImages;
using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_Integrated.Services.Auth;
using Profex_Integrated.Services.Auth.JwtToken;
using Profex_ViewModels.Masters;
using Profex_ViewModels.Vacancies;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace Profex_Integrated.Services.Posts;

public class PostService : IPostService
{
    //public static long CategoryId;
    public static long UserId;
    private string Token = "User";
    public string token;
    public long page = 1;
    private string _path = "C:\\Users\\Public\\Token.txt";
    private JwtParser jwtParser = new JwtParser();


    public async Task<IList<Vacancy>> GetAllMyPost(long page)
    {
        try
        {
            string token1 = File.ReadAllText(_path);
            IdentityService identityService = jwtParser.ParseToken(token1);

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(API.GET_ALL_MY_POSTS);

                var response = await client.GetAsync($"{client.BaseAddress}/{identityService.Id}?page={page}");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var vacancyList = JsonConvert.DeserializeObject<IList<Vacancy>>(responseContent);
                    return vacancyList;
                }
                else
                {
                    return null;
                }
            }
        }
        catch
        {
            return null;
        }
    }

    public async Task<int> AddPost(PostCreateDto dto)
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
                client.BaseAddress = new Uri(API.CREATE_POST);
                MultipartFormDataContent formData = new MultipartFormDataContent();
                
                formData.Add(new StringContent(dto.CategoryId.ToString()), "CategoryId");
                formData.Add(new StringContent(dto.Title.ToString()), "Title");
                formData.Add(new StringContent(dto.Price.ToString()), "Price");
                formData.Add(new StringContent(dto.Deccription.ToString()), "Description");
                formData.Add(new StringContent(dto.Region.ToString()), "Region");
                formData.Add(new StringContent(dto.District.ToString()), "District");
                formData.Add(new StringContent(dto.Latidute.ToString()), "Latidute");
                formData.Add(new StringContent(dto.Longitude.ToString()), "Longitude");
                formData.Add(new StringContent(dto.PhoneNumber.ToString()), "PhoneNumber");

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
    public async Task<int> AddPostImage(PostImageCreateDto dto)
    {
        long son = dto.PostId+1;
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
                formData.Add(new StringContent(son.ToString()), "PostId");
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


    public async Task<IList<Vacancy>> SearchAsync(string search)
    {
        //throw new NotImplementedException();
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(API.SEARCH_VACANCY);

                // Qidiruv so'zini query parametri sifatida qo'shish
                //var response = await client.GetAsync($"{client.BaseAddress}?search={search}");
                var response = await client.GetAsync($"?search={search}");
                //https://localhost:7145/api/common/master/search?search=das&page=1

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var vacancies = JsonConvert.DeserializeObject<IList<Vacancy>>(responseContent);
                    return vacancies;
                }
                else
                {
                    // Agar javob yaxshi kelmasa, bo'sh ro'yxatni qaytarish
                    return new List<Vacancy>();
                }
            }
        }
        catch
        {
            // Xato yuzaga kelsa, hammasini o'zgartirishsiz
            return new List<Vacancy>();
        }
    }




}
