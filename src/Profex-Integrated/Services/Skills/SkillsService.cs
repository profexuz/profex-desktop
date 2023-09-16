using Newtonsoft.Json;
using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_ViewModels.Categories;
using Profex_ViewModels.Masters;
using Profex_ViewModels.Skills;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Profex_Integrated.Services.Skills
{
    public class SkillsService : ISkillService
    {
        public static long CategoryId;
        public static long MasterId;
        private string Token = "Master";
        public string token;

        
        public async Task<IList<CategoryViewModel>> GetAllAysnc(long page)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(API.GET_ALL_CATEGORY + $"?page={page}");
                    var result = await client.GetAsync(client.BaseAddress);

                    if (result.IsSuccessStatusCode)
                    {
                        var responseContent = await result.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<IList<CategoryViewModel>>(responseContent);
                        return res;
                    }
                    else
                    {
                        return new List<CategoryViewModel>();
                    }
                }
                catch
                {
                    return new List<CategoryViewModel>();
                }
            }
        }

        public async Task<IList<SkillViewModel>> GetByCategoryId(long categoryId, long page)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API.GET_ALL_BY_CATEGORY_ID);
                    var response = await client.GetAsync($"{client.BaseAddress}?categoryId={categoryId}&page={page}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        var skilview = JsonConvert.DeserializeObject<IList<SkillViewModel>>(responseContent);
                        return skilview;
                        
                    }
                    else
                    {
                        return new List<SkillViewModel>();
                    }
                }

            }
            catch { return new List<SkillViewModel>(); }
        }

        public async Task<IList<SkillViewModel>> GetById(long id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API.GET_BY_SKILL_ID);
                    var response = await client.GetAsync($"{client.BaseAddress}/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        var skillView = JsonConvert.DeserializeObject<IList<SkillViewModel>>(responseContent);
                        return skillView;
                    }
                    else
                    {
                        return new List<SkillViewModel>();
                    }

                }
            }
            catch { return new List<SkillViewModel>(); }


        }

        public async Task<int> AddSkill(long skillId)
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
                    client.BaseAddress = new Uri(API.GET_ADD_SKILL);

                    MultipartFormDataContent formData = new MultipartFormDataContent();

                    formData.Add(new StringContent(skillId.ToString()), "skillId");

                    // Add the authentication token to the request headers.
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

        public async Task<MasterViewModel> GetAllMySkills(long masterId)
        {
            try
            {           

                using (HttpClient client = new HttpClient())
                {

                    client.BaseAddress = new Uri(API.MY_ALL_SKILL);

                    //var response = await client.GetAsync($"{client.BaseAddress}/{12}");
                    var response = await client.GetAsync($"{client.BaseAddress}/{12}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        var masterViewModel = JsonConvert.DeserializeObject<MasterViewModel>(responseContent);
                        return masterViewModel;
                    }
                    else
                    {
                        return new MasterViewModel();
                    }
                }
            }
            catch
            {
                return new MasterViewModel();
            }
        }

        public async Task<int> RemoveMySkill(long skillId)
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
                    client.BaseAddress = new Uri($"{API.REMOVE_MY_SKILL}/{skillId}"); // Yangi manzil

                    // Add the authentication token to the request headers.
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var response = await client.DeleteAsync(""); // Bo'sh qo'shimcha so'rovni yuboring

                    if (response.IsSuccessStatusCode)
                    {
                        return 1; // Success
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return -2; // Unauthorized
                    }
                    else
                    {
                        return 0; // Other errors
                    }
                }
            }
            catch
            {
                return -1; // Exception occurred
            }
            /*try
            {
                string tokenFilePath = "C:\\Users\\Public\\Token.txt";

                if (File.Exists(tokenFilePath))
                {
                    token = File.ReadAllText(tokenFilePath).Trim();
                }

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API.REMOVE_MY_SKILL);

                    // Add the authentication token to the request headers.
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var response = await client.DeleteAsync(skillId.ToString()); // Use skillId directly in the URL

                    if (response.IsSuccessStatusCode)
                    {
                        return 1; // Success
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return -2; // Unauthorized
                    }
                    else
                    {
                        return 0; // Other errors
                    }
                }
            }
            catch
            {
                return -1; // Exception occurred
            }*/
            /*try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API.REMOVE_MY_SKILL);
                    var response = await client.DeleteAsync($"{client.BaseAddress}/{skillId}");
                    
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
*/

        }

    }
}
