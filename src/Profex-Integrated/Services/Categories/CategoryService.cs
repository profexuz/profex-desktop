using Newtonsoft.Json;
using Profex_Integrated.Helpers;
using Profex_Integrated.Interfaces;
using Profex_ViewModels.Categories;

namespace Profex_Integrated.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        public static long CategoryId;
        public long page = 1;

        public async Task<IList<CategoryViewModel>> GetAll(long page)
        {
            try
            {

                using (HttpClient client = new HttpClient())
                {

                    client.BaseAddress = new Uri(API.CATEGORY_GET_ALL);

                    var response = await client.GetAsync($"{client.BaseAddress}?page={page}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        var vacancyList = JsonConvert.DeserializeObject<IList<CategoryViewModel>>(responseContent);
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
    }
}
