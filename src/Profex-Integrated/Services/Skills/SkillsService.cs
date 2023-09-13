using Newtonsoft.Json;
using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_ViewModels.Categories;
using Profex_ViewModels.Masters;
using Profex_ViewModels.Skills;

namespace Profex_Integrated.Services.Skills
{
    public class SkillsService : ISkillService
    {
        
        public async Task<IList<CategoryViewModel>> GetAllAysnc(long page)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //client.BaseAddress = new Uri(API.GET_ALL_CATEGORY+"?page=1");
                    client.BaseAddress = new Uri(API.GET_ALL_CATEGORY + $"?page={page}");
                    var result = await client.GetAsync(client.BaseAddress);

                    if(result.IsSuccessStatusCode)
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
                    var response = await client.GetAsync($"{client.BaseAddress}/{categoryId}?&{page}");
                    if(response.IsSuccessStatusCode)
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
                using(HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API.GET_BY_SKILL_ID);
                    var response = await client.GetAsync($"{client.BaseAddress}/{id}");
                    if(response.IsSuccessStatusCode)
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
            catch { return new List <SkillViewModel>(); }
        }
    }
}
